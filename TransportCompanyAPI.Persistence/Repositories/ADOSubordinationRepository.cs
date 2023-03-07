using TransportCompanyAPI.Domain.Entities.SubordinationEntities;
using TransportCompanyAPI.Domain.Repositories;

namespace TransportCompanyAPI.Persistence.Repositories
{
    /// <summary>
    /// Класс для работы с подчиненностью.
    /// Доступ к базе данных при помощи средств ADO.NET
    /// </summary>
    public class ADOSubordinationRepository : ISubordinationRepository
    {
        /// <summary>
        /// Объект для отправки SQL запросов
        /// </summary>
        private SqlQueries sqlQueries;

        /// <summary>
        /// Конструктов
        /// </summary>
        public ADOSubordinationRepository(SqlQueries sqlQueries)
        {
            this.sqlQueries = sqlQueries;
        }

        public async Task<Brigade> GetBrigade(long brigadeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Region> GetRegion(long regionId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Region>> GetRegions()
        {
            throw new NotImplementedException();
        }

        public async Task<SubordinationCount> GetSubordinationCount(long RegionId, long WorkshopId, long BrigadeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Workshop> GetWorkshop(long workshopId)
        {
            throw new NotImplementedException();
        }
    }
}
