import React from "react";
import Modal from "./../../../components/forms/modal/Modal";
import { useState } from "react";
import { getDateForInput } from "./../../../utils/getDateForInput";
import { useFetching } from "./../../../hooks/useFetching";
import Repair from "./../../../api/repair";

const RepairByPerson = ({ personId }) => {
  let [modalActive, setModalActive] = useState(false);
  let [params, setParams] = useState({
    personId: 0,
    start: null,
    end: null,
  });
  let [repairs, setRepairs] = useState([]);

  const [fetchRepairs, isRepairsLoading, repairsError] = useFetching(
    async (params) => {
      const response = await Repair.getRepairByPersonId(params);
      setRepairs(response.data);
    }
  );

  const update = () => {
    fetchRepairs({
      ...params,
      personId: personId,
    });
  };

  return (
    <div>
      <button
        onClick={() => {
          setModalActive(true);
        }}
      >
        Посмотреть ремонты
      </button>
      <Modal active={modalActive} setActive={setModalActive}>
        <div>
          <div>
            <label>Начало</label>
            <input
              type={"date"}
              value={getDateForInput(params.start)}
              onChange={(e) => {
                setParams({
                  ...params,
                  start: new Date(e.target.value),
                });
              }}
            />
          </div>
          <div>
            <label>Конец</label>
            <input
              type={"date"}
              value={getDateForInput(params.end)}
              onChange={(e) => {
                setParams({ ...params, end: new Date(e.target.value) });
              }}
            />
          </div>
          <button
            onClick={() => setParams({ ...params, start: null, end: null })}
          >
            Сбросить
          </button>
        </div>

        <table>
          <thead>
            <tr>
              <th>Деталь</th>
              <th>Действие</th>
              <th>Номер ремонта</th>
              <th>Общая стоимость ремонта</th>
              <th>Начало ремонта</th>
              <th>Окончание ремонта</th>
            </tr>
          </thead>
          <tbody>
            {repairs.map((r) => (
              <tr key={r.detail + r.repair.repairId}>
                <td>{r.detail}</td>
                <td>{r.action}</td>
                <td>{r.repair.repairId}</td>
                <td>{r.repair.price}</td>
                <td>{r.repair.start}</td>
                <td>{r.repair.end}</td>
              </tr>
            ))}
          </tbody>
        </table>

        <div>
          <button onClick={update}>Обновить таблицу</button>
        </div>
      </Modal>
    </div>
  );
};

export default RepairByPerson;
