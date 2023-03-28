namespace TransportCompanyAPI.Infrastructure.ViewModels.Repair
{
    /// <summary>
    /// Параметры для получения информации 
    /// о ремонтах по категории транспорта
    /// </summary>
    public class GetRepairInformationByCategoryIdViewModel
    {
        /// <summary>
        /// Id категории транспорта
        /// </summary>
        public short CategoryId { get; set; }

        /// <summary>
        /// Начало отчета
        /// </summary>
        public DateTime? Start { get; set; }

        /// <summary>
        /// Конец отчета
        /// </summary>
        public DateTime? End { get; set; }
    }
}
