import React from "react";

const GarageFacility = ({garageFacility}) => {
  return (
    <table>
      <thead>
        <tr>
          <th>Уникальный Id</th>
          <th>Адрес</th>
          <th>Категория</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>{garageFacility.garageFacilityId}</td>
          <td>{garageFacility.address}</td>
          <td>{garageFacility.category}</td>
        </tr>
      </tbody>
    </table>
  );
};

export default GarageFacility;
