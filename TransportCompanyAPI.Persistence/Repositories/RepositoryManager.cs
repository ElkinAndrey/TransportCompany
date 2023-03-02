using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Persistence.Settings;

namespace TransportCompanyAPI.Persistence.Repositories
{
    internal class RepositoryManager : IRepositoryManager
    {
        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        private string connectionString = ADOSettings.connectionString;

        /// <summary>
        /// РЕопзиторий для работы с транспортом
        /// </summary>
        private readonly ITransportRepository transportRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public RepositoryManager()
        {
            SqlConnection connection = new(connectionString);
            SqlQueries sqlQueries = new SqlQueries(connection);
            transportRepository = new ADOTransportRepository(sqlQueries);
        }

        public ITransportRepository TransportRepository => transportRepository;
    }
}
