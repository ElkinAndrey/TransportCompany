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

        public async Task<(long Count, decimal Price)> GetRepairInformationByBrandIdAsync(
            short brandId, 
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
    }
}
