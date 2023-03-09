using System.Data;
using TransportCompanyAPI.Domain.Entities.PersonEntities;
using TransportCompanyAPI.Domain.Entities.SubordinationEntities;
using TransportCompanyAPI.Domain.Enum;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Persistence.Features;
using TransportCompanyAPI.Persistence.Queries;

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
                    GetTransports getTransports = new GetTransports(sqlQueries);
                    person = Downcast.PersonDowncast(
                        person,
                        new Driver()
                        {
                            LicenseNumber = data["LicenseNumber"],
                            DateIssueLicense = Convert.ToDateTime(data["DateIssueLicense"]),
                            Transports = getTransports.Action(
                                length: 100,
                                personId: personId
                            ),
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
                            Brigade = GetBrigadeByForemanId(personId),
                        }
                    );
                    break;
                case PersonPositions.Master:
                    person = Downcast.PersonDowncast(
                        person,
                        new Master()
                        {
                            Workshop = GetWorkshopByMasterId(personId)
                        }
                    );
                    break;
                case PersonPositions.RegionChief:
                    person = Downcast.PersonDowncast(
                        person,
                        new RegionChief()
                        {
                            Region = GetRegionByRegionChiefId(personId)
                        }
                    );
                    break;
            }

            // Ввод бригады у обслуживающего персонала
            long? brigadeId = generalCharactTable.Rows[0].Field<long?>("brigade_id");
            string? brigadeName = generalCharactTable.Rows[0].Field<string?>("brigade_name");

            ServiceStaff? serviceStaff = person as ServiceStaff;

            if (serviceStaff != null && brigadeId != null)
            {
                serviceStaff.Brigade = new Brigade()
                {
                    BrigadeId = brigadeId ?? 0,
                    Name = brigadeName ?? "",
                };
                person = serviceStaff;
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

        /// <summary>
        /// Получить бригаду по Id бригадира
        /// </summary>
        /// <param name="foremanId">Id бригадира</param>
        /// <returns>Бригада</returns>
        private Brigade GetBrigadeByForemanId(long foremanId)
        {
            Brigade brigade;

            string query = @$"
                SELECT * 
                FROM GetBrigadeByForemanId({foremanId})
            ";

            DataTable dataTable = sqlQueries.QuerySelect(query);
            brigade = new Brigade
            {
                BrigadeId = dataTable.Rows[0].Field<long>("brigade_id"),
                Name = dataTable.Rows[0].Field<string>("brigade_name") ?? "",
            };

            return brigade;
        }

        /// <summary>
        /// Получить мастерскую по Id мастера
        /// </summary>
        /// <param name="masterId">Id мастера</param>
        /// <returns>Мастерская</returns>
        private Workshop GetWorkshopByMasterId(long masterId)
        {
            Workshop workshop;

            string query = @$"
                SELECT * 
                FROM GetWorkshopByMasterId({masterId})
            ";

            DataTable dataTable = sqlQueries.QuerySelect(query);
            workshop = new Workshop
            {
                WorkshopId = dataTable.Rows[0].Field<long>("workshop_id"),
                Name = dataTable.Rows[0].Field<string>("workshop_name") ?? "",
            };

            return workshop;
        }

        /// <summary>
        /// Получить участок по Id начальника участка
        /// </summary>
        /// <param name="regionChiefId">Id начальника участка</param>
        /// <returns>Участок</returns>
        private Region GetRegionByRegionChiefId(long regionChiefId)
        {
            Region region;

            string query = @$"
                SELECT * 
                FROM GetRegionByRegionChiefId({regionChiefId})
            ";

            DataTable dataTable = sqlQueries.QuerySelect(query);
            region = new Region
            {
                RegionId = dataTable.Rows[0].Field<long>("region_id"),
                Name = dataTable.Rows[0].Field<string>("region_name") ?? "",
            };

            return region;
        }
    }
}
