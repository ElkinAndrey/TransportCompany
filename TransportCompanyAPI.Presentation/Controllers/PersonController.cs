using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using TransportCompanyAPI.Infrastructure.ViewModels.Person;
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

        /// <summary>
        /// Получить людей
        /// </summary>
        /// <param name="model">Параметры отбора</param>
        /// <returns>Список людей</returns>
        [HttpPost]
        [Route("GetPersons")]
        public async Task<IActionResult> GetPersons([FromBody] GetPersonsViewModel model)
        {
            try
            {
                var persons = await serviceManager.PersonService.GetPersonsAsync(
                    model.OffSet,
                    model.Length,
                    model.Name,
                    model.Surname,
                    model.Patronymic,
                    model.PositionId,
                    model.StartHireDate,
                    model.EndHireDate,
                    model.StartDismissalDate,
                    model.EndDismissalDate
                );

                return Ok(persons);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить количество людей
        /// </summary>
        /// <param name="model">Параметры отбора</param>
        /// <returns>Список людей</returns>
        [HttpPost]
        [Route("GetPersonCount")]
        public async Task<IActionResult> GetPersonCount([FromBody] GetPersonCountViewModel model)
        {
            try
            {
                var persons = await serviceManager.PersonService.GetPersonCountAsync(
                    model.Name,
                    model.Surname,
                    model.Patronymic,
                    model.PositionId,
                    model.StartHireDate,
                    model.EndHireDate,
                    model.StartDismissalDate,
                    model.EndDismissalDate
                );

                return Ok(persons);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить все возможные должности людей
        /// </summary>
        /// <returns>
        /// [
        ///     ["1", "Водитель"],
        ///     ["2", "Сварщик"]
        /// ]
        /// </returns>
        [HttpGet]
        [Route("GetPersonPositions")]
        public async Task<IActionResult> GetPersonPositions()
        {
            try
            {
                /*
                var persons = new[] { new { Id = "", Name = "" } }.Skip(1).ToList();

                foreach (var person in await serviceManager.PersonService.GetPersonPositionsAsync())
                    persons.Add(new { Id = person[0], Name = person[1] });

                return Ok(persons);
                */

                var persons = await serviceManager.PersonService.GetPersonPositionsAsync();

                return Ok(persons);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
