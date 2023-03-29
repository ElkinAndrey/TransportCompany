import React, { useEffect, useState } from "react";
import Modal from "../../../components/forms/modal/Modal";
import { getDateForInput } from "../../../utils/getDateForInput";
import { useFetching } from "../../../hooks/useFetching";
import Transport from "../../../api/transport";
import Repair from "../../../api/repair";

const RepairInformationByCategory = () => {
  let [modalActive, setModalActive] = useState(false);
  let [params, setParams] = useState({
    categoryId: 0,
    start: null,
    end: null,
  });
  let [categories, setCategories] = useState([]);
  let [information, setInformation] = useState({
    count: "",
    price: "",
  });

  const [fetchCategories, isCategoriesLoading, categoriesError] = useFetching(
    async () => {
      const response = await Transport.getTransportCategories();
      setCategories(response.data);
    }
  );

  const [fetchInformation, isInformationLoading, informationError] =
    useFetching(async (params) => {
      const response = await Repair.getRepairInformationByCategoryId(params);
      setInformation(response.data);
    });

  useEffect(() => {
    fetchCategories();
  }, []);

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

        <div>Количество : {information.count}</div>
        <div>Общая стоимость : {information.price}</div>

        <div>
          <button onClick={update}>Обновить таблицу</button>
        </div>
      </Modal>
    </div>
  );
};

export default RepairInformationByCategory;
