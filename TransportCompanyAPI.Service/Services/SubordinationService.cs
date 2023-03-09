using TransportCompanyAPI.Domain.Entities.PersonEntities;
using TransportCompanyAPI.Domain.Entities.SubordinationEntities;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Service.Abstractions;
using TransportCompanyAPI.Service.Exceptions;

namespace TransportCompanyAPI.Service.Services
{
    /// <summary>
    /// Сервис для работы с подчиненностью
    /// </summary>
    public class SubordinationService : ISubordinationService
    {
        /// <summary>
        /// Репозитории
        /// </summary>
        private readonly IRepositoryManager repositoryManager;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repositoryManager"></param>
        public SubordinationService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<Brigade> GetBrigadeAsync(long brigadeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Region> GetRegionAsync(long regionId)
        {
            if (regionId <= 0)
                throw new RegionNotFoundException(regionId);

            try
            {
                Region region = await repositoryManager.SubordinationRepository.GetRegionAsync(regionId);
                return region;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Region>> GetRegionsAsync()
        {
            try
            {
                IEnumerable<Region> regions = await repositoryManager.SubordinationRepository.GetRegionsAsync();
                return regions;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SubordinationCount> GetSubordinationCountAsync(long RegionId, long WorkshopId, long BrigadeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Workshop> GetWorkshopAsync(long workshopId)
        {
            if (workshopId <= 0)
                throw new WorkshopNotFoundException(workshopId);

            try
            {
                Workshop region = await repositoryManager.SubordinationRepository.GetWorkshopAsync(workshopId);
                return region;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
