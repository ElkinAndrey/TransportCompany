using TransportCompanyAPI.Domain.Repositories;

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

        public Task<(long Count, decimal Price)> GetRepairInformationByCategoryIdAsync(
            short сategoryId, 
            DateTime? start, 
            DateTime? end
        )
        {
            throw new NotImplementedException();
        }
    }
}
