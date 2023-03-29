import React, { useEffect, useState } from "react";
import { useFetching } from "./../../../hooks/useFetching";
import Repair from "./../../../api/repair";
import Modal from "./../../../components/forms/modal/Modal";
import { getDateForInput } from "./../../../utils/getDateForInput";
import BrandTransport from "./../../BrandTransport/BrandTransport";

const DetailsByBrand = () => {
  let [modalActive, setModalActive] = useState(false);
  let [params, setParams] = useState({
    brandId: 0,
    start: null,
    end: null,
    detailsId: [],
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

  const [fetchDetailsCount, isDetailsCountLoading, detailsCountError] =
    useFetching(async (params) => {
      const response = await Repair.getDetailsByBrandId(params);
      setDetailsCount(response.data);
    });

  useEffect(() => {
    fetchDetails();
  }, []);

  const update = () => {
    if (params.brandId !== 0) {
      fetchDetailsCount({
        ...params,
        detailsId: details.filter((d) => d.isAdd).map((d) => d.id),
      });
    }
    else{
        setDetailsCount([])
    }
  };

  return (
    <div>
      <button
        onClick={() => {
          setModalActive(true);
        }}
      >
        Получить информацию о количестве ремонтируемых деталей по марке
        трансопорта
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

        <BrandTransport
          brandId={params.brandId}
          setBrandId={(newBrandId) => {
            setParams({ ...params, brandId: newBrandId });
          }}
        />

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

export default DetailsByBrand;
