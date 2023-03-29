import React, { useEffect, useState } from "react";
import Modal from "./../../../components/forms/modal/Modal";
import { useFetching } from "./../../../hooks/useFetching";
import Transport from "./../../../api/transport";
import Repair from "./../../../api/repair";
import { getDateForInput } from "./../../../utils/getDateForInput";

const DetailsByCategory = () => {
  let [modalActive, setModalActive] = useState(false);
  let [params, setParams] = useState({
    categoryId: 0,
    start: null,
    end: null,
    detailsId: [],
  });
  let [details, setDetails] = useState([]);
  let [categories, setCategories] = useState([]);
  let [detailsCount, setDetailsCount] = useState([]);

  const [fetchDetails, isDetailsLoading, detailsError] = useFetching(
    async () => {
      const response = await Repair.getDetails();
      setDetails(
        response.data.map((detail) => ({ ...detail, isAdd: false, count: "" }))
      );
    }
  );

  const [fetchCategories, isCategoriesLoading, categoriesError] = useFetching(
    async () => {
      const response = await Transport.getTransportCategories();
      setCategories(response.data);
    }
  );

  const [fetchDetailsCount, isDetailsCountLoading, detailsCountError] =
    useFetching(async (params) => {
      const response = await Repair.getDetailsByCategoryId(params);
      setDetailsCount(response.data);
    });

  useEffect(() => {
    fetchCategories();
    fetchDetails();
  }, []);

  const update = () => {
    fetchDetailsCount({
      ...params,
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
        Получить информацию о количестве ремонтируемых деталей по категории
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

        <select
          value={params.categoryId}
          onChange={(e) => {
            setParams({ ...params, categoryId: e.target.value });
          }}
        >
          <option value={0}>Всё</option>
          {categories.map((category) => (
            <option key={category[0]} value={category[0]}>
              {category[1]}
            </option>
          ))}
        </select>

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
          <div key={dc.name}>{dc.name} : {dc.count}</div>
        ))}

        <div>
          <button onClick={update}>Обновить таблицу</button>
        </div>
      </Modal>
    </div>
  );
};

export default DetailsByCategory;
