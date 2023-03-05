using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyAPI.Domain.Entities.TransportEntities;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Persistence;
using TransportCompanyAPI.Persistence.Repositories;
using TransportCompanyAPI.Persistence.Settings;
using Xunit;

namespace TransportCompanyAPI.Tests.Persistence.Repository
{
    /// <summary>
    /// Тесты класса TransportRepositoryTests
    /// </summary>
    public class ADOTransportRepositoryTests
    {
        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        private string connectionString = ADOSettings.connectionString;

        /// <summary>
        /// Реопзиторий для работы с транспортом
        /// </summary>
        private readonly ITransportRepository repository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ADOTransportRepositoryTests()
        {
            SqlConnection connection = new(connectionString);
            SqlQueries sqlQueries = new SqlQueries(connection);
            repository = new ADOTransportRepository(sqlQueries);
        }

        /// <summary>
        /// Проверка метода ADOTransportRepository.GetTransportsAsync
        /// </summary>
        [Fact]
        public async void TestGetTransportsAsync()
        {

            // Подготовка
            List<Transport> transports;
            int size = 1;

            // Действие
            transports = (await repository.GetTransportsAsync(1, size, "", "", "", 0, 0, null, null, null, null)).ToList();

            // Утверждение
            foreach (Transport transport in transports)
            {
                Assert.True(transport.TransportId != 0);
                Assert.True(transport.Mileage >= 0);
                Assert.True(transport.Category != "");
                Assert.True(transport.CountryCode != "");
                Assert.True(transport.DecipheringCountry != "");
            }
            // Assert.Equal("New Name", p.Name);
        }

        /// <summary>
        /// Проверка метода ADOTransportRepository.GetTransportByIdAsync
        /// </summary>
        [Fact]
        public async void TestGetTransportByIdAsync()
        {

            // Подготовка
            Transport transport;

            // Действие
            transport = await repository.GetTransportByIdAsync(1);

            // Утверждение
            
            Assert.True(transport.TransportId != 0);
            Assert.True(transport.Mileage >= 0);
            Assert.True(transport.Category != "");
            Assert.True(transport.CountryCode != "");
            Assert.True(transport.DecipheringCountry != "");
        }

        /// <summary>
        /// Проверка метода ADOTransportRepository.GetTransportCompaniesAsync
        /// </summary>
        [Fact]
        public async void TestGetTransportCompaniesAsync()
        {

            // Подготовка
            IEnumerable<string[]> companies;

            // Действие
            companies = await repository.GetTransportCompaniesAsync();


            Assert.True(companies.Count() != 0);
            // Утверждение
            foreach (var company in companies)
                Assert.True(company.Length == 2);
        }

        /// <summary>
        /// Проверка метода ADOTransportRepository.GetTransportModelsByCompanyIdAsync
        /// </summary>
        [Fact]
        public async void TestGetTransportModelsByCompanyIdAsync()
        {

            // Подготовка
            IEnumerable<string[]> models;

            // Действие
            models = await repository.GetTransportModelsByCompanyIdAsync(1);


            Assert.True(models.Count() != 0);
            // Утверждение
            foreach (var model in models)
                Assert.True(model.Length == 2);
        }

        /// <summary>
        /// Проверка метода ADOTransportRepository.GetTransportYearByModelIdAsync
        /// </summary>
        [Fact]
        public async void TestGetTransportYearByModelIdAsync()
        {
            // Подготовка
            IEnumerable<string[]> years;

            // Действие
            years = await repository.GetTransportYearByModelIdAsync(1);

            Assert.True(years.Count() != 0);
            // Утверждение
            foreach (var year in years)
                Assert.True(year.Length == 2);
        }

        /// <summary>
        /// Проверка метода ADOTransportRepository.GetPropertiesByCategoryIdAsync
        /// </summary>
        [Fact]
        public async void TestGetPropertiesByCategoryIdAsync()
        {
            // Подготовка
            IEnumerable<string[]> properties;

            // Действие
            properties = await repository.GetPropertiesByCategoryIdAsync(1);

            Assert.True(properties.Count() != 0);
            // Утверждение
            foreach (var property in properties)
                Assert.True(property.Length == 4);
        }

        /// <summary>
        /// Проверка метода ADOTransportRepository.GetTransportCategoriesAsync
        /// </summary>
        [Fact]
        public async void TestGetTransportCategoriesAsync()
        {
            // Подготовка
            IEnumerable<string[]> categories;

            // Действие
            categories = await repository.GetTransportCategoriesAsync();

            Assert.True(categories.Count() != 0);
            // Утверждение
            foreach (var category in categories)
                Assert.True(category.Length == 2);
        }

        /// <summary>
        /// Проверка метода ADOTransportRepository.GetTransportCountriesAsync
        /// </summary>
        [Fact]
        public async void TestGetTransportCountriesAsync()
        {
            // Подготовка
            IEnumerable<string[]> countries;

            // Действие
            countries = await repository.GetTransportCountriesAsync();

            Assert.True(countries.Count() != 0);
            // Утверждение
            foreach (var country in countries)
                Assert.True(country.Length == 3);
        }

        /// <summary>
        /// Проверка метода ADOTransportRepository.GetTransportCount
        /// </summary>
        [Fact]
        public async void TestGetTransportCount()
        {
            // Подготовка
            long count;

            // Действие
            count = await repository.GetTransportCount();

            // Утверждение
            Assert.True(count >= 0);
        }
    }
}
