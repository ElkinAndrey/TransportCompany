using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportCompanyAPI.Infrastructure.ViewModels.Repair;
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

        /// <summary>
        /// Получить количество ремонтов и их цену 
        /// по категории транспорта за обозначенный период
        /// </summary>
        /// <param name="model">Параметры получения</param>
        /// <returns>
        /// Вернет количество и стоимость
        /// {
        ///     count : 12
        ///     price : 10.1
        /// }
        /// </returns>
        [HttpPost]
        [Route("GetRepairInformationByCategoryId")]
        public async Task<IActionResult> GetRepairInformationByCategoryId(GetRepairInformationByCategoryIdViewModel model)
        {
            try
            {
                var repairInformation = await serviceManager.RepairService.GetRepairInformationByCategoryIdAsync(
                    model.CategoryId, 
                    model.Start, 
                    model.End
                );

                return Ok(new{
                    repairInformation.Count,
                    repairInformation.Price,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить количество ремонтов и их цену 
        /// по марке транспорта за обозначенный период
        /// </summary>
        /// <param name="model">Параметры получения</param>
        /// <returns>
        /// Вернет количество и стоимость
        /// {
        ///     count : 12
        ///     price : 10.1
        /// }
        /// </returns>
        [HttpPost]
        [Route("GetRepairInformationByBrandId")]
        public async Task<IActionResult> GetRepairInformationByBrandId(GetRepairInformationByBrandIdViewModel model)
        {
            try
            {
                var repairInformation = await serviceManager.RepairService.GetRepairInformationByBrandIdAsync(
                    model.BrandId,
                    model.Start,
                    model.End
                );

                return Ok(new
                {
                    repairInformation.Count,
                    repairInformation.Price,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить количество ремонтов и их цену 
        /// по Id транспорта за обозначенный период
        /// </summary>
        /// <param name="model">Параметры получения</param>
        /// <returns>
        /// Вернет количество и стоимость
        /// {
        ///     count : 12
        ///     price : 10.1
        /// }
        /// </returns>
        [HttpPost]
        [Route("GetRepairInformationByTransportId")]
        public async Task<IActionResult> GetRepairInformationByTransportId(GetRepairInformationByTransportIdViewModel model)
        {
            try
            {
                var repairInformation = await serviceManager.RepairService.GetRepairInformationByTransportIdAsync(
                    model.TransportId,
                    model.Start,
                    model.End
                );

                return Ok(new
                {
                    repairInformation.Count,
                    repairInformation.Price,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Количество отремонтированных деталей по конкретной категории
        /// </summary>
        /// <param name="model">Параметры получения</param>
        /// <returns>
        /// Вернет список с названием и количеством
        /// [
        ///     {
        ///         name : "двигатель"
        ///         count : 12
        ///     },
        ///     {
        ///         name : "Колесо"
        ///         count : 10
        ///     }
        /// ]
        /// </returns>
        [HttpPost]
        [Route("GetDetailsByCategoryId")]
        public async Task<IActionResult> GetDetailsByCategoryId(GetDetailsByCategoryIdViewModel model)
        {
            try
            {
                var repairInformation = await serviceManager.RepairService.GetDetailsByCategoryIdAsync(
                    model.CategoryId,
                    model.Start,
                    model.End,
                    model.DetailsId
                );

                return Ok(repairInformation.Select(inf => new
                {
                    inf.Name,
                    inf.Count,
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Количество отремонтированных деталей по конкретной марке транспорта
        /// </summary>
        /// <param name="model">Параметры получения</param>
        /// <returns>
        /// Вернет список с названием и количеством
        /// [
        ///     {
        ///         name : "двигатель"
        ///         count : 12
        ///     },
        ///     {
        ///         name : "Колесо"
        ///         count : 10
        ///     }
        /// ]
        /// </returns>
        [HttpPost]
        [Route("GetDetailsByBrandId")]
        public async Task<IActionResult> GetDetailsByBrandId(GetDetailsByBrandIdViewModel model)
        {
            try
            {
                var repairInformation = await serviceManager.RepairService.GetDetailsByBrandIdAsync(
                    model.BrandId,
                    model.Start,
                    model.End,
                    model.DetailsId
                );

                return Ok(repairInformation.Select(inf => new
                {
                    inf.Name,
                    inf.Count,
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Количество отремонтированных деталей по конкретной автомашине
        /// </summary>
        /// <param name="model">Параметры получения</param>
        /// <returns>
        /// Вернет список с названием и количеством
        /// [
        ///     {
        ///         name : "двигатель"
        ///         count : 12
        ///     },
        ///     {
        ///         name : "Колесо"
        ///         count : 10
        ///     }
        /// ]
        /// </returns>
        [HttpPost]
        [Route("GetDetailsByTransportId")]
        public async Task<IActionResult> GetDetailsByTransportId(GetDetailsByTransportIdViewModel model)
        {
            try
            {
                var repairInformation = await serviceManager.RepairService.GetDetailsByTransportIdAsync(
                    model.TransportId,
                    model.Start,
                    model.End,
                    model.DetailsId
                );

                return Ok(repairInformation.Select(inf => new
                {
                    inf.Name,
                    inf.Count,
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Ремонты, выполенные специалистом за обозначенный период
        /// </summary>
        /// <param name="model">Параметры получения</param>
        /// <returns>
        /// Вернет список с частями ремонта, которые выполнил специалист
        /// </returns>
        [HttpPost]
        [Route("GetRepairByPersonId")]
        public async Task<IActionResult> GetRepairByPersonId(GetRepairByPersonIdViewModel model)
        {
            try
            {
                var repairs = await serviceManager.RepairService.GetRepairByPersonIdAsync(
                    model.PersonId,
                    model.Start,
                    model.End
                );

                return Ok(repairs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Ремонты, выполенные специалистом за обозначенный период по указанной автомашине
        /// </summary>
        /// <param name="model">Параметры получения</param>
        /// <returns>
        /// Вернет список с частями ремонта, которые выполнил специалист
        /// </returns>
        [HttpPost]
        [Route("GetRepairByPersonIdAndTransportId")]
        public async Task<IActionResult> GetRepairByPersonIdAndTransportId(GetRepairByPersonIdAndTransportIdViewModel model)
        {
            try
            {
                var repairs = await serviceManager.RepairService.GetRepairByPersonIdAndTransportIdAsync(
                    model.PersonId,
                    model.TransportId,
                    model.Start,
                    model.End
                );

                return Ok(repairs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
