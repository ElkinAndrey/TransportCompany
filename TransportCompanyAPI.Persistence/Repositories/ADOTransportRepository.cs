using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Microsoft.SqlServer.Server;
using TransportCompanyAPI.Domain.Entities.TransportEntities;
using TransportCompanyAPI.Domain.Enum;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Persistence.Features;
using TransportCompanyAPI.Persistence.Settings;

namespace TransportCompanyAPI.Persistence.Repositories
{
    public class ADOTransportRepository : ITransportRepository
    {
        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        private string connectionString = ADOSettings.connectionString;

        /// <summary>
        /// Объект для отправки SQL запросов
        /// </summary>
        private SqlQueries sqlQueries;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ADOTransportRepository()
        {
            SqlConnection connection = new(connectionString);
            sqlQueries = new SqlQueries(connection);
        }

        public async Task<IEnumerable<string[]>> GetPropertiesByCategoryIdAsync(short categoryId)
        {
            List<string[]> property = new List<string[]>();

            string query = @$"
                SELECT * 
                FROM GetPropertiesByCategoryId({categoryId})  
            ";

            DataTable dataTable1 = sqlQueries.QuerySelect(query);

            foreach (DataRow row in dataTable1.Rows)
                property.Add(new string[]
                {
                    row.Field<long>("property_id").ToString(),
                    row.Field<string>("name") ?? "",
                    row.Field<string>("translation") ?? "",
                    row.Field<string>("type") ?? "",
                });

            return property;
        }

        public async Task<Transport> GetTransportByIdAsync(long id)
        {
            Transport transport;
            TransportCategories categoryId;
            string generalCharactQuery = @$"
                SELECT * 
                FROM GetTransportById({id})
            ";
            string uniqueCharactQuery = @$"
                SELECT * 
                FROM GetPropertyByTransportId({id})
            ";

            DataTable generalCharactTable = sqlQueries.QuerySelect(generalCharactQuery);
            transport = TransportConvertDataRow.ConvertTransport(generalCharactTable.Rows[0]);
            categoryId = (TransportCategories)generalCharactTable.Rows[0].Field<short>("category_id");
            DataTable uniqueCharactTable = sqlQueries.QuerySelect(uniqueCharactQuery);
            Dictionary<string, string> data = new Dictionary<string, string>();
            foreach (DataRow item in uniqueCharactTable.Rows)
                data[item.Field<string>("name") ?? ""] = item.Field<string>("content") ?? "";

            switch (categoryId)
            {
                case TransportCategories.Bus:
                    transport = Downcast.TransportDowncast(
                        transport,
                        new Bus()
                        {
                            NumberSeats = Convert.ToInt32(data["number_seats"]),
                            NumberStandingPlaces = Convert.ToInt32(data["number_standing_places"]),
                            NumberPlacesForDisabled = Convert.ToInt32(data["number_placesFor_disabled"]),
                        }
                    );
                    break;
                case TransportCategories.Taxi:
                    transport = Downcast.TransportDowncast(
                        transport,
                        new Taxi()
                        {
                            NumberSeats = Convert.ToInt32(data["number_seats"]),
                        }
                    );
                    break;
                case TransportCategories.ShuttleTaxi:
                    transport = Downcast.TransportDowncast(
                        transport,
                        new ShuttleTaxi()
                        {
                            NumberSeats = Convert.ToInt32(data["number_seats"]),
                        }
                    );
                    break;
                case TransportCategories.FreightTransport:
                    transport = Downcast.TransportDowncast(
                        transport,
                        new FreightTransport()
                        {
                            LoadCapacity = Convert.ToInt32(data["load_capacity"]),
                            Height = Convert.ToDouble(data["height"].Replace('.', ',')),
                        }
                    );
                    break;
                case TransportCategories.CargoTransportation:
                    transport = Downcast.TransportDowncast(
                        transport,
                        new AuxiliaryTransport()
                        {
                            Height = Convert.ToDouble(data["height"].Replace('.', ',')),
                        }
                    );
                    break;
            }
            return transport;
        }

        public async Task<IEnumerable<string[]>> GetTransportCategoriesAsync()
        {
            List<string[]> categories = new List<string[]>();

            string query = @$"
                SELECT * 
                FROM GetTransportCategories()
            ";

            DataTable dataTable = sqlQueries.QuerySelect(query);
            foreach (DataRow row in dataTable.Rows)
                categories.Add(new string[]
                {
                    row.Field<short>("category_id").ToString(),
                    row.Field<string>("name") ?? "",
                });

            return categories;
        }

        public async Task<IEnumerable<string[]>> GetTransportCompaniesAsync()
        {
            List<string[]> companies = new List<string[]>();

            string query = @$"
                SELECT * 
                FROM GetTransportCompanies()
            ";

            DataTable dataTable = sqlQueries.QuerySelect(query);
            foreach (DataRow row in dataTable.Rows)
                companies.Add(new string[]
                {
                    row.Field<long>("company_id").ToString(),
                    row.Field<string>("name") ?? "",
                });

            return companies;
        }

        public async Task<IEnumerable<string[]>> GetTransportCountriesAsync()
        {
            List<string[]> countries = new List<string[]>();

            string query = @$"
                SELECT * 
                FROM GetTransportCountries()
            ";

            DataTable dataTable = sqlQueries.QuerySelect(query);
            foreach (DataRow row in dataTable.Rows)
                countries.Add(new string[]
                {
                    row.Field<short>("country_id").ToString(),
                    row.Field<string>("country_code") ?? "",
                    row.Field<string>("deciphering_country") ?? "",
                });

            return countries;
        }

        public async Task<IEnumerable<string[]>> GetTransportModelsByCompanyIdAsync(long companyId)
        {
            List<string[]> models = new List<string[]>();

            string query = @$"
                SELECT * 
                FROM GetTransportModelsByCompanyId({companyId})
            ";

            DataTable dataTable = sqlQueries.QuerySelect(query);
            foreach (DataRow row in dataTable.Rows)
                models.Add(new string[]
                {
                    row.Field<long>("model_id").ToString(),
                    row.Field<string>("name") ?? "",
                });

            return models;
        }

        public async Task<IEnumerable<Transport>> GetTransportsAsync(
            long offset, 
            long length, 
            string series, 
            string number, 
            string regionCode, 
            short transportCountryId, 
            short transportCategoryId, 
            DateTime? startBuy,
            DateTime? endBuy,
            DateTime? startWriteOff,
            DateTime? endWriteOff
        )
        {
            List<Transport> transports = new List<Transport>();
            string query = @$"
                SELECT * 
                FROM GetTransports(
                    {offset},
                    {length}, 
                    N'{series}',
                    N'{number}',
                    N'{regionCode}',
                    {transportCountryId},
                    {transportCategoryId},
                    N'{Helpers.ConvertDateTimeInISO8601(startBuy)}',
                    N'{Helpers.ConvertDateTimeInISO8601(endBuy)}',
                    N'{Helpers.ConvertDateTimeInISO8601(startWriteOff)}',
                    N'{Helpers.ConvertDateTimeInISO8601(endWriteOff)}'
                )
            ";
            await Task.Run(() => {
                DataTable dataTable = sqlQueries.QuerySelect(query);

                foreach (DataRow row in dataTable.Rows)
                    transports.Add(TransportConvertDataRow.ConvertTransport(row));
            });

            return transports;
        }

        public async Task<IEnumerable<string[]>> GetTransportYearByModelIdAsync(long modelId)
        {
            List<string[]> models = new List<string[]>();

            string query = @$"
                SELECT * 
                FROM GetTransportYearByModelId({modelId})
            ";

            DataTable dataTable = sqlQueries.QuerySelect(query);
            foreach (DataRow row in dataTable.Rows)
                models.Add(new string[]
                {
                    row.Field<long>("brand_id").ToString(),
                    row.Field<int>("year_publishing").ToString(),
                });

            return models;
        }
    }
}
