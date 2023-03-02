using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Service.Abstractions;

namespace TransportCompanyAPI.Service.Services
{
    public class ServiceManager : IServiceManager
    {
        /// <summary>
        /// Реопзиторий для работы с транспортом
        /// </summary>
        private readonly ITransportService transportService;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            transportService = new TransportService(repositoryManager);
        }

        public ITransportService TransportService => transportService;
    }
}
