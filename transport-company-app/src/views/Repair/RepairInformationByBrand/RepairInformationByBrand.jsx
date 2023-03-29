import React, { useState } from "react";
import Modal from "./../../../components/forms/modal/Modal";
import BrandTransport from "./../../BrandTransport/BrandTransport";
import { useFetching } from "./../../../hooks/useFetching";
import Repair from "./../../../api/repair";

const RepairInformationByBrand = () => {
  let [modalActive, setModalActive] = useState(false);
  let [params, setParams] = useState({
    brandId: 0,
    start: null,
    end: null,
  });
  let [information, setInformation] = useState({
    count: "",
    price: "",
  });

  const [fetchInformation, isInformationLoading, informationError] =
    useFetching(async (params) => {
      const response = await Repair.getRepairInformationByBrandId(params);
      setInformation(response.data);
    });

  const update = () => {
    if (params.brandId !== 0) {
      fetchInformation(params);
    }
    else{
      setInformation({
        count: "",
        price: "",
      });
    }
  };

  return (
    <div>
      <button
        onClick={() => {
          setModalActive(true);
        }}
      >
        Получить информацию о ремонтах по марке транспорта
      </button>
      <Modal active={modalActive} setActive={setModalActive}>
        <BrandTransport
          brandId={params.brandId}
          setBrandId={(newBrandId) => {
            setParams({ ...params, brandId: newBrandId });
          }}
        />

        <div>Количество : {information.count}</div>
        <div>Общая стоимость : {information.price}</div>

        <div>
          <button onClick={update}>Обновить таблицу</button>
        </div>
      </Modal>
    </div>
  );
};

export default RepairInformationByBrand;
