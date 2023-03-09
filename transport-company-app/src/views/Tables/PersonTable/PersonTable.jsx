import React, { useEffect, useRef, useState } from "react";
import Person from "./../../../api/person";
import { getDateForInput } from "./../../../utils/getDateForInput";
import { useFetching } from "./../../../hooks/useFetching";
import TableLink from "./../../../components/forms/tableLink/TableLink";

const PersonTable = ({ page, setPage, setEnd, setPersonCount }) => {
  const len = 10;

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
    startHireDate: null,
    endHireDate: null,
    startDismissalDate: null,
    endDismissalDate: null,
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

  const [fetchPerson, isPersonLoading, personError] = useFetching(async (p) => {
    const response = await Person.getPersons(p);
    setPersons(response.data);
  });

  const [fetchPersonCount, isPersonCountLoading, personCountError] =
    useFetching(async (p) => {
      const response = await Person.getPersonCount(p);
      setPersonCount(response.data);
      setEnd(
        response.data === 0 ? 1 : Math.floor((response.data - 1) / len + 1)
      );
    });

  const [fetchPositions, isPositionsLoading, positionsError] = useFetching(
    async () => {
      const response = await Person.getPersonPositions();
      setPositions(response.data);
    }
  );

  useEffect(() => {
    fetchPerson({ ...oldParams, offset: (page - 1) * len, length: len });
    fetchPersonCount(oldParams);
  }, [page]);

  useEffect(() => {
    fetchPositions();
  }, []);

  const update = () => {
    setOldParams({ ...params });
    fetchPerson(params);
    fetchPersonCount(params);
    setPage(1);
  };

  return (
    <div>
      <div>
        <button onClick={update}>Обновить таблицу</button>
      </div>
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
          <tr>
            <th>
              <input
                value={params.surname}
                onChange={(e) =>
                  setParams({ ...params, surname: e.target.value })
                }
              />
            </th>
            <th>
              <input
                value={params.name}
                onChange={(e) => setParams({ ...params, name: e.target.value })}
              />
            </th>
            <th>
              <input
                value={params.patronymic}
                onChange={(e) =>
                  setParams({ ...params, patronymic: e.target.value })
                }
              />
            </th>
            <th>
              <select
                value={params.positionId}
                onChange={(e) =>
                  setParams({ ...params, positionId: e.target.value })
                }
              >
                <option value={0}>Всё</option>
                {positions.map((position) => (
                  <option key={position[0]} value={position[0]}>
                    {position[1]}
                  </option>
                ))}
              </select>
            </th>
            <th>
              <div>
                <label>Начало</label>
                <input
                  type={"date"}
                  value={getDateForInput(params.startHireDate)}
                  onChange={(e) => {
                    setParams({
                      ...params,
                      startHireDate: new Date(e.target.value),
                    });
                  }}
                />
              </div>

              <div>
                <label>Конец</label>
                <input
                  type={"date"}
                  value={getDateForInput(params.endHireDate)}
                  onChange={(e) => {
                    setParams({
                      ...params,
                      endHireDate: new Date(e.target.value),
                    });
                  }}
                />
              </div>
              <button
                onClick={() =>
                  setParams({
                    ...params,
                    startHireDate: null,
                    endHireDate: null,
                  })
                }
              >
                Сбросить
              </button>
            </th>
            <th>
              <div>
                <label>Начало</label>
                <input
                  type={"date"}
                  value={getDateForInput(params.startDismissalDate)}
                  onChange={(e) => {
                    setParams({
                      ...params,
                      startDismissalDate: new Date(e.target.value),
                    });
                  }}
                />
              </div>
              <div>
                <label>Конец</label>
                <input
                  type={"date"}
                  value={getDateForInput(params.endDismissalDate)}
                  onChange={(e) => {
                    setParams({
                      ...params,
                      endDismissalDate: new Date(e.target.value),
                    });
                  }}
                />
              </div>
              <button
                onClick={() =>
                  setParams({
                    ...params,
                    startDismissalDate: null,
                    endDismissalDate: null,
                  })
                }
              >
                Сбросить
              </button>
            </th>
          </tr>
        </thead>
        {!personError.message && !isPersonLoading && persons.length !== 0 ? (
          <tbody>
            {persons.map((person) => (
              <tr key={person.personId} style={{ position: "relative" }}>
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
                <TableLink to={`/person/${person.personId}`} />
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
