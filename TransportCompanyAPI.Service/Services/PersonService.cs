using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyAPI.Domain.Entities.PersonEntities;
using TransportCompanyAPI.Domain.Entities.TransportEntities;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Service.Abstractions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TransportCompanyAPI.Service.Exceptions;
using System.Xml.Linq;

namespace TransportCompanyAPI.Service.Services
{
    /// <summary>
    /// Сервис для работы с людьми
    /// </summary>
    public class PersonService : IPersonService
    {
        /// <summary>
        /// Репозитории
        /// </summary>
        private readonly IRepositoryManager repositoryManager;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repositoryManager"></param>
        public PersonService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<Person> GetPersonByIdAsync(long personId)
        {
            if (personId <= 0)
                throw new PersonNotFoundException(personId);

            try
            {
                Person persons = await repositoryManager.PersonRepository.GetPersonByIdAsync(personId);
                return persons;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
            try
            {
                long persons = await repositoryManager.PersonRepository.GetPersonCountAsync(
                    name,
                    surname,
                    patronymic,
                    positionId,
                    startHireDate,
                    endHireDate,
                    startDismissalDate,
                    endDismissalDate
                );
                return persons;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
            if (offset < 0)
                throw new NegativeStartScoreException(offset);

            if (length < 0)
                throw new NegativeLengthException(length);

            if (length == 0)
                return new List<Person>();

            try
            {
                IEnumerable<Person> persons = await repositoryManager.PersonRepository.GetPersonsAsync(
                    offset,
                    length,
                    name,
                    surname,
                    patronymic,
                    positionId,
                    startHireDate,
                    endHireDate,
                    startDismissalDate,
                    endDismissalDate
                );
                return persons;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
