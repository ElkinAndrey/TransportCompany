using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Service.Abstractions;

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

        public Task<(long Count, decimal Price)> GetRepairInformationByCategoryIdAsync(short сategoryId, DateTime? start, DateTime? end)
        {
            throw new NotImplementedException();
        }
    }
}
