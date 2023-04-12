import React from 'react'
import { useState } from 'react';
import { useFetching } from './../../hooks/useFetching';
import { useEffect } from 'react';
import Modal from './../../components/forms/modal/Modal';
import { getDateForInput } from './../../utils/getDateForInput';
import Transport from "./../../api/transport";

const MileageByTransport = ({transportId}) => {
  let [modalActive, setModalActive] = useState(false);
  let [params, setParams] = useState({
    transportId: transportId,
    start: null,
    end: null,
  });
  let [mileage, setMileage] = useState("");

  const [fetchMileage, isMileageLoading, mileageError] = useFetching(
    async (params) => {
      const response = await Transport.getMileageByTransportId(params);
      setMileage(response.data);
    }
  );

  useEffect(() => {
    fetchMileage({ ...params, transportId: transportId });
  }, []);

  const update = () => {
    fetchMileage({ ...params, transportId: transportId });
  };

  return (
    <div>
      <button
        onClick={() => {
          setModalActive(true);
        }}
      >
        Посмотреть пробег за период
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

        <div>Пробег : {mileage}</div>

        <div>
          <button onClick={update}>Обновить</button>
        </div>
      </Modal>
    </div>
  );
}

export default MileageByTransport