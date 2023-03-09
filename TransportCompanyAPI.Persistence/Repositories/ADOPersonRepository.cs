using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyAPI.Domain.Entities.PersonEntities;
using TransportCompanyAPI.Domain.Entities.TransportEntities;
using TransportCompanyAPI.Domain.Enum;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Persistence.Features;
using TransportCompanyAPI.Persistence.Queries;
using TransportCompanyAPI.Persistence.Settings;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            Person person;
            PersonPositions positionId;
            string generalCharactQuery = @$"
                SELECT * 
                FROM GetPersonById({personId})
            ";
            string uniqueCharactQuery = @$"
                SELECT * 
                FROM GetPropertyByPersonId({personId})
            ";

            DataTable generalCharactTable = sqlQueries.QuerySelect(generalCharactQuery);
            person = ConvertDataRow.ConvertPerson(generalCharactTable.Rows[0]);
            positionId = (PersonPositions)generalCharactTable.Rows[0].Field<short>("position_id");
            DataTable uniqueCharactTable = sqlQueries.QuerySelect(uniqueCharactQuery);
            Dictionary<string, string> data = new Dictionary<string, string>();
            foreach (DataRow item in uniqueCharactTable.Rows)
                data[item.Field<string>("name") ?? ""] = item.Field<string>("content") ?? "";

            switch (positionId)
            {
                case PersonPositions.Driver:
                    person = Downcast.PersonDowncast(
                        person,
                        new Driver()
                        {
                            LicenseNumber = data["LicenseNumber"],
                            DateIssueLicense = Convert.ToDateTime(data["DateIssueLicense"]),
                        }
                    );
                    break;
                case PersonPositions.Technician:
                    person = Downcast.PersonDowncast(
                        person,
                        new Technician()
                        {
                        }
                    );
                    break;
                case PersonPositions.Welder:
                    person = Downcast.PersonDowncast(
                        person,
                        new Welder()
                        {
                        }
                    );
                    break;
                case PersonPositions.Locksmith:
                    person = Downcast.PersonDowncast(
                        person,
                        new Locksmith()
                        {
                        }
                    );
                    break;
                case PersonPositions.Foreman:
                    person = Downcast.PersonDowncast(
                        person,
                        new Foreman()
                        {
                        }
                    );
                    break;

                case PersonPositions.Master:
                    person = Downcast.PersonDowncast(
                        person,
                        new Master()
                        {
                        }
                    );
                    break;
                case PersonPositions.RegionChief:
                    person = Downcast.PersonDowncast(
                        person,
                        new RegionChief()
                        {
                        }
                    );
                    break;
            }

            return person;
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
            long count;

            string query = @$"
                SELECT *
                FROM GetPersonCount(
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
            count = dataTable.Rows[0].Field<long>("count");

            return count;
        }

        public async Task<IEnumerable<string[]>> GetPersonPositionsAsync()
        {
            List<string[]> positions = new List<string[]>();

            string query = @$"
                SELECT * 
                FROM GetPersonPositions()
            ";

            DataTable dataTable = sqlQueries.QuerySelect(query);
            foreach (DataRow row in dataTable.Rows)
                positions.Add(new string[]
                {
                    row.Field<short>("position_id").ToString(),
                    row.Field<string>("name") ?? "",
                });

            return positions;
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
            IEnumerable<Person> persons;

            GetPersons getPersons = new GetPersons(sqlQueries);
            persons = getPersons.Action(
                offset: offset,
                length: length,
                name: name,
                surname: surname,
                patronymic: patronymic,
                positionId: positionId,
                startHireDate: startHireDate,
                endHireDate: endHireDate,
                startDismissalDate: startDismissalDate,
                endDismissalDate: endDismissalDate
            );

            return persons;
        }
    }
}
