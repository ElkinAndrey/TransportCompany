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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<string[]>> GetTransportCompaniesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<string[]>> GetTransportCountriesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<string[]>> GetTransportModelsByCompanyIdAsync(long companyId)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
