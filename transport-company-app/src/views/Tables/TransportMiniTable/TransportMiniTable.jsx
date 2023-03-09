import React from "react";
import TableLink from "./../../../components/forms/tableLink/TableLink";

const TransportMiniTable = ({ transports }) => {
  return (
    <table>
      <thead>
        <tr>
          <th>Уникальный Id</th>
          <th>Категория</th>
          <th>Серия</th>
          <th>Номер</th>
          <th>Код региона</th>
          <th>Код страны</th>
          <th>Пробег (км)</th>
          <th>Компания производитель</th>
          <th>Модель</th>
          <th>Год издания</th>
        </tr>
      </thead>
      <tbody>
        {transports.map((transport) => (
          <tr
            key={transport.transportId}
            className={"stringTable"}
            style={{ position: "relative" }}
          >
            <td>{transport.transportId}</td>
            <td>{transport.category}</td>
            <td>{transport.series}</td>
            <td>{transport.number}</td>
            <td>{transport.regionCode}</td>
            <td>{transport.countryCode}</td>
            <td>{transport.mileage}</td>
            <td>{transport.manufacturerCompany}</td>
            <td>{transport.transportModel}</td>
            <td>{transport.yearPublishing}</td>
            <TableLink to={`/transport/${transport.transportId}`} />
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default TransportMiniTable;
