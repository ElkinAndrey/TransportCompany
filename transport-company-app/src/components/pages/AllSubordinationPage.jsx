import React, { useEffect, useRef, useState } from "react";
import { useFetching } from "./../../hooks/useFetching";
import Subordination from "./../../api/subordination";
import CellLink from "./../forms/CellLink/CellLink";

const AllSubordinationPage = () => {
  const dataFetchedRef = useRef(false);

  let [regions, setRegions] = useState([]);

  const [fetchRegions, isRegionsLoading, regionsError] = useFetching(
    async () => {
      const response = await Subordination.getAllSubjugation();
      setRegions(response.data);
    }
  );

  useEffect(() => {
    if (dataFetchedRef.current) return;
    dataFetchedRef.current = true;
    fetchRegions();
  }, []);
  return (
    <div>
      <table>
        <thead>
          <tr>
            <th>Участок</th>
            <th>Мастерска</th>
            <th>Бригада</th>
            <th>Персонал</th>
          </tr>
        </thead>
        <tbody>
          {regions.map((region) => {
            return region.workshops.map((workshop, workshopIndex) => {
              return workshop.brigades.map((brigade, brigadeIndex) => {
                console.log(brigade);
                return brigade.serviceStaffs.map(
                  (serviceStaff, serviceStaffIndex) => (
                    <tr>
                      {workshopIndex === 0 &&
                        brigadeIndex === 0 &&
                        serviceStaffIndex === 0 && (
                          <CellLink
                            to={`/region/${region.regionId}`}
                            rowspan={region.workshops.reduce(
                              (accumulator, workshop) =>
                                accumulator +
                                workshop.brigades.reduce(
                                  (accumulator, brigade) =>
                                    accumulator + brigade.serviceStaffs.length,
                                  0
                                ),
                              0
                            )}
                          >
                            {`${region.regionId} ${region.name}`}
                          </CellLink>
                        )}

                      {brigadeIndex === 0 && serviceStaffIndex === 0 && (
                        <CellLink
                          to={`/workshop/${workshop.workshopId}`}
                          rowspan={workshop.brigades.reduce(
                            (accumulator, brigade) =>
                              accumulator + brigade.serviceStaffs.length,
                            0
                          )}
                        >
                          {`${workshop.workshopId} ${workshop.name}`}
                        </CellLink>
                      )}

                      {serviceStaffIndex === 0 && (
                        <CellLink
                          to={`/brigade/${brigade.brigadeId}`}
                          rowspan={brigade.serviceStaffs.length}
                        >
                          {`${brigade.brigadeId} ${brigade.name}`}
                        </CellLink>
                      )}

                      <CellLink to={`/person/${serviceStaff.personId}`}>
                        {`${serviceStaff.personId} ${serviceStaff.name} ${serviceStaff.surname} ${serviceStaff.patronymic}`}
                      </CellLink>
                    </tr>
                  )
                );
              });
            });
          })}
        </tbody>
      </table>
    </div>
  );
};

export default AllSubordinationPage;
