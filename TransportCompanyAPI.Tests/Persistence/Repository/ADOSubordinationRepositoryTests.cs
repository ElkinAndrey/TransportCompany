using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyAPI.Domain.Entities.PersonEntities;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Persistence.Repositories;
using TransportCompanyAPI.Persistence.Settings;
using TransportCompanyAPI.Persistence;
using Xunit;
using TransportCompanyAPI.Domain.Entities.SubordinationEntities;

namespace TransportCompanyAPI.Tests.Persistence.Repository
{
    /// <summary>
    /// Тесты класса ADOSubordinationRepository
    /// </summary>
    public class ADOSubordinationRepositoryTests
    {
        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        private string connectionString = ADOSettings.connectionString;

        /// <summary>
        /// Реопзиторий для работы с транспортом
        /// </summary>
        private readonly ISubordinationRepository repository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ADOSubordinationRepositoryTests()
        {
            SqlConnection connection = new(connectionString);
            SqlQueries sqlQueries = new SqlQueries(connection);
            repository = new ADOSubordinationRepository(sqlQueries);
        }

        /// <summary>
        /// Проверка метода ADOSubordinationRepository.GetRegionsAsync
        /// </summary>
        [Fact]
        public async void TestGetRegionsAsync()
        {

            // Подготовка
            List<Region> regions;

            // Действие
            regions = (await repository.GetRegionsAsync()).ToList();

            // Утверждение
            foreach (Region transport in regions)
            {
                Assert.True(transport.RegionId != 0);
            }
        }

        /// <summary>
        /// Проверка метода ADOSubordinationRepository.GetRegionAsync
        /// </summary>
        [Fact]
        public async void TestGetRegionAsync()
        {

            // Подготовка
            Region region;

            // Действие
            region = (await repository.GetRegionAsync(1));

            // Утверждение
            Assert.True(region.RegionId != 0);
        }

        /// <summary>
        /// Проверка метода ADOSubordinationRepository.GetWorkshopAsync
        /// </summary>
        [Fact]
        public async void TestGetWorkshopAsync()
        {

            // Подготовка
            Workshop workshop;

            // Действие
            workshop = (await repository.GetWorkshopAsync(1));

            // Утверждение
            Assert.True(workshop.WorkshopId != 0);
        }

        /// <summary>
        /// Проверка метода ADOSubordinationRepository.GetBrigadeAsync
        /// </summary>
        [Fact]
        public async void TestGetBrigadeAsync()
        {

            // Подготовка
            Brigade brigade;

            // Действие
            brigade = (await repository.GetBrigadeAsync(1));

            // Утверждение
            Assert.True(brigade.BrigadeId != 0);
        }

        /// <summary>
        /// Проверка метода ADOSubordinationRepository.GetSubordinationCountAsync
        /// </summary>
        [Fact]
        public async void TestGetSubordinationCountAsync()
        {

            // Подготовка
            SubordinationCount subordinationCount;
            
            // Действие
            subordinationCount = await repository.GetSubordinationCountAsync(0, 0, 0);

            // Утверждение
            Assert.True(subordinationCount.RegionCount >= 0);
            Assert.True(subordinationCount.WorkshopCount >= 0);
            Assert.True(subordinationCount.BrigadeCount >= 0);
            Assert.True(subordinationCount.PersonCount >= 0);
        }
    }
}
