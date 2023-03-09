using System.Data;
using TransportCompanyAPI.Domain.Entities.PersonEntities;
using TransportCompanyAPI.Domain.Entities.SubordinationEntities;
using TransportCompanyAPI.Domain.Entities.TransportEntities;

namespace TransportCompanyAPI.Persistence.Features
{
    /// <summary>
    /// Конвертировать строки из базы данных в объекты
    /// </summary>
    static class ConvertDataRow
    {
        /// <summary>
        /// Конвертировать строку в базе данных в человека
        /// </summary>
        /// <param name="row">Строка</param>
        /// <returns>Человек</returns>
        static public Person ConvertPerson(DataRow row) =>
            new Person()
            {
                PersonId = row.Field<long>("person_id"),
                Name = row.Field<string>("name") ?? "",
                Surname = row.Field<string>("surname") ?? "",
                Patronymic = row.Field<string>("patronymic") ?? "",
                HireDate = row.Field<DateTime>("start"),
                DismissalDate = row.Field<DateTime?>("end"),
                PersonPosition = row.Field<string>("position") ?? "",
            };

        /// <summary>
        /// Конвертировать строку в базе данных в транспорт
        /// </summary>
        /// <param name="row">Строка</param>
        /// <returns>Транспорт</returns>
        static public Transport ConvertTransport(DataRow row) =>
            new Transport()
            {
                TransportId = row.Field<long>("transport_id"),
                Category = row.Field<string>("category") ?? "",
                Series = row.Field<string>("series") ?? "",
                Number = row.Field<string>("number") ?? "",
                RegionCode = row.Field<string>("region_code") ?? "",
                CountryCode = row.Field<string>("country_code") ?? "",
                DecipheringCountry = row.Field<string>("deciphering_country") ?? "",
                Start = row.Field<DateTime>("start"),
                End = row.Field<DateTime?>("end"),
                Mileage = row.Field<int>("mileage"),
                ManufacturerCompany = row.Field<string>("manufacturer_company") ?? "",
                TransportModel = row.Field<string>("transport_model") ?? "",
                YearPublishing = row.Field<int>("year_publishing"),
            };

        /// <summary>
        /// Конвертировать строку в базе данных с начальством в объект человека
        /// </summary>
        /// <param name="position">Должность начальника</param>
        /// <param name="row">Строка</param>W
        /// <returns>Человек</returns>
        static public Person ConvertSubordinationPerson(string position, DataRow row) =>
            new Person()
            {
                PersonId = row.Field<long>($"{position}_id"),
                Name = row.Field<string>($"{position}_name") ?? "",
                Surname = row.Field<string>($"{position}_surname") ?? "",
                Patronymic = row.Field<string>($"{position}_patronymic") ?? "",
                HireDate = row.Field<DateTime>($"{position}_start"),
                DismissalDate = row.Field<DateTime?>($"{position}_end"),
                PersonPosition = row.Field<string>($"{position}_position") ?? "",
            };

        /// <summary>
        /// Конвертировать строку в базе данных с начальством в объект участка
        /// </summary>
        /// <param name="row">Строка</param>
        /// <returns>Участок</returns>
        static public Region ConvertRegion(DataRow row) =>
            new Region()
            {
                RegionId = row.Field<long>("region_id"),
                Name = row.Field<string>("region_name") ?? "",
                RegionChief = Downcast.PersonDowncast(
                    ConvertSubordinationPerson("region_chief", row),
                    new RegionChief()
                )
            };

        /// <summary>
        /// Получить мастерскую по строке в базе данных
        /// </summary>
        /// <param name="row">строка</param>
        /// <returns>Мастерска</returns>
        static public Workshop ConvertWorkshop(DataRow row) =>
            new Workshop()
            {
                WorkshopId = row.Field<long>("workshop_id"),
                Name = row.Field<string>("workshop_name") ?? "",
                Master = Downcast.PersonDowncast(
                    ConvertSubordinationPerson("master", row),
                    new Master()
                ),
                GarageFacility = ConvertGarageFacility(row),
            };

        /// <summary>
        /// Получить объект гаражного хозяйства из строки в базе данных
        /// </summary>
        /// <param name="row">Строка</param>
        /// <returns>Объект гаражного хозяйства</returns>
        static public GarageFacility ConvertGarageFacility(DataRow row) =>
            new GarageFacility()
            {
                GarageFacilityId = row.Field<long>("garage_facility_id"),
                Address = row.Field<string>("garage_facility_address") ?? "",
                Category = row.Field<string>("garage_facility_category") ?? "",
            };

        /// <summary>
        /// Получить блигаду по строке из базы данных
        /// </summary>
        /// <param name="row">Строка</param>
        /// <returns>Бригада</returns>
        static public Brigade ConvertBrigade(DataRow row) =>
            new Brigade()
            {
                BrigadeId = row.Field<long>("brigade_id"),
                Name = row.Field<string>("brigade_name") ?? "",
                Foreman = Downcast.PersonDowncast(
                    ConvertSubordinationPerson("foreman", row),
                    new Foreman()
                ),
            };
    }
}
