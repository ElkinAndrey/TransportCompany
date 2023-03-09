using System.Data;
using TransportCompanyAPI.Domain.Entities.PersonEntities;
using TransportCompanyAPI.Domain.Entities.SubordinationEntities;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Persistence.Features;

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

        public async Task<Brigade> GetBrigadeAsync(long brigadeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Region> GetRegionAsync(long regionId)
        {
            Region region;
            List<Workshop> workshops;

            string regionQuery = @$"
                SELECT *
                FROM GetRegionById({regionId})
            ";
            DataTable regionTable = sqlQueries.QuerySelect(regionQuery);
            region = SubordinationConvertDataRow.ConvertRegion(regionTable.Rows[0]);

            string workshopsQuery = @$"
                SELECT *
                FROM GetWorkshopsByRegionId({regionId})
            ";
            DataTable workshopsTable = sqlQueries.QuerySelect(workshopsQuery);
            workshops = new List<Workshop>();
            foreach (DataRow item in workshopsTable.Rows)
                workshops.Add(SubordinationConvertDataRow.ConvertWorkshop(item));

            region.Workshops = workshops;

            return region;
        }

        public async Task<IEnumerable<Region>> GetRegionsAsync()
        {
            List<Region> regions = new List<Region>();

            string query = @$"
                SELECT *
                FROM GetRegions()
            ";
            DataTable table = sqlQueries.QuerySelect(query);

            foreach (DataRow item in table.Rows)
                regions.Add(SubordinationConvertDataRow.ConvertRegion(item));

            return regions;
        }

        public async Task<SubordinationCount> GetSubordinationCountAsync(long RegionId, long WorkshopId, long BrigadeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Workshop> GetWorkshopAsync(long workshopId)
        {
            throw new NotImplementedException();
        }
    }
}
