using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Service.Abstractions;
using TransportCompanyAPI.Service.Exceptions;

namespace TransportCompanyAPI.Service.Services
{
    /// <summary>
    /// Сервис для работы с ремонтами
    /// </summary>
    public class RepairService : IRepairService
    {
        /// <summary>
        /// Репозитории
        /// </summary>
        private readonly IRepositoryManager repositoryManager;

        /// <summary>
        /// Сервис для работы с ремонтами
        /// </summary>
        /// <param name="repositoryManager">Менеджер репозиториев, отвечающий за работу со всеми репозиториями</param>
        public RepairService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<(string Name, long Count)>> GetDetailsByBrandIdAsync(long brandId, DateTime? start, DateTime? end, IEnumerable<short> detailsId)
        {
            if (start != null && end != null && start > end)
                return new List<(string Name, long Count)>();

            if (brandId < 0)
                throw new NegativeStartScoreException(brandId);

            if (!detailsId.Any())
                return new List<(string Name, long Count)>();

            try
            {
                var repairInformation = await repositoryManager.RepairRepository.GetDetailsByBrandIdAsync(
                    brandId,
                    start,
                    end,
                    detailsId
                );
                return repairInformation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<(string Name, long Count)>> GetDetailsByCategoryIdAsync(
            short сategoryId, 
            DateTime? start, 
            DateTime? end, 
            IEnumerable<short> detailsId
        )
        {
            if (start != null && end != null && start > end)
                return new List<(string Name, long Count)>();

            if (сategoryId < 0)
                throw new NegativeStartScoreException(сategoryId);

            if (!detailsId.Any())
                return new List<(string Name, long Count)>();

            try
            {
                var repairInformation = await repositoryManager.RepairRepository.GetDetailsByCategoryIdAsync(
                    сategoryId,
                    start,
                    end,
                    detailsId
                );
                return repairInformation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(long Count, decimal Price)> GetRepairInformationByBrandIdAsync(
            long brandId, 
            DateTime? start, 
            DateTime? end
        )
        {
            if (start != null && end != null && start > end)
                return (0, 0);

            if (brandId < 0)
                throw new NegativeStartScoreException(brandId);

            try
            {
                var repairInformation = await repositoryManager.RepairRepository.GetRepairInformationByBrandIdAsync(
                    brandId,
                    start,
                    end
                );
                return repairInformation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(long Count, decimal Price)> GetRepairInformationByCategoryIdAsync(
            short сategoryId, 
            DateTime? start, 
            DateTime? end
        )
        {
            if (start != null && end != null && start > end)
                return (0, 0);

            if (сategoryId < 0)
                throw new NegativeStartScoreException(сategoryId);

            try
            {
                var repairInformation = await repositoryManager.RepairRepository.GetRepairInformationByCategoryIdAsync(
                    сategoryId, 
                    start, 
                    end
                );
                return repairInformation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(long Count, decimal Price)> GetRepairInformationByTransportIdAsync(
            long transportId, 
            DateTime? start, 
            DateTime? end
        )
        {
            if (start != null && end != null && start > end)
                return (0, 0);

            if (transportId < 0)
                throw new NegativeStartScoreException(transportId);

            try
            {
                var repairInformation = await repositoryManager.RepairRepository.GetRepairInformationByTransportIdAsync(
                    transportId,
                    start,
                    end
                );
                return repairInformation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
