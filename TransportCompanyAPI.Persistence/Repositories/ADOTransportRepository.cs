using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using TransportCompanyAPI.Domain.Entities.TransportEntities;
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

        public async Task<IEnumerable<string[]>> GetPropertiesByCategoryIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Transport> GetTransportByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<string[]>> GetTransportCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<string[]>> GetTransportCompaniesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<string[]>> GetTransportCountriesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<string[]>> GetTransportModelsByCompaniesAsync(int companyId)
        {
            throw new NotImplementedException();
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
            DataTable dataTable = sqlQueries.QuerySelect(query);

            foreach (DataRow row in dataTable.Rows)
                transports.Add(TransportConvertDataRow.ConvertTransport(row));

            return transports;
        }

        public async Task<IEnumerable<string[]>> GetTransportYearByModelAsync(int modelId)
        {
            throw new NotImplementedException();
        }
    }
}
