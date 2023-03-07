import React, { useEffect, useRef, useState } from "react";
import { useFetching } from "./../../hooks/useFetching";
import Person from "./../../api/person";

const PersonTable = ({ page, setPage, setEnd, setPersonCount }) => {
  const len = 3;

  let [positions, setPositions] = useState([]);
  let [persons, setPersons] = useState([]);
  let [params, setParams] = useState({
    offset: (page - 1) * len,
    length: len,
    series: "",
    number: "",
    regionCode: "",
    transportCountryId: 0,
    transportCategoryId: 0,
    startBuy: null,
    endBuy: null,
    startWriteOff: null,
    endWriteOff: null,
  });
  let [oldParams, setOldParams] = useState({
    offset: (page - 1) * len,
    length: len,
    series: "",
    number: "",
    regionCode: "",
    transportCountryId: 0,
    transportCategoryId: 0,
    startBuy: null,
    endBuy: null,
    startWriteOff: null,
    endWriteOff: null,
  });

  const [fetchPerson, isPersonLoading, personError] = useFetching(
    async (p) => {
      const response = await Person.getPersons(p);
      setPersons(response.data);
    }
  );

  const [fetchPersonCount, isPersonCountLoading, personCountError] =
    useFetching(async (p) => {
      const response = await Person.getPersonCount(p);
      setPersonCount(response.data);
      setEnd(
        response.data === 0 ? 1 : Math.floor((response.data - 1) / len + 1)
      );
    });

  const [fetchCategories, isCategoriesLoading, categoriesError] = useFetching(
    async () => {
      const response = await Person.getPersontCategories();
      setPositions(response.data);
    }
  );

  useEffect(() => {
    fetchPerson({ ...oldParams, offset: (page - 1) * len, length: len });
    fetchPersonCount(oldParams);
  }, [page]);

  useEffect(() => {
    fetchCategories();
  }, []);

  return (
    <div>
      <table>
        <thead>
          <tr>
            <th>Фамилия</th>
            <th>Имя</th>
            <th>Отчество</th>
            <th>Должность</th>
            <th>Дата приема на работу</th>
            <th>Дата увольнения</th>
          </tr>
        </thead>
        {!personError.message && !isPersonLoading && persons.length !== 0 ? (
          <tbody>
            {persons.map((person) => (
              <tr key={person.personId}>
                <td>{person.surname}</td>
                <td>{person.name}</td>
                <td>{person.patronymic}</td>
                <td>{person.personPosition}</td>
                <td>{person.hireDate}</td>
                <td>
                  {person.dismissalDate === null
                    ? "Не уволен"
                    : person.dismissalDate}
                </td>
              </tr>
            ))}
          </tbody>
        ) : (
          <tbody>
            <tr>
              <td colSpan="99999">
                {/* Ошибка */}
                {personError ? (
                  <div>Ошибка</div>
                ) : (
                  <div>
                    {/* Загрузка */}
                    {isPersonLoading ? (
                      <div>Загрузка...</div>
                    ) : (
                      <div>
                        {/* Пустые данные */}
                        {persons.length === 0 ? (
                          <div>Нет людей</div>
                        ) : (
                          <div></div>
                        )}
                      </div>
                    )}
                  </div>
                )}
              </td>
            </tr>
          </tbody>
        )}
      </table>
    </div>
  );
};

export default PersonTable;
