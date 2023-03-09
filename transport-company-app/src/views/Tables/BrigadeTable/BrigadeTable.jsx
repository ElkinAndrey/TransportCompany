import React from "react";
import TableLink from './../../../components/forms/tableLink/TableLink';

const BrigadeTable = ({ brigades }) => {
  return (
    <table>
      <thead>
        <tr>
          <th>Уникальный Id</th>
          <th>Название</th>
          <th>ФИО бригадира</th>
        </tr>
      </thead>
      <tbody>
        {brigades.map((brigade) => (
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
  );
};

export default BrigadeTable;
