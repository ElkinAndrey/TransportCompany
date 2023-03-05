using System.ComponentModel.Design;
using System.Data.SqlClient;
using TransportCompanyAPI.Domain.Entities.TransportEntities;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Service.Abstractions;
using TransportCompanyAPI.Service.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TransportCompanyAPI.Service.Services
{
    /// <summary>
    /// Сервис для работы с транспортом
    /// </summary>
    public class TransportService : ITransportService
    {
        /// <summary>
        /// Репозитории
        /// </summary>
        private readonly IRepositoryManager repositoryManager;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repositoryManager"></param>
        public TransportService(IRepositoryManager repositoryManager)
        { 
           this.repositoryManager = repositoryManager; 
        }

        public async Task<IEnumerable<string[]>> GetPropertiesByCategoryIdAsync(short categoryId)
        {
            if (categoryId <= 0)
                return new List<string[]>();

            try
            {
                IEnumerable<string[]> properties = await repositoryManager.TransportRepository.GetPropertiesByCategoryIdAsync(categoryId);
                return properties;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Transport> GetTransportByIdAsync(long id)
        {
            if (id <= 0)
                throw new TransportNotFoundException(id);

            try
            {
                Transport transport = await repositoryManager.TransportRepository.GetTransportByIdAsync(id);
                return transport;
            }
            catch (Exception ex)
            {
                throw new TransportNotFoundException(id);
            }
        }

        public async Task<IEnumerable<string[]>> GetTransportCategoriesAsync()
        {
            try
            {
                IEnumerable<string[]> categories = await repositoryManager.TransportRepository.GetTransportCategoriesAsync();
                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<string[]>> GetTransportCompaniesAsync()
        {
            try
            {
                IEnumerable<string[]> companies = await repositoryManager.TransportRepository.GetTransportCompaniesAsync();
                return companies;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<string[]>> GetTransportCountriesAsync()
        {
            try
            {
                IEnumerable<string[]> countries = await repositoryManager.TransportRepository.GetTransportCountriesAsync();
                return countries;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<string[]>> GetTransportModelsByCompanyIdAsync(long companyId)
        {
            if (companyId <= 0)
                throw new NegativeStartScoreException(companyId);

            try
            {
                IEnumerable<string[]> companies = await repositoryManager.TransportRepository.GetTransportCompaniesAsync();
                return companies;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Transport>> GetTransportsAsync(
            long offset, 
            long length, 
            string series, 
            string number, 
            string regionCode, 
            short transportCountryId, 
            short transportCategoryId, 
            DateTime? startBuy, 
            DateTime? endBuy, 
            DateTime? startWriteOff, 
            DateTime? endWriteOff
        )
        {
            if (offset < 0 )
                throw new NegativeStartScoreException(offset);

            if (length < 0)
                throw new NegativeLengthException(length);

            if (length == 0)
                return new List<Transport>();

            try
            {
                IEnumerable<Transport> transports = await repositoryManager.TransportRepository.GetTransportsAsync(
                offset,
                length,
                series,
                number,
                regionCode,
                transportCountryId,
                transportCategoryId,
                startBuy,
                endBuy,
                startWriteOff,
                endWriteOff
            );
                return transports;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<string[]>> GetTransportYearByModelIdAsync(long modelId)
        {
            if (modelId <= 0)
                throw new NegativeStartScoreException(modelId);

            try
            {
                IEnumerable<string[]> models = await repositoryManager.TransportRepository.GetTransportCompaniesAsync();
                return models;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
