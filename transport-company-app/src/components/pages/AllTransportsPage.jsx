import React, { useEffect, useRef, useState } from "react";
import { useFetching } from "./../../hooks/useFetching";
import Transport from "./../../api/transport";
import CellLink from "./../forms/CellLink/CellLink";

const AllTransportsPage = () => {
  const dataFetchedRef = useRef(false);

  let [transports, setTransports] = useState([]);

  const [fetchTransports, isTransportsLoading, transportsError] = useFetching(
    async () => {
      const response = await Transport.getDistributionDriversTransport();
      setTransports(response.data);
    }
  );

  useEffect(() => {
    if (dataFetchedRef.current) return;
    dataFetchedRef.current = true;
    fetchTransports();
  }, []);

  return (
    <div>
      <table>
        <thead>
          <tr>
            <th>Транспорт</th>
            <th>Водитель</th>
          </tr>
        </thead>
        <tbody>
          {transports.map((transport) => {
            return transport.drivers.map((driver, index) => (
              <tr>
                {index === 0 && (
                  <CellLink
                    to={`/transport/${transport.transportId}`}
                    rowspan={transport.drivers.length}
                  >
                    {`Id:${transport.transportId} Серия:${transport.series} Номер:${transport.number} Код региона:${transport.regionCode} Код страны:${transport.countryCode}`}
                  </CellLink>
                )}
                <CellLink to={`/person/${driver.personId}`}>
                  {`${driver.personId} | ${driver.name} ${driver.surname} ${driver.patronymic}`}
                </CellLink>
              </tr>
            ));
          })}
        </tbody>
      </table>
    </div>
  );
};

export default AllTransportsPage;
