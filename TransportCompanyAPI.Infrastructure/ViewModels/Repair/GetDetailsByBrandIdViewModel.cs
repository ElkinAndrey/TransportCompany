namespace TransportCompanyAPI.Infrastructure.ViewModels.Repair
{
    /// <summary>
    /// Параметры для получения количества деталей по марке транспорта 
    /// </summary>
    public class GetDetailsByBrandIdViewModel
    {
        /// <summary>
        /// Id марки транспорта
        /// </summary>
        public long BrandId { get; set; }

        /// <summary>
        /// Начало отчета
        /// </summary>
        public DateTime? Start { get; set; }

        /// <summary>
        /// Конец отчета
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>
        /// Список с Id деталей, у которых нужно найти количество
        /// </summary>
        public List<short> DetailsId { get; set; } = new List<short>();
    }
}
