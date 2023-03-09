import React, { useEffect } from "react";
import { useRef } from "react";
import { useState } from "react";
import { useParams } from "react-router-dom";
import Subordination from "./../../api/subordination";
import { useFetching } from "./../../hooks/useFetching";
import { Link } from "react-router-dom";
import TableLink from "./../forms/tableLink/TableLink";

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
      <table>
        <thead>
          <tr>
            <th>Уникальный Id</th>
            <th>Имя</th>
            <th>Фамилия</th>
            <th>Отчество</th>
            <th>Дата приема на работу</th>
            <th>Дата увольнения</th>
          </tr>
        </thead>
        <tbody>
          <tr className={"stringTable"} style={{ position: "relative" }}>
            <td>{region.regionChief.personId}</td>
            <td>{region.regionChief.name}</td>
            <td>{region.regionChief.surname}</td>
            <td>{region.regionChief.patronymic}</td>
            <td>{region.regionChief.hireDate}</td>
            <td>
              {region.regionChief.dismissalDate === null
                ? "Не уволен"
                : region.regionChief.dismissalDate}
            </td>
            <TableLink to={`/person/${region.regionChief.personId}`} />
          </tr>
        </tbody>
      </table>

      <h2>Мастерские</h2>
      <table>
        <thead>
          <tr>
            <th>Уникальный Id</th>
            <th>Название</th>
            <th>ФИО мастера</th>
            <th>Адрес</th>
            <th>Категория</th>
          </tr>
        </thead>
        <tbody>
          {region.workshops.map((workshop) => (
            <tr key={workshop.workshopId} style={{ position: "relative" }}>
              <td>{workshop.workshopId}</td>
              <td>{workshop.name}</td>
              <td>
                {workshop.master.surname} {workshop.master.name}{" "}
                {workshop.master.patronymic}
              </td>
              <td>{workshop.garageFacility.address}</td>
              <td>{workshop.garageFacility.category}</td>
              <TableLink to={`/workshop/${workshop.workshopId}`} />
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default RegionPage;
