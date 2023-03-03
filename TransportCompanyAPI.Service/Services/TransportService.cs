using System.Data.SqlClient;
using TransportCompanyAPI.Domain.Entities.TransportEntities;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Service.Abstractions;
using TransportCompanyAPI.Service.Exceptions;

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

        public Task<IEnumerable<string[]>> GetPropertiesByCategoryIdAsync(short categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<Transport> GetTransportByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string[]>> GetTransportCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string[]>> GetTransportCompaniesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string[]>> GetTransportCountriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string[]>> GetTransportModelsByCompanyIdAsync(long companyId)
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
            if (offset <= 0 )
                throw new NegativeStartScoreException(offset);

            if (length < 0)
                throw new NegativeLengthException(length);

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

        public Task<IEnumerable<string[]>> GetTransportYearByModelIdAsync(long modelId)
        {
            throw new NotImplementedException();
        }
    }
}
