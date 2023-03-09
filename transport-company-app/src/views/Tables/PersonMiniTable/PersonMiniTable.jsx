import React from "react";
import TableLink from "./../../../components/forms/tableLink/TableLink";

const PersonMiniTable = ({ persons }) => {
  return (
    <table>
      <thead>
        <tr>
          <th>Уникальный Id</th>
          <th>Имя</th>
          <th>Фамилия</th>
          <th>Отчество</th>
          <th>Должность</th>
          <th>Дата приема на работу</th>
          <th>Дата увольнения</th>
        </tr>
      </thead>
      <tbody>
        {persons.map((person) => (
          <tr
            key={person.personId}
            className={"stringTable"}
            style={{ position: "relative" }}
          >
            <td>{person.personId}</td>
            <td>{person.name}</td>
            <td>{person.surname}</td>
            <td>{person.patronymic}</td>
            <td>{person.personPosition}</td>
            <td>{person.hireDate}</td>
            <td>
              {person.dismissalDate === null
                ? "Не уволен"
                : person.dismissalDate}
            </td>
            <TableLink to={`/person/${person.personId}`} />
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default PersonMiniTable;
