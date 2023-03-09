using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyAPI.Domain.Entities.PersonEntities;
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
    }
}
