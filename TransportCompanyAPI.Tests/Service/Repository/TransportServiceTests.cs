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
using TransportCompanyAPI.Service.Abstractions;
using TransportCompanyAPI.Service.Services;
using TransportCompanyAPI.Domain.Entities.TransportEntities;
using TransportCompanyAPI.Service.Exceptions;

namespace TransportCompanyAPI.Tests.Service.Repository
{
    /// <summary>
    /// Тесты класса TransportService
    /// </summary>
    public class TransportServiceTests
    {
        /// <summary>
        /// Реопзиторий для работы с транспортом
        /// </summary>
        private readonly ITransportService transportService;

        /// <summary>
        /// Конструктор
        /// </summary>
        public TransportServiceTests()
        {
            IRepositoryManager repositoryManager = new RepositoryManager();
            transportService = new TransportService(repositoryManager);
        }

        /// <summary>
        /// Проверка метода TransportService.GetTransportsAsync
        /// </summary>
        [Fact]
        public async void TestGetTransportsAsync()
        {

            // Подготовка
            List<Transport> transports;

            // Действие
            try
            {
                transports = (await transportService.GetTransportsAsync(-1, 1, "", "", "", 0, 0, null, null, null, null)).ToList();
            }
            catch(Exception ex) 
            {
                Assert.Equal(ex.Message, new NegativeStartScoreException(-1).Message);
            }

            try
            {
                transports = (await transportService.GetTransportsAsync(1, -1, "", "", "", 0, 0, null, null, null, null)).ToList();
            }
            catch (Exception ex)
            {
                Assert.Equal(ex.Message, new NegativeLengthException(-1).Message);
            }

            transports = (await transportService.GetTransportsAsync(1, 1, "11111111111111", "", "", 0, 0, null, null, null, null)).ToList();
        }

        /// <summary>
        /// Проверка метода TransportService.GetTransportByIdAsync
        /// </summary>
        [Fact]
        public async void TestGetTransportByIdAsync()
        {

            // Подготовка
            Transport transports;

            // Действие
            try
            {
                transports = await transportService.GetTransportByIdAsync(-1);
            }
            catch (Exception ex)
            {
                Assert.Equal(ex.Message, new TransportNotFoundException(-1).Message);
            }

            try
            {
                transports = await transportService.GetTransportByIdAsync(long.MaxValue);
            }
            catch (Exception ex)
            {
                Assert.Equal(ex.Message, new TransportNotFoundException(long.MaxValue).Message);
            }
        }

        /// <summary>
        /// Проверка метода TransportService.GetPropertiesByCategoryIdAsync
        /// </summary>
        [Fact]
        public async void TestGetPropertiesByCategoryIdAsync()
        {

            // Подготовка
            IEnumerable<string[]> properties;

            // Действие
            properties = await transportService.GetPropertiesByCategoryIdAsync(-1);
            Assert.True(properties.Count() == 0);
            properties = await transportService.GetPropertiesByCategoryIdAsync(short.MaxValue);
            Assert.True(properties.Count() == 0);
        }
    }
}
