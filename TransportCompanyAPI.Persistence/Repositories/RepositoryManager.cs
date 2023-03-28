using System.Data.SqlClient;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Persistence.Settings;

namespace TransportCompanyAPI.Persistence.Repositories
{
    /// <summary>
    /// Репозиторий для работы с остальными репозиториями
    /// </summary>
    public class RepositoryManager : IRepositoryManager
    {
        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        private string connectionString = ADOSettings.connectionString;

        /// <summary>
        /// Реопзиторий для работы с транспортом
        /// </summary>
        private readonly ITransportRepository transportRepository;

        /// <summary>
        /// Реопзиторий для работы с людьми
        /// </summary>
        private readonly IPersonRepository personRepository;

        /// <summary>
        /// Реопзиторий для работы с подчиненностью
        /// </summary>
        private readonly ISubordinationRepository subordinationRepository;

        /// <summary>
        /// Реопзиторий для работы с ремонтами
        /// </summary>
        private readonly IRepairRepository repairRepository;

        /// <summary>
        /// Репозиторий для работы с остальными репозиториями
        /// </summary>
        public RepositoryManager()
        {
            SqlConnection connection = new(connectionString);
            SqlQueries sqlQueries = new SqlQueries(connection);

            transportRepository = new ADOTransportRepository(sqlQueries);
            personRepository = new ADOPersonRepository(sqlQueries);
            subordinationRepository = new ADOSubordinationRepository(sqlQueries);
            repairRepository = new ADORepairRepository(sqlQueries);
        }

        public ITransportRepository TransportRepository => transportRepository;

        public IPersonRepository PersonRepository => personRepository;

        public ISubordinationRepository SubordinationRepository => subordinationRepository;

        public IRepairRepository RepairRepository => repairRepository;
    }
}
