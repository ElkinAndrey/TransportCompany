import React, { useEffect } from "react";
import { useRef } from "react";
import { useState } from "react";
import { useParams } from "react-router-dom";
import Subordination from "./../../api/subordination";
import { useFetching } from "./../../hooks/useFetching";
import WorkshopTable from './../../views/Tables/WorkshopTable/WorkshopTable';
import PersonMiniTable from './../../views/Tables/PersonMiniTable/PersonMiniTable';

const RegionPage = () => {
  const dataFetchedRef = useRef(false);
  const params = useParams();
  let [region, setRegion] = useState({
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
  });
  let [count, setCount] = useState({
    regionCount: "",
    workshopCount: "",
    brigadeCount: "",
    personCount: "",
  });

  const [fetchRegion, isRegionLoading, regionError] = useFetching(
    async (regionId) => {
      const response = await Subordination.getRegion(regionId);
      setRegion(response.data);
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
    fetchRegion(params.regionId);
    fetchCount({ regionId: params.regionId });
  }, []);

  return (
    <div>
      <h1>Участок</h1>
      <div>Уникальный Id участка : {region.regionId}</div>
      <div>Название участка : {region.name}</div>

      <h2>Персонал на предприятии</h2>
      <div>Количество мастерских : {count.workshopCount}</div>
      <div>Количество бригад : {count.brigadeCount}</div>
      <div>Количество персонала : {count.personCount}</div>
      <div>
        Общее число человек :{" "}
        {1 + count.workshopCount + count.brigadeCount + count.personCount}
      </div>

      <h2>Начальник участка</h2>
      <PersonMiniTable persons={[region.regionChief]} />

      <h2>Мастерские</h2>
      <WorkshopTable workshops={region.workshops} />
    </div>
  );
};

export default RegionPage;
