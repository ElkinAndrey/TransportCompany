import { React, useEffect, useRef, useState } from "react";
import Transport from "./../../../api/transport";
import { getDateForInput } from './../../../utils/getDateForInput';
import { useFetching } from './../../../hooks/useFetching';

const TransportTable = ({ page, setPage, setEnd, setTransportCount }) => {
  const len = 10;
  let [transports, setTransport] = useState([]);
  let [categories, setCategories] = useState([]);
  let [countries, setCountries] = useState([]);

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

  const [fetchTransport, isTransportLoading, transportError] = useFetching(
    async (p) => {
      const response = await Transport.getTransports(p);
      setTransport(response.data);
    }
  );

  const [fetchTransportCount, isTransportCountLoading, transportCountError] =
    useFetching(async (p) => {
      const response = await Transport.getTransportCount(p);
      setTransportCount(response.data);
      setEnd(response.data === 0 ? 1 : Math.floor((response.data - 1) / len + 1));
    });

  const [fetchCategories, isCategoriesLoading, categoriesError] = useFetching(
    async () => {
      const response = await Transport.getTransportCategories();
      setCategories(response.data);
    }
  );

  const [fetchCountries, isCountriesLoading, countriesError] = useFetching(
    async () => {
      const response = await Transport.getTransportCountries();
      setCountries(response.data);
    }
  );

  useEffect(() => {
    fetchTransport({ ...oldParams, offset: (page - 1) * len, length: len });
    fetchTransportCount(oldParams);
  }, [page]);

  useEffect(() => {
    fetchCategories();
    fetchCountries();
  }, []);

  const update = () => {
    setOldParams({ ...params });
    fetchTransport(params);
    fetchTransportCount(params);
    setPage(1)
  };

  return (
    <div>
      <div>
        <button onClick={update}>Обновить таблицу</button>
      </div>
      <table>
        <thead>
          <tr>
            <th>Категория</th>
            <th>Серия</th>
            <th>Номер</th>
            <th>Код региона</th>
            <th>Код страны</th>
            <th>Старана</th>
            <th>Дата покупки</th>
            <th>Дата продажи</th>
            <th>Пробег (км)</th>
            <th>Компания производитель</th>
            <th>Модель</th>
            <th>Год издания</th>
            <th></th>
          </tr>
          <tr>
            <th>
              <select
                value={params.categoryId}
                onChange={(e) =>
                  setParams({ ...params, transportCategoryId: e.target.value })
                }
              >
                <option value={0}>Всё</option>
                {categories.map((category) => (
                  <option key={category[0]} value={category[0]}>
                    {category[1]}
                  </option>
                ))}
              </select>
            </th>
            <th>
              <input
                value={params.series}
                onChange={(e) =>
                  setParams({ ...params, series: e.target.value })
                }
              />
            </th>
            <th>
              <input
                value={params.number}
                onChange={(e) =>
                  setParams({ ...params, number: e.target.value })
                }
              />
            </th>
            <th>
              <input
                value={params.regionCode}
                onChange={(e) =>
                  setParams({ ...params, regionCode: e.target.value })
                }
              />
            </th>
            <th colSpan="2">
              <select
                value={params.countryId}
                onChange={(e) =>
                  setParams({ ...params, transportCountryId: e.target.value })
                }
              >
                <option value={0}>Всё</option>
                {countries.map((country) => (
                  <option key={country[0]} value={country[0]}>
                    {`${country[1]} (${country[2]})`}
                  </option>
                ))}
              </select>
            </th>
            <th>
              <div>
                <label>Начало</label>
                <input
                  type={"date"}
                  value={getDateForInput(params.startBuy)}
                  onChange={(e) => {
                    setParams({
                      ...params,
                      startBuy: new Date(e.target.value),
                    });
                  }}
                />
              </div>

              <div>
                <label>Конец</label>
                <input
                  type={"date"}
                  value={getDateForInput(params.endBuy)}
                  onChange={(e) => {
                    setParams({ ...params, endBuy: new Date(e.target.value) });
                  }}
                />
              </div>
              <button
                onClick={() =>
                  setParams({ ...params, startBuy: null, endBuy: null })
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
                  value={getDateForInput(params.startWriteOff)}
                  onChange={(e) => {
                    setParams({
                      ...params,
                      startWriteOff: new Date(e.target.value),
                    });
                  }}
                />
              </div>
              <div>
                <label>Конец</label>
                <input
                  type={"date"}
                  value={getDateForInput(params.endWriteOff)}
                  onChange={(e) => {
                    setParams({
                      ...params,
                      endWriteOff: new Date(e.target.value),
                    });
                  }}
                />
              </div>
              <button
                onClick={() =>
                  setParams({
                    ...params,
                    startWriteOff: null,
                    endWriteOff: null,
                  })
                }
              >
                Сбросить
              </button>
            </th>
            <th></th>
            <th></th>
            <th></th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        {!transportError.message &&
        !isTransportLoading &&
        transports.length !== 0 ? (
          <tbody>
            {transports.map((t) => (
              <tr key={t.transportId}>
                <td>{t.category}</td>
                <td>{t.series}</td>
                <td>{t.number}</td>
                <td>{t.regionCode}</td>
                <td>{t.countryCode}</td>
                <td>{t.decipheringCountry}</td>
                <td>{t.start}</td>
                <td>{t.end === null ? "Не продан" : t.end}</td>
                <td>{t.mileage}</td>
                <td>{t.manufacturerCompany}</td>
                <td>{t.transportModel}</td>
                <td>{t.yearPublishing}</td>
              </tr>
            ))}
          </tbody>
        ) : (
          <tbody>
            <tr>
              <td colSpan="99999">
                {/* Ошибка */}
                {transportError.message ? (
                  <div>Ошибка</div>
                ) : (
                  <div>
                    {/* Загрузка */}
                    {isTransportLoading ? (
                      <div>Загрузка...</div>
                    ) : (
                      <div>
                        {/* Пустые данные */}
                        {transports.length === 0 ? (
                          <div>Нет транспорта</div>
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

export default TransportTable;
