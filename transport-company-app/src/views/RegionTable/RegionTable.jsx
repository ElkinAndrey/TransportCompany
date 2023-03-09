import React from "react";
import TableLink from "./../../components/forms/tableLink/TableLink";

const RegionTable = ({ regions }) => {
  return (
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
  );
};

export default RegionTable;
