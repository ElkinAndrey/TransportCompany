import { React, useEffect, useRef, useState } from "react";
import { useFetching } from "./../../hooks/useFetching";
import Transport from "./../../api/transport";

const TransportTable = () => {
  const dataFetchedRef = useRef(false);

  let [transports, setTransport] = useState([]);

  let [params, setParams] = useState({
    offset: 0,
    length: 10,
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

  useEffect(() => {
    if (dataFetchedRef.current) return;
    dataFetchedRef.current = true;
    fetchTransport(params);
  }, []);

  return (
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
              {transportError ? (
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
  );
};

export default TransportTable;
