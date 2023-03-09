import React, { useEffect, useRef, useState } from "react";
import { useFetching } from "./../../hooks/useFetching";
import Subordination from "./../../api/subordination";
import { Link } from "react-router-dom";
import TableLink from "../forms/tableLink/TableLink";

const RegionsPage = () => {
  const dataFetchedRef = useRef(false);
  let [regions, setRegions] = useState([]);
  let [count, setCount] = useState({
    regionCount: "",
    workshopCount: "",
    brigadeCount: "",
    personCount: "",
  });

  const [fetchRegions, isRegionsLoading, regionsError] = useFetching(
    async () => {
      const response = await Subordination.getRegions();
      setRegions(response.data);
    }
  );

  const [fetchCount, isCountLoading, countError] = useFetching(async () => {
    const response = await Subordination.getSubordinationCount({});
    setCount(response.data);
  });

  useEffect(() => {
    if (dataFetchedRef.current) return;
    dataFetchedRef.current = true;
    fetchRegions();
    fetchCount();
  }, []);

  return (
    <div>
      <h1>Персонал на предприятии</h1>
      <div>Количество участков : {count.regionCount}</div>
      <div>Количество мастерских : {count.workshopCount}</div>
      <div>Количество бригад : {count.brigadeCount}</div>
      <div>Количество обслуживающего персонала : {count.personCount}</div>
      <div>
        Общее число человек :{" "}
        {count.regionCount +
          count.workshopCount +
          count.brigadeCount +
          count.personCount}
      </div>

      <h1>Участки</h1>
      <table>
        <thead>
          <tr>
            <th>Уникальный Id</th>
            <th>Название</th>
            <th>ФИО начальника</th>
          </tr>
        </thead>
        <tbody>
          {regions.map((region) => (
            <tr
              key={region.regionId}
              className={"stringTable"}
              style={{ position: "relative" }}
            >
              <td>{region.regionId}</td>
              <td>{region.name}</td>
              <td>
                {region.regionChief.surname} {region.regionChief.name}{" "}
                {region.regionChief.patronymic}
              </td>
              <TableLink to={`/region/${region.regionId}`} />
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default RegionsPage;
