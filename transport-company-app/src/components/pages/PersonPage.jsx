import React, { useEffect, useRef, useState } from "react";
import { useParams } from "react-router-dom";
import { useFetching } from "./../../hooks/useFetching";
import Person from "./../../api/person";
import TableLink from "./../forms/tableLink/TableLink";
import TransportMiniTable from "./../../views/Tables/TransportMiniTable/TransportMiniTable";

const PersonPage = () => {
  const dataFetchedRef = useRef(false);
  const params = useParams();
  const [person, setPerson] = useState({});

  const [fetchPerson, isPersonLoading, personError] = useFetching(
    async (id) => {
      const response = await Person.getPersonById(id);
      setPerson(response.data);
    }
  );

  useEffect(() => {
    if (dataFetchedRef.current) return;
    dataFetchedRef.current = true;
    fetchPerson(params.personId);
  }, []);

  return (
    <div>
      <h1>Общие характеристики</h1>
      <div>Уникальный Id : {person.personId}</div>
      <div>Должность : {person.personPosition}</div>
      <h4>ФИО</h4>
      <div>Имя : {person.name}</div>
      <div>Фамилия : {person.surname}</div>
      <div>Отчеств : {person.patronymic}</div>
      <h4>Период работы</h4>
      <div>Дата принятия на работу : {person.hireDate}</div>
      <div>
        Дата увольнения :{" "}
        {person.dismissalDate === null ? "Не уволен" : person.dismissalDate}
      </div>

      <h1>Уникальные характеристики</h1>
      {person.hasOwnProperty("licenseNumber") && (
        <div>Номер водительских прав : {person.licenseNumber}</div>
      )}
      {person.hasOwnProperty("dateIssueLicense") && (
        <div>Дата выдачи водительских прав : {person.dateIssueLicense}</div>
      )}

      {person.hasOwnProperty("transports") && (
        <div>
          <h1>Транспорт</h1>
          <TransportMiniTable transports={person.transports} />
        </div>
      )}

      {person.hasOwnProperty("brigade") && (
        <div>
          <h1>Бригада</h1>
          <table>
            <thead>
              <tr>
                <th>Уникальный ID</th>
                <th>Название бригады</th>
              </tr>
            </thead>
            <tbody>
              <tr className={"stringTable"} style={{ position: "relative" }}>
                <td>{person.brigade.brigadeId}</td>
                <td>{person.brigade.name}</td>
                <TableLink to={`/brigade/${person.brigade.brigadeId}`} />
              </tr>
            </tbody>
          </table>
        </div>
      )}

      {person.hasOwnProperty("workshop") && (
        <div>
          <h1>Мастерская</h1>
          <table>
            <thead>
              <tr>
                <th>Уникальный ID</th>
                <th>Название мастерской</th>
              </tr>
            </thead>
            <tbody>
              <tr className={"stringTable"} style={{ position: "relative" }}>
                <td>{person.workshop.workshopId}</td>
                <td>{person.workshop.name}</td>
                <TableLink to={`/workshop/${person.workshop.workshopId}`} />
              </tr>
            </tbody>
          </table>
        </div>
      )}

      {person.hasOwnProperty("region") && (
        <div>
          <h1>Участок</h1>
          <table>
            <thead>
              <tr>
                <th>Уникальный ID</th>
                <th>Название участка</th>
              </tr>
            </thead>
            <tbody>
              <tr className={"stringTable"} style={{ position: "relative" }}>
                <td>{person.region.regionId}</td>
                <td>{person.region.name}</td>
                <TableLink to={`/region/${person.region.regionId}`} />
              </tr>
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
};

export default PersonPage;
