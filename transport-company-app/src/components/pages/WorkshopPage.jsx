import React, { useEffect, useReducer } from "react";
import { useState } from "react";
import { useParams } from "react-router-dom";
import Subordination from "./../../api/subordination";
import { useFetching } from "./../../hooks/useFetching";
import BrigadeTable from "./../../views/BrigadeTable/BrigadeTable";
import RegionTable from "./../../views/RegionTable/RegionTable";
import PersonMiniTable from "./../../views/PersonMiniTable/PersonMiniTable";
import GarageFacility from "./../../views/GarageFacility/GarageFacility";

const WorkshopPage = () => {
  const dataFetchedRef = useReducer(false);
  const params = useParams();
  let [workshop, setWorkshop] = useState({
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
    region: {
      regionId: "",
      name: "",
      regionChief: {
        personId: "",
        name: "",
        surname: "",
        patronymic: "",
        hireDate: "",
        dismissalDate: "",
      },
      workshops: [],
    },
    brigades: [],
  });
  let [count, setCount] = useState({
    regionCount: "",
    workshopCount: "",
    brigadeCount: "",
    personCount: "",
  });

  const [fetchWorkshop, isWorkshopLoading, workshopError] = useFetching(
    async (workshopId) => {
      const response = await Subordination.getWorkshop(workshopId);
      setWorkshop(response.data);
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
    fetchWorkshop(params.workshopId);
    fetchCount({ workshopId: params.workshopId });
  }, []);

  return (
    <div>
      <h1>Мастерская</h1>
      <div>Уникальный Id мастерской : {workshop.workshopId}</div>
      <div>Название мастерской : {workshop.name}</div>

      <h2>Персонал на предприятии</h2>
      <div>Количество бригад : {count.brigadeCount}</div>
      <div>Количество персонала : {count.personCount}</div>
      <div>
        Общее число человек : {1 + count.brigadeCount + count.personCount}
      </div>

      <h2>Участок</h2>
      <RegionTable regions={[workshop.region]} />

      <h2>Мастер</h2>
      <PersonMiniTable persons={[workshop.master]} />

      <h2>Объект гражданского хозяйства</h2>
      <GarageFacility garageFacility={workshop.garageFacility} />

      <h2>Бригады</h2>
      <BrigadeTable brigades={workshop.brigades} />
    </div>
  );
};

export default WorkshopPage;
