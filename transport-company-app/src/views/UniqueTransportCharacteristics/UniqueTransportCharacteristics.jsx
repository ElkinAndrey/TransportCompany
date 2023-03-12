import React, { useEffect, useRef, useState } from "react";
import Transport from "./../../api/transport";
import { useFetching } from "./../../hooks/useFetching";
import { getDateForInput } from "./../../utils/getDateForInput";

const UniqueTransportCharacteristics = ({ transport }) => {
  const dataFetchedRef = useRef(false);
  const [paramsCargoTransportation, setParamsCargoTransportation] = useState({
    length: 100,
    transportId: transport.transportId,
    firstTransportation: null,
    lastTransportation: null,
  });
  const [cargoTransportations, setCargoTransportations] = useState([]);

  const [
    fetchCargoTransportation,
    isCargoTransportationLoading,
    cargoTransportationError,
  ] = useFetching(async (p) => {
    const response = await Transport.getCargoaTransportations(p);
    setCargoTransportations(response.data);
  });

  useEffect(() => {
    if (dataFetchedRef.current) return;
    dataFetchedRef.current = true;
    fetchCargoTransportation(paramsCargoTransportation);
  }, []);

  return (
    <div>
      <h1>Уникальные характеристики</h1>

      {transport.hasOwnProperty("numberSeats") ? (
        <div>Количество сидячих мест : {transport.numberSeats}</div>
      ) : (
        <div></div>
      )}

      {transport.hasOwnProperty("numberStandingPlaces") ? (
        <div>Количество стоячих мест : {transport.numberStandingPlaces}</div>
      ) : (
        <div></div>
      )}

      {transport.hasOwnProperty("numberPlacesForDisabled") ? (
        <div>
          Количество мест для инвалидов : {transport.numberPlacesForDisabled}
        </div>
      ) : (
        <div></div>
      )}

      {transport.hasOwnProperty("loadCapacity") ? (
        <div>Грузоподьемность : {transport.loadCapacity}</div>
      ) : (
        <div></div>
      )}

      {transport.hasOwnProperty("height") ? (
        <div>Высота : {transport.height}</div>
      ) : (
        <div></div>
      )}

      {transport.hasOwnProperty("cargoTransportations") ? (
        <div>
          <h4>
            Перевозки{" "}
            <button
              onClick={() =>
                fetchCargoTransportation(paramsCargoTransportation)
              }
            >
              Обновить перевозки
            </button>
          </h4>
          <div>
            <label>Начало</label>
            <input
              type={"date"}
              value={getDateForInput(
                paramsCargoTransportation.firstTransportation
              )}
              onChange={(e) => {
                setParamsCargoTransportation({
                  ...paramsCargoTransportation,
                  firstTransportation: new Date(e.target.value),
                });
              }}
            />
          </div>

          <div>
            <label>Конец</label>
            <input
              type={"date"}
              value={getDateForInput(
                paramsCargoTransportation.lastTransportation
              )}
              onChange={(e) => {
                setParamsCargoTransportation({
                  ...paramsCargoTransportation,
                  lastTransportation: new Date(e.target.value),
                });
              }}
            />
          </div>
          <button
            onClick={() => {
              setParamsCargoTransportation({
                ...paramsCargoTransportation,
                firstTransportation: null,
                lastTransportation: null,
              });
            }}
          >
            Сбросить
          </button>
          {cargoTransportations.map((cargoTransportation) => (
            <div
              key={cargoTransportation.cargoTransportationId}
              style={{ border: "3px black solid", marginBottom: "3px" }}
            >
              <div>
                Id перевозки : {cargoTransportation.cargoTransportationId}
              </div>
              <div>Цена : {cargoTransportation.price}</div>
              <div>
                Дополнительное описание
                {cargoTransportation.additionalInformation}
              </div>
              <div>
                Дата оформления : {cargoTransportation.startTransportation}
              </div>
              <div>
                Дата выполнения : {cargoTransportation.endTransportation}
              </div>
            </div>
          ))}
        </div>
      ) : (
        <div></div>
      )}

      {transport.hasOwnProperty("route") && (
        <div>
          <div>Номер маршрута : {transport.route.number}</div>
          <div>Маршрут : {transport.route.stops.join(" => ")}</div>
        </div>
      )}
    </div>
  );
};

export default UniqueTransportCharacteristics;
