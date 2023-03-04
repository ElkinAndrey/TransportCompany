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
    }
}
