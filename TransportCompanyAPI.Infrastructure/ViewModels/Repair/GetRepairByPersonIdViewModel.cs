namespace TransportCompanyAPI.Infrastructure.ViewModels.Repair
{
    /// <summary>
    /// Параметры для получения ремонтов по Id человека
    /// </summary>
    public class GetRepairByPersonIdViewModel
    {
        /// <summary>
        /// Id человека, который совершил ремонты
        /// </summary>
        public long PersonId { get; set; }

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
