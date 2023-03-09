import React, { useEffect, useRef, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { useFetching } from "./../../hooks/useFetching";
import Transport from "./../../api/transport";
import UniqueTransportCharacteristics from './../../views/UniqueTransportCharacteristics/UniqueTransportCharacteristics';
import PersonMiniTable from './../../views/Tables/PersonMiniTable/PersonMiniTable';

const TransportPage = () => {
  const dataFetchedRef = useRef(false);
  const params = useParams();
  let history = useNavigate();
  const [transport, setTransport] = useState({
    transportId: "",
    series: "",
    number: "",
    regionCode: "",
    start: "",
    end: "",
    mileage: "",
    category: "",
    countryCode: "",
    decipheringCountry: "",
    manufacturerCompany: "",
    transportModel: "",
    yearPublishing: "",
    brigade: null,
    drivers: [],
  });

  const [fetchTransport, isTransportLoading, transportError] = useFetching(
    async (id) => {
      const response = await Transport.getTransportById(id);
      setTransport(response.data);
    }
  );

  useEffect(() => {
    if (dataFetchedRef.current) return;
    dataFetchedRef.current = true;
    fetchTransport(params.id);
  }, []);

  const redirectBrigade = (brigadeId) => {
    history(`/brigade/${brigadeId}`);
  };

  console.log(transport);

  return (
    <div>
      <div>
        <h1>Общие характеристики</h1>
        <div>Уникальный Id : {transport.transportId}</div>
        <div>Категория транспорта : {transport.category}</div>
        <div>Пробег : {transport.mileage}</div>
        <h4>Государственный номер</h4>
        <div>Серия : {transport.series}</div>
        <div>Номер : {transport.number}</div>
        <div>Код региона : {transport.regionCode}</div>
        <div>
          Код страны : {transport.countryCode} ({transport.decipheringCountry})
        </div>
        <h4>Период эксплуатации</h4>
        <div>Начало : {transport.start}</div>
        <div>
          Окончание :{" "}
          {transport.end === null ? "Не вышел из эксплуатации" : transport.end}
        </div>
        <h4>Марка</h4>
        <div>Компания производитель : {transport.manufacturerCompany}</div>
        <div>Модель транспорта : {transport.transportModel}</div>
        <div>Год издания : {transport.yearPublishing}</div>
      </div>

      {transport.end === null && (
        <button
          onClick={() => {
            Transport.decommissionTransport({
              transportId: transport.transportId,
              decommissionTime: new Date(),
            });
          }}
        >
          Списать транспорт
        </button>
      )}

      <div>
        <h1>Бригада</h1>
        <table>
          <thead>
            <tr>
              <th>Уникальный Id</th>
              <th>Название</th>
              <th>ФИО бригадира</th>
            </tr>
          </thead>
          <tbody>
            <tr
              key={transport.brigade.brigadeId}
              className={"stringTable"}
              onClick={() => {
                redirectBrigade(transport.brigade.brigadeId);
              }}
            >
              <td>{transport.brigade.brigadeId}</td>
              <td>{transport.brigade.name}</td>
              <td>
                {transport.brigade.foreman.surname}{" "}
                {transport.brigade.foreman.name}{" "}
                {transport.brigade.foreman.patronymic}
              </td>
            </tr>
          </tbody>
        </table>
      </div>

      <PersonMiniTable persons={transport.drivers}/>

      {transport.hasOwnProperty("transportId") && (
        <div>
          <UniqueTransportCharacteristics transport={transport} />
        </div>
      )}
    </div>
  );
};

export default TransportPage;
