using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyAPI.Domain.Entities.PersonEntities;
using TransportCompanyAPI.Persistence.Features;

namespace TransportCompanyAPI.Persistence.Queries
{
    /// <summary>
    /// Получить список людей
    /// </summary>
    public class GetPersons
    {
        /// <summary>
        /// Объект для отправки SQL запросов
        /// </summary>
        private SqlQueries sqlQueries;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sqlQueries">Объект для отправки SQL запросов</param>
        public GetPersons(SqlQueries sqlQueries)
        {
            this.sqlQueries = sqlQueries;
        }

        /// <summary>
        /// Получить список людей
        /// </summary>
        /// <param name="offset">Начало среза</param>
        /// <param name="length">Длина среза</param>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="patronymic">Отчество</param>
        /// <param name="positionId">Id должности</param>
        /// <param name="startHireDate">Начало периода даты начала эксплуатации</param>
        /// <param name="endHireDate">Конец периода даты начала эксплуатации</param>
        /// <param name="startDismissalDate">Начало периода даты конца эксплуатации</param>
        /// <param name="endDismissalDate">Конец периода даты окончания эксплуатации</param>
        /// <param name="brigadeId">Id бригады</param>
        /// <param name="transportId">Id транспорта</param>
        /// <returns>Списко людей</returns>
        public IEnumerable<Person> Action(
            long offset = 0,
            long length = 0,
            string name = "",
            string surname = "",
            string patronymic = "",
            short positionId = 0,
            DateTime? startHireDate = null,
            DateTime? endHireDate = null,
            DateTime? startDismissalDate = null,
            DateTime? endDismissalDate = null,
            long brigadeId = 0,
            long transportId = 0
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
	                N'{Helpers.ConvertDateTimeInISO8601(endDismissalDate)}',
                    {brigadeId},
                    {transportId}
                )
            ";

            DataTable dataTable = sqlQueries.QuerySelect(query);

            foreach (DataRow row in dataTable.Rows)
                persons.Add(ConvertDataRow.ConvertPerson(row));

            return persons;
        }
    }
}
