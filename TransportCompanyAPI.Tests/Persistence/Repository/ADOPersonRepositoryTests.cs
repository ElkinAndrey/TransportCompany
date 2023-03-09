using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Persistence.Repositories;
using TransportCompanyAPI.Persistence.Settings;
using TransportCompanyAPI.Persistence;
using Xunit;
using TransportCompanyAPI.Domain.Entities.PersonEntities;

namespace TransportCompanyAPI.Tests.Persistence.Repository
{
    /// <summary>
    /// Тесты класса ADOPersonRepository
    /// </summary>
    public class ADOPersonRepositoryTests
    {
        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        private string connectionString = ADOSettings.connectionString;

        /// <summary>
        /// Реопзиторий для работы с транспортом
        /// </summary>
        private readonly IPersonRepository repository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ADOPersonRepositoryTests()
        {
            SqlConnection connection = new(connectionString);
            SqlQueries sqlQueries = new SqlQueries(connection);
            repository = new ADOPersonRepository(sqlQueries);
        }

        /// <summary>
        /// Проверка метода ADOPersonRepository.GetPersonsAsync
        /// </summary>
        [Fact]
        public async void TestGetPersonsAsync()
        {

            // Подготовка
            List<Person> transports;
            int size = 1;

            // Действие
            transports = (await repository.GetPersonsAsync(0, size, "", "", "", 0, null, null, null, null)).ToList();

            // Утверждение
            foreach (Person transport in transports)
            {
                Assert.True(transport.PersonId != 0);
            }
        }

        /// <summary>
        /// Проверка метода ADOPersonRepository.GetPersonPositionsAsync
        /// </summary>
        [Fact]
        public async void TestGetPersonPositionsAsync()
        {

            // Подготовка
            List<string[]> positions;

            // Действие
            positions = (await repository.GetPersonPositionsAsync()).ToList();

            // Утверждение
            foreach (string[] position in positions)
            {
                Assert.True(position.Length == 2);
            }
        }

        /// <summary>
        /// Проверка метода ADOPersonRepository.GetPersonCountAsync
        /// </summary>
        [Fact]
        public async void TestGetPersonCountAsync()
        {

            // Подготовка
            long count;

            // Действие
            count = await repository.GetPersonCountAsync("", "", "", 0, null, null, null, null);

            Assert.True(count >= 0);
        }

        /// <summary>
        /// Проверка метода ADOPersonRepository.GetPersonByIdAsync
        /// </summary>
        [Fact]
        public async void TestGetPersonByIdAsync()
        {

            // Подготовка
            Person person;

            // Действие
            person = await repository.GetPersonByIdAsync(20003);

            Assert.True(person.PersonId != 0);
        }
    }
}
