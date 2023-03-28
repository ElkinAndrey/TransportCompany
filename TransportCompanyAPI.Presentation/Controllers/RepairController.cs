using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportCompanyAPI.Service.Abstractions;

namespace TransportCompanyAPI.Presentation.Controllers
{
    /// <summary>
    /// Класс для создания запросов с ремонтами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RepairController : ControllerBase
    {
        /// <summary>
        /// Хранилище с данными
        /// </summary>
        private IServiceManager serviceManager;

        /// <summary>
        /// Контроллер
        /// </summary>
        /// <param name="serviceManager">Хранилище с данными</param>
        public RepairController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }
    }
}
