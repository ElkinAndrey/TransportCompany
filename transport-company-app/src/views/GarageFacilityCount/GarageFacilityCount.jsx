import React, { useEffect, useState } from "react";
import Modal from "./../../components/forms/modal/Modal";
import Transport from "./../../api/transport";
import { useFetching } from "./../../hooks/useFetching";

const GarageFacilityCount = ({ categoryId }) => {
  let [modalActive, setModalActive] = useState(false);
  let [count, setCount] = useState({});
  const [fetchCount, isCountLoading, countError] = useFetching(
    async (categoryId) => {
      const response = await Transport.getGarageFacilityCountByCategoryId(
        categoryId
      );
      setCount(response.data);
    }
  );

  return (
    <div>
      <button
        onClick={() => {
          setModalActive(true);
          fetchCount(categoryId);
        }}
      >
        Посмотреть количество объектов гаражного хозяйства
      </button>
      <Modal active={modalActive} setActive={setModalActive}>
        {Object.entries(count).map((keyvalue) => (
          <div key={keyvalue[0]}>
            {keyvalue[0]} : {keyvalue[1]}
          </div>
        ))}
      </Modal>
    </div>
  );
};

export default GarageFacilityCount;
