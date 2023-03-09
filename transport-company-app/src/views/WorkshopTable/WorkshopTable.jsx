import React from "react";
import TableLink from './../../components/forms/tableLink/TableLink';

const WorkshopTable = ({ workshops }) => {
  return (
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
        {workshops.map((workshop) => (
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
  );
};

export default WorkshopTable;
