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

		public async Task<IEnumerable<Region>> GetAllSubjugationAsync()
		{
            try
			{
				var regions = await repositoryManager.SubordinationRepository.GetAllSubjugationAsync();
				return regions;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<Brigade> GetBrigadeAsync(long brigadeId)
        {
            if (brigadeId <= 0)
                throw new WorkshopNotFoundException(brigadeId);

            try
            {
                Brigade brigade = await repositoryManager.SubordinationRepository.GetBrigadeAsync(brigadeId);
                return brigade;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
            try
            {
                SubordinationCount subordinationCount = await repositoryManager.SubordinationRepository.GetSubordinationCountAsync(RegionId, WorkshopId, BrigadeId);
                return subordinationCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Workshop> GetWorkshopAsync(long workshopId)
        {
            if (workshopId <= 0)
                throw new WorkshopNotFoundException(workshopId);

            try
            {
                Workshop workshop = await repositoryManager.SubordinationRepository.GetWorkshopAsync(workshopId);
                return workshop;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
