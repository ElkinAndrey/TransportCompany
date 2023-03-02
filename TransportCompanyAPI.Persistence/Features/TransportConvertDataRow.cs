using System.Data;
using TransportCompanyAPI.Domain.Entities.TransportEntities;

namespace TransportCompanyAPI.Persistence.Features
{
    static class TransportConvertDataRow
    {
        static public Transport ConvertTransport(DataRow row) =>
            new Transport()
            {
                TransportId = row.Field<long>("transport_id"),
                Category = row.Field<string>("category") ?? "",
                Series = row.Field<string>("series") ?? "",
                Number = row.Field<string>("number") ?? "",
                RegionCode = row.Field<string>("region_code") ?? "",
                CountryCode = row.Field<string>("country_code") ?? "",
                DecipheringCountry = row.Field<string>("deciphering_country") ?? "",
                Start = row.Field<DateTime>("start"),
                End = row.Field<DateTime?>("end"),
                Mileage = row.Field<int>("mileage"),
                ManufacturerCompany = row.Field<string>("manufacturer_company") ?? "",
                TransportModel = row.Field<string>("transport_model") ?? "",
                YearPublishing = row.Field<int>("year_publishing"),
            };
    }
}