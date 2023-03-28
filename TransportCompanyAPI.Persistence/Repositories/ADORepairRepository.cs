using System.Data;
using TransportCompanyAPI.Domain.Entities.PersonEntities;
using TransportCompanyAPI.Domain.Entities.SubordinationEntities;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Persistence.Features;

namespace TransportCompanyAPI.Persistence.Repositories
{
    /// <summary>
    /// Класс для работы с ремонтами.
    /// Доступ к базе данных при помощи средств ADO.NET
    /// </summary>
    public class ADORepairRepository : IRepairRepository
    {
        // <summary>
        /// Объект для отправки SQL запросов
        /// </summary>
        private SqlQueries sqlQueries;

        /// <summary>
        /// Класс для работы с ремонтами.
        /// Доступ к базе данных при помощи средств ADO.NET
        /// </summary>
        public ADORepairRepository(SqlQueries sqlQueries)
        {
            this.sqlQueries = sqlQueries;
        }

        public async Task<IEnumerable<(string Name, long Count)>> GetDetailsByBrandIdAsync(
            long brandId, 
            DateTime? start, 
            DateTime? end, 
            IEnumerable<short> detailsId
        )
        {
            List<(string Name, long Count)> details = new List<(string Name, long Count)>();

            string query = @$"
                DECLARE @TL [smallint_list];
                INSERT @TL VALUES ({String.Join("), (", detailsId)})
                SELECT * 
                FROM GetDetailsByBrandId(
                    {brandId},
                    '{Helpers.ConvertDateTimeInISO8601(start)}',
                    '{Helpers.ConvertDateTimeInISO8601(end)}',
                    @TL
                )
            ";

            DataTable dataTable = sqlQueries.QuerySelect(query);
            foreach (DataRow row in dataTable.Rows)
                details.Add((
                    Name: row.Field<string>("name") ?? "",
                    Count: row.Field<long>("count")
                ));

            return details;
        }

        public async Task<IEnumerable<(string Name, long Count)>> GetDetailsByCategoryIdAsync(
            short сategoryId, 
            DateTime? start, 
            DateTime? end, 
            IEnumerable<short> detailsId
        )
        {
            List<(string Name, long Count)> details = new List<(string Name, long Count)>();

            string query = @$"
                DECLARE @TL [smallint_list];
                INSERT @TL VALUES ({String.Join("), (", detailsId)})
                SELECT * 
                FROM GetDetailsByCategoryId(
                    {сategoryId},
                    '{Helpers.ConvertDateTimeInISO8601(start)}',
                    '{Helpers.ConvertDateTimeInISO8601(end)}',
                    @TL
                )
            ";

            DataTable dataTable = sqlQueries.QuerySelect(query);
            foreach (DataRow row in dataTable.Rows)
                details.Add((
                    Name: row.Field<string>("name") ?? "",
                    Count: row.Field<long>("count")
                ));

            return details;
        }

        public async Task<(long Count, decimal Price)> GetRepairInformationByBrandIdAsync(
            long brandId, 
            DateTime? start, 
            DateTime? end
        )
        {
            (long Count, decimal Price) repairInformation;

            string query = @$"
                SELECT * 
                FROM GetRepairInformationByBrandId(
                    {brandId},
                    '{Helpers.ConvertDateTimeInISO8601(start)}',
                    '{Helpers.ConvertDateTimeInISO8601(end)}'
                )
            ";

            DataTable dataTable = sqlQueries.QuerySelect(query);
            repairInformation.Count = dataTable.Rows[0].Field<long>("count");
            repairInformation.Price = dataTable.Rows[0].Field<decimal>("price");

            return repairInformation;
        }

        public async Task<(long Count, decimal Price)> GetRepairInformationByCategoryIdAsync(
            short categoryId, 
            DateTime? start, 
            DateTime? end
        )
        {
            (long Count, decimal Price) repairInformation;

            string query = @$"
                SELECT * 
                FROM GetRepairInformationByCategoryId(
                    {categoryId},
                    '{Helpers.ConvertDateTimeInISO8601(start)}',
                    '{Helpers.ConvertDateTimeInISO8601(end)}'
                )
            ";

            DataTable dataTable = sqlQueries.QuerySelect(query);
            repairInformation.Count = dataTable.Rows[0].Field<long>("count");
            repairInformation.Price = dataTable.Rows[0].Field<decimal>("price");

            return repairInformation;
        }

        public async Task<(long Count, decimal Price)> GetRepairInformationByTransportIdAsync(
            long transportId, 
            DateTime? start, 
            DateTime? end
        )
        {
            (long Count, decimal Price) repairInformation;

            string query = @$"
                SELECT * 
                FROM GetRepairInformationByTransportId(
                    {transportId},
                    '{Helpers.ConvertDateTimeInISO8601(start)}',
                    '{Helpers.ConvertDateTimeInISO8601(end)}'
                )
            ";

            DataTable dataTable = sqlQueries.QuerySelect(query);
            repairInformation.Count = dataTable.Rows[0].Field<long>("count");
            repairInformation.Price = dataTable.Rows[0].Field<decimal>("price");

            return repairInformation;
        }
    }
}
