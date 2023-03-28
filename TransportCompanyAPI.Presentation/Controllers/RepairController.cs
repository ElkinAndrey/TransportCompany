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
    }
}
