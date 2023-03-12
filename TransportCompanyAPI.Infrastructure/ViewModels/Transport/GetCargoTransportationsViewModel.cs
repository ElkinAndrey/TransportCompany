namespace TransportCompanyAPI.Infrastructure.ViewModels.Transport
{
    /// <summary>
    /// Параметры для получения грузоперевозок
    /// </summary>
    public class GetCargoTransportationsViewModel
    {
        /// <summary>
        /// Количество грузоперевозок
        /// </summary>
        public long Length { get; set; } = 100;

        /// <summary>
        /// Уникальныц Id транспорта, у которого получаются грузоперевозки
        /// </summary>
        public long TransportId { get; set; }

        /// <summary>
        /// Начало отчета
        /// </summary>
        public DateTime? FirstTransportation { get; set; } = null;

        /// <summary>
        /// Конец отчета
        /// </summary>
        public DateTime? LastTransportation { get; set; } = null;
    }
}
