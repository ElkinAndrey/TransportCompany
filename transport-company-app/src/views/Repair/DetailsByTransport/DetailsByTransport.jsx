import React, { useEffect, useState } from "react";
import { getDateForInput } from "./../../../utils/getDateForInput";
import Modal from "./../../../components/forms/modal/Modal";
import { useFetching } from "./../../../hooks/useFetching";
import Repair from "./../../../api/repair";

const DetailsByTransport = ({ transportId }) => {
  let [modalActive, setModalActive] = useState(false);
  let [params, setParams] = useState({
    transportId: 0,
    start: null,
    end: null,
  });
  let [details, setDetails] = useState([]);
  let [detailsCount, setDetailsCount] = useState([]);

  const [fetchDetails, isDetailsLoading, detailsError] = useFetching(
    async () => {
      const response = await Repair.getDetails();
      setDetails(
        response.data.map((detail) => ({ ...detail, isAdd: false, count: "" }))
      );
    }
  );

  const [fetchInformation, isInformationLoading, informationError] =
    useFetching(async (params) => {
      const response = await Repair.getDetailsByTransportId(params);
      setDetailsCount(response.data);
    });

  useEffect(() => {
    fetchDetails();
  }, []);

  const update = () => {
    fetchInformation({
      ...params,
      transportId: transportId,
      detailsId: details.filter((d) => d.isAdd).map((d) => d.id),
    });
  };

  return (
    <div>
      <button
        onClick={() => {
          setModalActive(true);
        }}
      >
        Получить информацию о количестве ремонтируемых деталей у трансопорта
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
              <th>Нужно найти</th>
            </tr>
          </thead>
          <tbody>
            {details.map((detail, index) => (
              <tr key={detail.id}>
                <td>{detail.name}</td>
                <td>
                  <input
                    type={"checkbox"}
                    checked={detail.isAdd}
                    onChange={() => {
                      details[index].isAdd = !details[index].isAdd;
                      setDetails([...details]);
                    }}
                  />
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        {detailsCount.map((dc) => (
          <div key={dc.name}>
            {dc.name} : {dc.count}
          </div>
        ))}

        <div>
          <button onClick={update}>Обновить таблицу</button>
        </div>
      </Modal>
    </div>
  );
};

export default DetailsByTransport;
