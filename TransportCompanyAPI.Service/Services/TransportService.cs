using TransportCompanyAPI.Domain.Entities.SubordinationEntities;
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

        public async Task<IEnumerable<string[]>> GetTransportPropertiesByCategoryIdAsync(short categoryId)
        {
            if (categoryId <= 0)
                return new List<string[]>();

            try
            {
                IEnumerable<string[]> properties = await repositoryManager.TransportRepository.GetTransportPropertiesByCategoryIdAsync(categoryId);
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

        public async Task<long> GetTransportCount(
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
            try
            {
                long count = await repositoryManager.TransportRepository.GetTransportCount(
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
                return count;
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
                IEnumerable<string[]> models = await repositoryManager.TransportRepository.GetTransportModelsByCompanyIdAsync(companyId);
                return models;
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
                IEnumerable<string[]> years = await repositoryManager.TransportRepository.GetTransportYearByModelIdAsync(modelId);
                return years;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Dictionary<string, long>> GetGarageFacilityCountByCategoryIdAsync(short categoryId)
        {
            if (categoryId < 0)
                throw new NegativeStartScoreException(categoryId);

            try
            {
                var count = await repositoryManager.TransportRepository.GetGarageFacilityCountByCategoryIdAsync(categoryId);
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CargoTransportation>> GetCargoTransportationsAsync(
            long length, 
            long transportId, 
            DateTime? firstTransportation, 
            DateTime? lastTransportation
        )
        {
            if (length <= 0)
                return new List<CargoTransportation>();

            if (transportId <= 0)
                throw new TransportNotFoundException(transportId);

            try
            {
                var cargoTransportations = await repositoryManager.TransportRepository.GetCargoTransportationsAsync(
                    length, 
                    transportId, 
                    firstTransportation, 
                    lastTransportation
                );
                return cargoTransportations;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> GetMileageByTransportIdAsync(long transportId, DateTime? start, DateTime? end)
        {
            if (start != null && end != null && start > end)
                return 0;

            if (transportId <= 0)
                throw new TransportNotFoundException(transportId);

            try
            {
                var mileage = await repositoryManager.TransportRepository.GetMileageByTransportIdAsync(
                    transportId,
                    start,
                    end
                );
                return mileage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<long> GetMileageByCategoryIdAsync(long categoryId, DateTime? start, DateTime? end)
        {
            if (start != null && end != null && start > end)
                return 0;

            if (categoryId < 0)
                throw new NegativeStartScoreException(categoryId);

            try
            {
                var mileage = await repositoryManager.TransportRepository.GetMileageByCategoryIdAsync(
                    categoryId,
                    start,
                    end
                );
                return mileage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Transport>> GetTransportsByBrigadeIdAsync(long brigadeId)
        {
            if (brigadeId < 0)
                throw new NegativeStartScoreException(brigadeId);

            try
            {
                var transports = await repositoryManager.TransportRepository.GetTransportsByBrigadeIdAsync(brigadeId);
                return transports;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		public async Task<IEnumerable<Transport>> GetDistributionDriversTransportAsync()
        {
            try
            {
				var transports = await repositoryManager.TransportRepository.GetDistributionDriversTransportAsync();
				return transports;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
