using System.Data;
using TransportCompanyAPI.Domain.Entities.PersonEntities;
using TransportCompanyAPI.Domain.Entities.TransportEntities;

namespace TransportCompanyAPI.Persistence.Features
{
    static class PersonConvertDataRow
    {
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
    }
}
