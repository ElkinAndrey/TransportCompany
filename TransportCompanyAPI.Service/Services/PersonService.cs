using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyAPI.Domain.Entities.PersonEntities;
using TransportCompanyAPI.Service.Abstractions;

namespace TransportCompanyAPI.Service.Services
{
    /// <summary>
    /// Сервис для работы с людьми
    /// </summary>
    public class PersonService : IPersonService
    {
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
            throw new NotImplementedException();
        }
    }
}
