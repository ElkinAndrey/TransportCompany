using System.Diagnostics.Metrics;
using TransportCompanyAPI.Domain.Entities.PersonEntities;
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

        public async Task<(long Count, decimal Price)> GetRepairInformationByCategoryIdAsync(short сategoryId, DateTime? start, DateTime? end)
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
    }
}
