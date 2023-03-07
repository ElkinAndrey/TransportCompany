using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyAPI.Domain.Entities.PersonEntities;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Persistence.Features;
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

        public async Task<Person> GetPersonByIdAsync(long personId)
        {
            throw new NotImplementedException();
        }

        public async Task<long> GetPersonCountAsync(
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

        public async Task<IEnumerable<string[]>> GetPersonPositionsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync(
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
            List<Person> persons = new List<Person>();

            string query = @$"
                SELECT * FROM GetPersons (
	                {offset},
	                {length},
	                N'{name}',
	                N'{surname}',
	                N'{patronymic}',
	                {positionId},
	                N'{Helpers.ConvertDateTimeInISO8601(startHireDate)}',
	                N'{Helpers.ConvertDateTimeInISO8601(endHireDate)}',
	                N'{Helpers.ConvertDateTimeInISO8601(startDismissalDate)}',
	                N'{Helpers.ConvertDateTimeInISO8601(endDismissalDate)}'
                )
            ";

            DataTable dataTable = sqlQueries.QuerySelect(query);

            foreach (DataRow row in dataTable.Rows)
                persons.Add(PersonConvertDataRow.ConvertPerson(row));

            return persons;
        }
    }
}
