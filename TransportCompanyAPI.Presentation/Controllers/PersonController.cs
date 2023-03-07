using Microsoft.AspNetCore.Mvc;
using TransportCompanyAPI.Service.Abstractions;

namespace TransportCompanyAPI.Presentation.Controllers
{
    /// <summary>
    /// Класс для создания запросов с людьми
    /// </summary>
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        /// <summary>
        /// Хранилище с данными
        /// </summary>
        private IServiceManager serviceManager;

        /// <summary>
        /// Контроллер
        /// </summary>
        /// <param name="serviceManager">Хранилище с данными</param>
        public PersonController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        /// <summary>
        /// Получение транспотра по id
        /// </summary>
        /// <param name="personId">id транспорта</param>
        /// <returns>Транспорт</returns>
        [HttpGet]
        [Route("GetPerson/{personId}")]
        public async Task<IActionResult> GetPersonById(long personId)
        {
            try
            {
                var person = await serviceManager.PersonService.GetPersonByIdAsync(personId);

                return Ok(person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
