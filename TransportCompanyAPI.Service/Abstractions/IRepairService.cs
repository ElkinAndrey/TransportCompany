using TransportCompanyAPI.Domain.Entities.RepairEntities;

namespace TransportCompanyAPI.Service.Abstractions
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

        /// <summary>
        /// Получить количество ремонтов и их цену 
        /// по марке транспорта за обозначенный период
        /// </summary>
        /// <param name="brandId">Id марка транспорта</param>
        /// <param name="start">Начало отчета</param>
        /// <param name="end">Конец отчета</param>
        /// <returns>
        /// Count - количество ремонтов
        /// Price - общая цена ремонтов
        /// </returns>
        public Task<(long Count, decimal Price)> GetRepairInformationByBrandIdAsync(
            long brandId,
            DateTime? start,
            DateTime? end
        );

        /// <summary>
        /// Получить количество ремонтов и их цену 
        /// по транспорту за обозначенный период
        /// </summary>
        /// <param name="transportId">Id транспорта</param>
        /// <param name="start">Начало отчета</param>
        /// <param name="end">Конец отчета</param>
        /// <returns>
        /// Count - количество ремонтов
        /// Price - общая цена ремонтов
        /// </returns>
        public Task<(long Count, decimal Price)> GetRepairInformationByTransportIdAsync(
            long transportId,
            DateTime? start,
            DateTime? end
        );

        /// <summary>
        /// Количество отримонтированных деталей по конкретной категории
        /// </summary>
        /// <param name="сategoryId">Id категории транспорта</param>
        /// <param name="start">Начало отчета</param>
        /// <param name="end">Конец отчета</param>
        /// <param name="detailsId">Списко с Id деталей, количество которых нужно получить</param>
        /// <returns>Список с деталями и их количествами</returns>
        public Task<IEnumerable<(string Name, long Count)>> GetDetailsByCategoryIdAsync(
            short сategoryId,
            DateTime? start,
            DateTime? end,
            IEnumerable<short> detailsId
        );

        /// <summary>
        /// Количество отримонтированных деталей по конкретной марке транспорта
        /// </summary>
        /// <param name="brandId">Id марки транспорта</param>
        /// <param name="start">Начало отчета</param>
        /// <param name="end">Конец отчета</param>
        /// <param name="detailsId">Списко с Id деталей, количество которых нужно получить</param>
        /// <returns>Список с деталями и их количествами</returns>
        public Task<IEnumerable<(string Name, long Count)>> GetDetailsByBrandIdAsync(
            long brandId,
            DateTime? start,
            DateTime? end,
            IEnumerable<short> detailsId
        );

        /// <summary>
        /// Количество отремонтированных деталей по конкретной Id транспорта
        /// </summary>
        /// <param name="transportId">Id транспорта</param>
        /// <param name="start">Начало отчета</param>
        /// <param name="end">Конец отчета</param>
        /// <param name="detailsId">Списко с Id деталей, количество которых нужно получить</param>
        /// <returns>Список с деталями и их количествами</returns>
        public Task<IEnumerable<(string Name, long Count)>> GetDetailsByTransportIdAsync(
            long transportId,
            DateTime? start,
            DateTime? end,
            IEnumerable<short> detailsId
        );

        /// <summary>
        /// Получить список ремонтов у сотрудника за определенный период
        /// </summary>
        /// <param name="personId">Id сотрудника</param>
        /// <param name="start">Начало отчета</param>
        /// <param name="end">Конец отчета</param>
        /// <returns>Список с часятями ремонта, которые выполняет сотрудник</returns>
        public Task<IEnumerable<RepairPart>> GetRepairByPersonIdAsync(
            long personId,
            DateTime? start,
            DateTime? end
        );

        /// <summary>
        /// Получить список ремонтов у сотрудника за определенный период по указанной автомашине
        /// </summary>
        /// <param name="personId">Id сотрудника</param>
        /// <param name="transportId">Id транспорта</param>
        /// <param name="start">Начало отчета</param>
        /// <param name="end">Конец отчета</param>
        /// <returns>Список с часятями ремонта, которые выполняет сотрудник</returns>
        public Task<IEnumerable<RepairPart>> GetRepairByPersonIdAndTransportIdAsync(
            long personId,
            long transportId,
            DateTime? start,
            DateTime? end
        );

        /// <summary>
        /// Получить список с деталями
        /// </summary>
        /// <returns>Список с деталями</returns>
        public Task<IEnumerable<(short Id, string Name)>> GetDetailsAsync();
    }
}
