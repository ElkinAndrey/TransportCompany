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
    }
}
