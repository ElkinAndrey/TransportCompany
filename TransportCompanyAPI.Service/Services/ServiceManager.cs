﻿using TransportCompanyAPI.Domain.Repositories;
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
        /// Реопзиторий для работы с подчиненностью
        /// </summary>
        private readonly ISubordinationService subordinationService;

        /// <summary>
        /// Реопзиторий для работы с ремонтами
        /// </summary>
        private readonly IRepairService repairService;

        /// <summary>
        /// Сервис для работы с доругими сервисами
        /// </summary>
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            transportService = new TransportService(repositoryManager);
            personService = new PersonService(repositoryManager);
            subordinationService = new SubordinationService(repositoryManager);
            repairService = new RepairService(repositoryManager);
        }

        public ITransportService TransportService => transportService;

        public IPersonService PersonService => personService;

        public ISubordinationService SubordinationService => subordinationService;

        public IRepairService RepairService => repairService;
    }
}
