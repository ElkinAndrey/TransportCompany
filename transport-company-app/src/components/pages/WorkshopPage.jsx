import React, { useEffect, useReducer } from "react";
import { useState } from "react";
import { useParams } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import Subordination from "./../../api/subordination";
import { useFetching } from "./../../hooks/useFetching";
import TableLink from "./../forms/tableLink/TableLink";

const WorkshopPage = () => {
  const dataFetchedRef = useReducer(false);
  const params = useParams();
  let history = useNavigate();
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
      <table>
        <thead>
          <tr>
            <th>Уникальный Id</th>
            <th>Название</th>
            <th>ФИО начальника</th>
          </tr>
        </thead>
        <tbody>
          <tr
            key={workshop.region.regionId}
            className={"stringTable"}
            style={{ position: "relative" }}
          >
            <td>{workshop.region.regionId}</td>
            <td>{workshop.region.name}</td>
            <td>
              {workshop.region.regionChief.surname}{" "}
              {workshop.region.regionChief.name}{" "}
              {workshop.region.regionChief.patronymic}
            </td>
            <TableLink to={`/region/${workshop.region.regionId}`} />
          </tr>
        </tbody>
      </table>

      <h2>Мастер</h2>
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
            <td>{workshop.master.personId}</td>
            <td>{workshop.master.name}</td>
            <td>{workshop.master.surname}</td>
            <td>{workshop.master.patronymic}</td>
            <td>{workshop.master.hireDate}</td>
            <td>
              {workshop.master.dismissalDate === null
                ? "Не уволен"
                : workshop.master.dismissalDate}
            </td>
            <TableLink to={`/person/${workshop.master.personId}`} />
          </tr>
        </tbody>
      </table>

      <h2>Объект гражданского хозяйства</h2>
      <table>
        <thead>
          <tr>
            <th>Уникальный Id</th>
            <th>Адрес</th>
            <th>Категория</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>{workshop.garageFacility.garageFacilityId}</td>
            <td>{workshop.garageFacility.address}</td>
            <td>{workshop.garageFacility.category}</td>
          </tr>
        </tbody>
      </table>

      <h2>Бригады</h2>
      <table>
        <thead>
          <tr>
            <th>Уникальный Id</th>
            <th>Название</th>
            <th>ФИО бригадира</th>
          </tr>
        </thead>
        <tbody>
          {workshop.brigades.map((brigade) => (
            <tr
              key={brigade.brigadeId}
              className={"stringTable"}
              style={{ position: "relative" }}
            >
              <td>{brigade.brigadeId}</td>
              <td>{brigade.name}</td>
              <td>
                {brigade.foreman.surname} {brigade.foreman.name}{" "}
                {brigade.foreman.patronymic}
              </td>
              <TableLink to={`/brigade/${brigade.brigadeId}`} />
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default WorkshopPage;
