﻿using System;
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
    }
}