import React, { useEffect, useReducer } from "react";
import { useState } from "react";
import { useParams } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import { useFetching } from "./../../hooks/useFetching";
import Subordination from "./../../api/subordination";
import TableLink from "./../forms/tableLink/TableLink";
import WorkshopTable from "./../../views/WorkshopTable/WorkshopTable";
import PersonMiniTable from "./../../views/PersonMiniTable/PersonMiniTable";

const BrigadePage = () => {
  const dataFetchedRef = useReducer(false);
  const params = useParams();
  let history = useNavigate();
  let [brigade, setBrigade] = useState({
    brigadeId: "",
    name: "",
    foreman: {
      personId: "",
      name: "",
      surname: "",
      patronymic: "",
      hireDate: "",
      dismissalDate: "",
    },
    workshop: {
      workshopId: "",
      name: "",
      master: {
        personId: "",
        name: "",
        surname: "",
        patronymic: "",
        hireDate: "",
        dismissalDate: "",
      },
      garageFacility: {
        garageFacilityId: "",
        street: "",
        house: "",
        category: "",
      },
    },
    serviceStaffs: [],
  });
  let [count, setCount] = useState({
    regionCount: "",
    workshopCount: "",
    brigadeCount: "",
    personCount: "",
  });

  const [fetchBrigade, isBrigadeLoading, brigadeError] = useFetching(
    async (brigadeId) => {
      const response = await Subordination.getBrigade(brigadeId);
      setBrigade(response.data);
    }
  );

  const [fetchCount, isCountLoading, countError] = useFetching(
    async (params) => {
      const response = await Subordination.getSubordinationCount(params);
      setCount(response.data);
    }
  );

  useEffect(() => {
    if (dataFetchedRef.current) return;
    dataFetchedRef.current = true;
    fetchBrigade(params.brigadeId);
    fetchCount({ brigadeId: params.brigadeId });
  }, []);

  const redirectPerson = (personId) => {
    history(`/person/${personId}`);
  };

  const redirectWorkshop = (workshopId) => {
    history(`/workshop/${workshopId}`);
  };

  return (
    <div>
      <h1>Бригада</h1>
      <div>Уникальный Id бригады : {brigade.brigadeId}</div>
      <div>Название бригады : {brigade.name}</div>
      <h2>Персонал на предприятии</h2>
      <div>Количество персонала : {count.personCount}</div>
      <div>
        Общее число человек : {1 + count.brigadeCount + count.personCount}
      </div>
      
      <h2>Мастерская</h2>
      <WorkshopTable workshops={[brigade.workshop]} />

      <h2>Начальник бригады</h2>
      <PersonMiniTable persons={[brigade.foreman]} />

      <h2>Работники</h2>
      <PersonMiniTable persons={brigade.serviceStaffs} />
    </div>
  );
};

export default BrigadePage;
