using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyAPI.Domain.Entities.PersonEntities;
using TransportCompanyAPI.Domain.Entities.SubordinationEntities;
using TransportCompanyAPI.Domain.Entities.TransportEntities;

namespace TransportCompanyAPI.Persistence.Features
{
    static class SubordinationConvertDataRow
    {
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

        static public GarageFacility ConvertGarageFacility(DataRow row) =>
            new GarageFacility()
            {
                GarageFacilityId = row.Field<long>("garage_facility_id"),
                Address = row.Field<string>("garage_facility_address") ?? "",
                Category = row.Field<string>("garage_facility_category") ?? "",
            };

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
