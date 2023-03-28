﻿namespace TransportCompanyAPI.Service.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса для работы с ремонтом 
    /// </summary>
    public interface IRepairService
    {
        /// <summary>
        /// Получить количество ремонтов и их цену 
        /// по категории транспорта за обозначенный период
        /// </summary>
        /// <param name="сategoryId">Id категории транспорта</param>
        /// <param name="start">Начало отчета</param>
        /// <param name="end">Конец отчета</param>
        /// <returns>
        /// Count - количество ремонтов
        /// Price - общая цена ремонтов
        /// </returns>
        public Task<(long Count, decimal Price)> GetRepairInformationByCategoryIdAsync(
            short сategoryId,
            DateTime? start,
            DateTime? end
        );
    }
}