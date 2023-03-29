import React, { useEffect, useState } from "react";
import { useFetching } from "./../../../hooks/useFetching";
import Repair from "./../../../api/repair";
import Modal from "./../../../components/forms/modal/Modal";
import { getDateForInput } from "./../../../utils/getDateForInput";

const RepairInformationByTransport = ({ transportId }) => {
  let [modalActive, setModalActive] = useState(false);
  let [params, setParams] = useState({
    transportId: 0,
    start: null,
    end: null,
  });
  let [information, setInformation] = useState({
    count: "",
    price: "",
  });

  const [fetchInformation, isInformationLoading, informationError] =
    useFetching(async (params) => {
      const response = await Repair.getRepairInformationByTransportId({
        ...params,
        transportId: transportId,
      });
      setInformation(response.data);
    });

  const update = () => {
    fetchInformation(params);
  };

  return (
    <div>
      <button
        onClick={() => {
          setModalActive(true);
        }}
      >
        Получить информацию о ремонтах по категории
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

        <div>Количество : {information.count}</div>
        <div>Общая стоимость : {information.price}</div>

        <div>
          <button onClick={update}>Обновить таблицу</button>
        </div>
      </Modal>
    </div>
  );
};

export default RepairInformationByTransport;
