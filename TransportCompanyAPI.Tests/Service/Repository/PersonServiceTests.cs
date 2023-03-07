using TransportCompanyAPI.Domain.Entities.PersonEntities;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Persistence.Repositories;
using TransportCompanyAPI.Service.Abstractions;
using TransportCompanyAPI.Service.Exceptions;
using TransportCompanyAPI.Service.Services;
using Xunit;

namespace TransportCompanyAPI.Tests.Service.Repository
{
    /// <summary>
    /// Тесты класса PersonService
    /// </summary>
    public class PersonServiceTests
    {
        /// <summary>
        /// Реопзиторий для работы с людьми
        /// </summary>
        private readonly IPersonService personService;

        /// <summary>
        /// Конструктор
        /// </summary>
        public PersonServiceTests()
        {
            IRepositoryManager repositoryManager = new RepositoryManager();
            personService = new PersonService(repositoryManager);
        }

        /// <summary>
        /// Проверка метода TransportService.GetPersonsAsync
        /// </summary>
        [Fact]
        public async void TestGetPersonsAsync()
        {

            // Подготовка
            List<Person> transports;

            // Действие
            try
            {
                transports = (await personService.GetPersonsAsync(-1, 1, "", "", "", 0, null, null, null, null)).ToList();
            }
            catch (Exception ex)
            {
                Assert.Equal(ex.Message, new NegativeStartScoreException(-1).Message);
            }

            try
            {
                transports = (await personService.GetPersonsAsync(1, -1, "", "", "", 0, null, null, null, null)).ToList();
            }
            catch (Exception ex)
            {
                Assert.Equal(ex.Message, new NegativeLengthException(-1).Message);
            }

            transports = (await personService.GetPersonsAsync(1, 1, "11111111111111", "", "", 0, null, null, null, null)).ToList();
        }
    }
}
