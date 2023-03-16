namespace TransportCompanyAPI.Infrastructure.ViewModels.Transport
{
    /// <summary>
    /// Параметры для получения пробега транспорта по категории
    /// </summary>
    public class GetMileageByCategoryIdViewModel
    {
        /// <summary>
        /// Уникальный Id категории транспорта, у которой нужно найти пробег
        /// </summary>
        public long CategoryId { get; set; }

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
