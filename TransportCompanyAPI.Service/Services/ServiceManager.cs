using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Service.Abstractions;

namespace TransportCompanyAPI.Service.Services
{
    /// <summary>
    /// Сервис для работы с доругими сервисами
    /// </summary>
    public class ServiceManager : IServiceManager
    {
        /// <summary>
        /// Реопзиторий для работы с транспортом
        /// </summary>
        private readonly ITransportService transportService;

        /// <summary>
        /// Реопзиторий для работы с людьми
        /// </summary>
        private readonly IPersonService personService;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            transportService = new TransportService(repositoryManager);
            personService = new PersonService(repositoryManager);
        }

        public ITransportService TransportService => transportService;

        public IPersonService PersonService => personService;
    }
}
