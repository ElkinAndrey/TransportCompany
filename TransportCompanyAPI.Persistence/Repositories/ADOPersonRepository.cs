using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyAPI.Domain.Entities.PersonEntities;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Persistence.Settings;

namespace TransportCompanyAPI.Persistence.Repositories
{
    /// <summary>
    /// Класс для работы с людьми.
    /// Доступ к базе данных при помощи средств ADO.NET
    /// </summary>
    public class ADOPersonRepository : IPersonRepository
    {
        /// <summary>
        /// Объект для отправки SQL запросов
        /// </summary>
        private SqlQueries sqlQueries;

        /// <summary>
        /// Конструктов
        /// </summary>
        public ADOPersonRepository(SqlQueries sqlQueries)
        {
            this.sqlQueries = sqlQueries;
        }

        public Task<Person> GetPersonById(long personId)
        {
            throw new NotImplementedException();
        }

        public Task<long> GetPersonCount(
            string name, 
            string surname, 
            string patronymic, 
            short positionId, 
            DateTime? startHireDate, 
            DateTime? endHireDate,
            DateTime? startDismissalDate,
            DateTime? endDismissalDate
        )
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string[]>> GetPersonPositions()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> GetPersons(
            long offset, 
            long length, 
            string name, 
            string surname, 
            string patronymic, 
            short positionId, 
            DateTime? startHireDate, 
            DateTime? endHireDate, 
            DateTime? startDismissalDate, 
            DateTime? endDismissalDate
        )
        {
            throw new NotImplementedException();
        }
    }
}
