namespace TransportCompanyAPI.Infrastructure.ViewModels.Repair
{
    /// <summary>
    /// Параметры для получения ремонтов по Id человека и id транспорта
    /// </summary>
    public class GetRepairByPersonIdAndTransportIdViewModel
    {
        /// <summary>
        /// Id человека, который совершил ремонты
        /// </summary>
        public long PersonId { get; set; }

        /// <summary>
        /// Id транспорта, над которым совершали ремонты
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
