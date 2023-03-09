﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportCompanyAPI.Domain.Entities.PersonEntities;
using TransportCompanyAPI.Domain.Entities.SubordinationEntities;
using TransportCompanyAPI.Service.Abstractions;

namespace TransportCompanyAPI.Presentation.Controllers
{
    /// <summary>
    /// Класс для создания запросов с подчиненностью
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SubordinationController : ControllerBase
    {
        /// <summary>
        /// Хранилище с данными
        /// </summary>
        private IServiceManager serviceManager;

        /// <summary>
        /// Контроллер
        /// </summary>
        /// <param name="serviceManager">Хранилище с данными</param>
        public SubordinationController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        /// <summary>
        /// Получить список участков
        /// </summary>
        /// <returns>Список участков</returns>
        [HttpGet]
        [Route("GetRegions")]
        public async Task<IActionResult> GetRegions()
        {
            try
            {
                var regions = await serviceManager.SubordinationService.GetRegionsAsync();

                return Ok(regions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить участок с начальником и списком мастерских на участке
        /// </summary>
        /// <param name="regionId">Id участка, на котором нужно получить мастерские</param>
        /// <returns>Участок</returns>
        [HttpGet]
        [Route("GetRegion/{regionId}")]
        public async Task<IActionResult> GetRegion(long regionId)
        {
            try
            {
                var region = await serviceManager.SubordinationService.GetRegionAsync(regionId);

                return Ok(region);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
