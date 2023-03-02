using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyAPI.Domain.Entities.TransportEntities;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Persistence.Repositories;
using Xunit;

namespace TransportCompanyAPI.Tests.Persistence.Repository
{
    public class ADOTransportRepositoryTests
    {
        /// <summary>
        /// Проверка метода ADOTransportRepository.GetTransportsAsync
        /// </summary>
        [Fact]
        public async void TestGetTransportsAsync()
        {

            // Подготовка
            ITransportRepository repository = new ADOTransportRepository();
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
            ITransportRepository repository = new ADOTransportRepository();
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
            ITransportRepository repository = new ADOTransportRepository();
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
            ITransportRepository repository = new ADOTransportRepository();
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
            ITransportRepository repository = new ADOTransportRepository();
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
            ITransportRepository repository = new ADOTransportRepository();
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
            ITransportRepository repository = new ADOTransportRepository();
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
            ITransportRepository repository = new ADOTransportRepository();
            IEnumerable<string[]> countries;

            // Действие
            countries = await repository.GetTransportCountriesAsync();

            Assert.True(countries.Count() != 0);
            // Утверждение
            foreach (var country in countries)
                Assert.True(country.Length == 3);
        }
    }
}
