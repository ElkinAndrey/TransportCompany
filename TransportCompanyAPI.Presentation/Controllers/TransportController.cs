using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using TransportCompanyAPI.Domain.Entities.TransportEntities;
using TransportCompanyAPI.Infrastructure.ViewModels.Transport;
using TransportCompanyAPI.Service.Abstractions;

namespace TransportCompanyAPI.Presentation.Controllers
{ 
    /// <summary>
    /// Класс для создания запросов с транспортом
    /// </summary>
    [Route("api/[controller]")]
    public class TransportController : Controller
    {
        /// <summary>
        /// Хранилище с данными
        /// </summary>
        private IServiceManager serviceManager;

        /// <summary>
        /// Контроллер
        /// </summary>
        /// <param name="serviceManager">Хранилище с данными</param>
        public TransportController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        /// <summary>
        /// Получение транспотра по id
        /// </summary>
        /// <param name="transportId">id транспорта</param>
        /// <returns>Транспорт</returns>
        [HttpGet]
        [Route("GetTransports/{transportId}")]
        public async Task<IActionResult> GetTransportById(long transportId)
        {
            try
            {
                var transport = await serviceManager.TransportService.GetTransportByIdAsync(transportId);

                return Ok(transport);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Добавление нового транспорта
        /// </summary>
        /// <param name="model">Параметры выбора</param>
        /// <returns>Транспорт</returns>
        [HttpPost]
        [Route("GetTransports")]
        public async Task<IActionResult> GetTransports([FromBody]GetTransportsViewModel model)
        {
            if (model == null)
                return BadRequest("Неверный формат данных");

            try
            {

                var transports = await serviceManager.TransportService.GetTransportsAsync(
                    model.OffSet,
                    model.Length,
                    model.Series,
                    model.Number,
                    model.RegionCode,
                    model.TransportCountryId,
                    model.TransportCategoryId,
                    model.StartBuy,
                    model.EndBuy,
                    model.StartWriteOff,
                    model.EndWriteOff
                );

                return Ok(transports);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить список уникальных характеристик транспорта по категории
        /// </summary>
        /// <param name="categoryId">Id категории траспорта</param>
        /// <returns>Список с категориями транспорта</returns>
        [HttpGet]
        [Route("GetTransportPropertiesByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetTransportPropertiesByCategoryId(short categoryId)
        {
            try
            {
                var properties = await serviceManager.TransportService.GetTransportPropertiesByCategoryIdAsync(categoryId);

                return Ok(properties);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получение всех категорий транспорта в виде словаря 
        /// </summary>
        /// <returns>Словарь, где ключ - это название категории, а значение - это номер категории</returns>
        [HttpGet]
        [Route("GetTransportCategories")]
        public async Task<IActionResult> GetTransportCategories()
        {
            try
            {
                var categiries = await serviceManager.TransportService.GetTransportCategoriesAsync();

                return Ok(categiries);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // <summary>
        /// Получение всех кодов стран в виде словаря (например RUS)
        /// </summary>
        /// <returns>Список стран</returns>
        [HttpGet]
        [Route("GetTransportCountries")]
        public async Task<IActionResult> GetTransportCountries()
        {
            try
            {
                var countries = await serviceManager.TransportService.GetTransportCountriesAsync();

                return Ok(countries);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить список с компаниями, производящими транспорт
        /// </summary>
        /// <returns>
        /// [
        ///     ["1", "ВАЗ"],
        ///     ["2", "BMW"]
        /// ]
        /// </returns>
        [HttpGet]
        [Route("GetTransportCompanies")]
        public async Task<IActionResult> GetTransportCompanies()
        {
            try
            {
                var companies = await serviceManager.TransportService.GetTransportCompaniesAsync();

                return Ok(companies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить список с моделями транспорта по определенной компании
        /// </summary>
        /// <param name="companyId">Номер компании производителя</param>
        /// <returns>
        /// [
        ///     ["1", "RAV4"],
        ///     ["2", "Corolla"]
        /// ]
        /// </returns>
        [HttpGet]
        [Route("GetTransportModels/{companyId}")]
        public async Task<IActionResult> GetTransportModelsByCompanyId(int companyId)
        {
            try
            {
                var models = await serviceManager.TransportService.GetTransportModelsByCompanyIdAsync(companyId);

                return Ok(models);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить все годы издания автомобиля по модели
        /// </summary>
        /// <param name="modelId">Номер модели транспорта</param>
        /// <returns>
        /// [
        ///     ["1", "2005"],
        ///     ["2", "2019"]
        /// ]
        /// </returns>
        [HttpGet]
        [Route("GetTransportYears/{modelId}")]
        public async Task<IActionResult> GetTransportYearByModelId(int modelId)
        {
            try
            {
                var years = await serviceManager.TransportService.GetTransportYearByModelIdAsync(modelId);

                return Ok(years);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить количество транспорта
        /// </summary>
        /// <returns>Количество транспорта</returns>
        [HttpPost]
        [Route("GetTransportCount")]
        public async Task<IActionResult> GetTransportCount([FromBody] GetTransportCountViewModel model)
        {
            try
            {
                var count = await serviceManager.TransportService.GetTransportCount(
                    model.Series,
                    model.Number,
                    model.RegionCode,
                    model.TransportCountryId,
                    model.TransportCategoryId,
                    model.StartBuy,
                    model.EndBuy,
                    model.StartWriteOff,
                    model.EndWriteOff
                );

                return Ok(count);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить количество объектов гаражного хозяйства по категории транспорта
        /// </summary>
        /// <param name="categoryId">Категория транспорта</param>
        /// <returns>Количетво объектов гаражного хозяйства</returns>
        [HttpGet]
        [Route("GetGarageFacilityCountByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetGarageFacilityCountByCategoryId(short categoryId)
        {
            try
            {
                var count = await serviceManager.TransportService.GetGarageFacilityCountByCategoryIdAsync(categoryId);

                return Ok(count);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить все грузоперевозки транспорта по Id транспорта, дате начала и конца
        /// </summary>
        /// <param name="model">Параметры запроса</param>
        /// <returns>Список с грузоперевозками</returns>
        [HttpPost]
        [Route("GetCargoTransportations")]
        public async Task<IActionResult> GetCargoTransportations([FromBody] GetCargoTransportationsViewModel model)
        {
            if (model == null)
                return BadRequest("Неверный формат данных");

            try
            {
                var count = await serviceManager.TransportService.GetCargoTransportationsAsync(
                    model.Length,
                    model.TransportId,
                    model.FirstTransportation,
                    model.LastTransportation
                );

                return Ok(count);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить пробег автомобиля за определенный период
        /// </summary>
        /// <param name="model">Параметры получения пробега</param>
        /// <returns>Пробег</returns>
        [HttpPost]
        [Route("GetMileageByTransportId")]
        public async Task<IActionResult> GetMileageByTransportId([FromBody] GetMileageByTransportIdViewModel model)
        {
            if (model == null)
                return BadRequest("Неверный формат данных");

            try
            {
                var mileage = await serviceManager.TransportService.GetMileageByTransportIdAsync(
                    model.TransportId,
                    model.Start,
                    model.End
                );

                return Ok(mileage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить пробег автомобиля за определенный период
        /// </summary>
        /// <param name="model">Параметры получения пробега</param>
        /// <returns>Пробег</returns>
        [HttpPost]
        [Route("GetMileageByCategoryId")]
        public async Task<IActionResult> GetMileageByCategoryId([FromBody] GetMileageByCategoryIdViewModel model)
        {
            if (model == null)
                return BadRequest("Неверный формат данных");

            try
            {
                var mileage = await serviceManager.TransportService.GetMileageByCategoryIdAsync(
                    model.CategoryId,
                    model.Start,
                    model.End
                );

                return Ok(mileage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Список транспорта по Id бригады
        /// </summary>
        /// <param name="brigadeId">Id бригады</param>
        /// <returns>Список транспорта</returns>
        [HttpGet]
        [Route("GetTransportsByBrigadeId/{brigadeId}")]
        public async Task<IActionResult> GetTransportsByBrigadeId(long brigadeId)
        {
            try
            {
                var transports = await serviceManager.TransportService.GetTransportsByBrigadeIdAsync(brigadeId);

                return Ok(transports);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
