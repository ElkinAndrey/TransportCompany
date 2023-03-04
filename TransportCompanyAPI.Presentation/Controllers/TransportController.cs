using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using TransportCompanyAPI.Domain.Entities.TransportEntities;
using TransportCompanyAPI.Domain.Repositories;
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
            var transport = await serviceManager.TransportService.GetTransportByIdAsync(transportId);

            return Ok(transport);
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
                return BadRequest(ModelState);

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

        /// <summary>
        /// Получить список уникальных характеристик транспорта по категории
        /// </summary>
        /// <param name="categoryId">Id категории траспорта</param>
        /// <returns>Список с категориями транспорта</returns>
        [HttpGet]
        [Route("GetPropertiesByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetPropertiesByCategoryId(short categoryId)
        {
            var properties = await serviceManager.TransportService.GetPropertiesByCategoryIdAsync(categoryId);

            return Ok(properties);
        }
    }
}
