import React, { useEffect, useRef, useState } from "react";
import Transport from "./../../api/transport";
import { useFetching } from "./../../hooks/useFetching";

const BrandTransport = ({ brandId, setBrandId }) => {
  const dataFetchedRef = useRef(false);

  let [brandSettings, setBrandSettings] = useState({
    company: {
      id: 0,
      name: "",
    },
    model: {
      id: 0,
      name: "",
    },
    year: "",
  });
  let [brandData, setBrandData] = useState({
    companies: [],
    models: [],
    years: [],
  });

  const [fetchCompanies, isCompaniesLoading, companiesError] = useFetching(
    async () => {
      const response = await Transport.getTransportCompanies();
      setBrandData({ ...brandData, companies: response.data });
    }
  );

  const [fetchModels, isModelsLoading, modelsError] = useFetching(
    async (company) => {
      const response = await Transport.getTransportModels(company);
      setBrandData({ ...brandData, models: response.data });
    }
  );

  const [fetchYears, isYearsLoading, yearsError] = useFetching(
    async (model) => {
      const response = await Transport.getTransportYears(model);

      setBrandData({ ...brandData, years: response.data });
    }
  );

  useEffect(() => {
    if (dataFetchedRef.current) return;
    dataFetchedRef.current = true;
    fetchCompanies();
  }, []);

  return (
    <div>
      <div
        style={{ fontWeight: "bold" }}
      >{`Марка транспорта : ${brandSettings.company.name} ${brandSettings.model.name} ${brandSettings.year}`}</div>

      <div>
        <label>Компания производитель</label>
        <select
          value={brandSettings.company.id}
          onChange={(e) => {
            setBrandId(0);
            fetchModels(e.target.value);
            setBrandSettings({
              ...brandSettings,
              model: { id: 0, name: "" },
              year: "",
              company: {
                id: e.target.value,
                name: brandData.companies.find(
                  (el) => el[0] === e.target.value
                )[1],
              },
            });
          }}
        >
          <option value={0} disabled>
            Выберете компанию
          </option>
          {brandData.companies.map((company) => (
            <option key={company[0]} value={company[0]}>
              {company[1]}
            </option>
          ))}
        </select>
      </div>

      {brandSettings.company.id !== null && brandSettings.company.id !== 0 && (
        <div>
          <label>Модель транспорта</label>
          <select
            value={brandSettings.model.id}
            onChange={(e) => {
              setBrandSettings({
                ...brandSettings,
                model: {
                  id: e.target.value,
                  name: brandData.models.find(
                    (el) => el[0] === e.target.value
                  )[1],
                },
                year: "",
              });
              setBrandId(0);
              fetchYears(e.target.value);
            }}
          >
            <option value={0} disabled>
              Выберете модель
            </option>
            {brandData.models.map((model) => (
              <option key={model[0]} value={model[0]}>
                {model[1]}
              </option>
            ))}
          </select>
        </div>
      )}

      {brandSettings.model.id !== null && brandSettings.model.id !== 0 && (
        <div>
          <label>Год издания</label>
          <select
            value={brandId}
            onChange={(e) => {
              setBrandSettings({
                ...brandSettings,
                year: brandData.years.find((el) => el[0] === e.target.value)[1],
              });
              setBrandId(e.target.value);
            }}
          >
            <option value={0} disabled>
              Выберете год
            </option>
            {brandData.years.map((year) => (
              <option key={year[0]} value={year[0]}>
                {year[1]}
              </option>
            ))}
          </select>
        </div>
      )}
    </div>
  );
};

export default BrandTransport;
