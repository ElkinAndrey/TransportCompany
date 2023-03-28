namespace TransportCompanyAPI.Infrastructure.ViewModels.Repair
{
    /// <summary>
    /// Параметры для получения информации 
    /// о ремонтах по марке транспорта
    /// </summary>
    public class GetRepairInformationByTransportIdViewModel
    {
        /// <summary>
        /// Id марки транспорта
        /// </summary>
        public long TransportId { get; set; }

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
