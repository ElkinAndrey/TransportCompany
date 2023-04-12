import React, { useRef, useState } from "react";
import { getDateForInput } from "./../../../utils/getDateForInput";
import Modal from "./../../../components/forms/modal/Modal";
import Repair from "./../../../api/repair";
import { useFetching } from "./../../../hooks/useFetching";
import Transport from "./../../../api/transport";
import { useEffect } from "react";
import TransportMiniTable from "../../Tables/TransportMiniTable/TransportMiniTable";

const RepairByPersonAndTransport = ({ personId, brigadeId }) => {
  const dataFetchedRef = useRef(false);
  let [modalActive, setModalActive] = useState(false);
  let [params, setParams] = useState({
    personId: 0,
    transportId: 0,
    start: null,
    end: null,
  });
  let [repairs, setRepairs] = useState([]);
  let [transports, setTransports] = useState([]);

  const [fetchRepairs, isRepairsLoading, repairsError] = useFetching(
    async (params) => {
      const response = await Repair.getRepairByPersonIdAndTransportId(params);
      setRepairs(response.data);
    }
  );

  const [fetchTransports, isTransportsLoading, transportsError] = useFetching(
    async (brigadeId) => {
      const response = await Transport.getTransportsByBrigadeId(brigadeId);
      setTransports(response.data);
    }
  );

  useEffect(() => {
    if (dataFetchedRef.current) return;
    dataFetchedRef.current = true;
    fetchTransports(brigadeId);
  }, []);

  const update = (transportId) => {
    fetchRepairs({
      ...params,
      personId: personId,
      transportId: transportId,
    });
  };

  return (
    <div>
      <button
        onClick={() => {
          setModalActive(true);
        }}
      >
        Посмотреть ремонты по транспорту
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

        <h4>Транспорт</h4>

        <table>
          <thead>
            <tr>
              <th>Уникальный Id</th>
              <th>Категория</th>
              <th>Серия</th>
              <th>Номер</th>
              <th>Код региона</th>
              <th>Код страны</th>
              <th>Пробег (км)</th>
              <th>Компания производитель</th>
              <th>Модель</th>
              <th>Год издания</th>
            </tr>
          </thead>
          <tbody>
            {transports.map((transport) => (
              <tr
                key={transport.transportId}
                className={"stringTable"}
                onClick={() => {
                  update(transport.transportId);
                }}
              >
                <td>{transport.transportId}</td>
                <td>{transport.category}</td>
                <td>{transport.series}</td>
                <td>{transport.number}</td>
                <td>{transport.regionCode}</td>
                <td>{transport.countryCode}</td>
                <td>{transport.mileage}</td>
                <td>{transport.manufacturerCompany}</td>
                <td>{transport.transportModel}</td>
                <td>{transport.yearPublishing}</td>
              </tr>
            ))}
          </tbody>
        </table>

        <h4>Ремонты</h4>

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
      </Modal>
    </div>
  );
};

export default RepairByPersonAndTransport;
