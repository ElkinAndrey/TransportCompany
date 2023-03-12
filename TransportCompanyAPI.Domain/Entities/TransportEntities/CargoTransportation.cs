namespace TransportCompanyAPI.Domain.Entities.TransportEntities
{
    /// <summary>
    /// Грузоперевозка
    /// </summary>
    public class CargoTransportation
    {
        /// <summary>
        /// Уникальный Id грузоперевозки
        /// </summary>
        public long CargoTransportationId { get; set; }

        /// <summary>
        /// Цена грузоперевозки
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Дополнительные сведенья о грузоперевозке
        /// </summary>
        public string AdditionalInformation { get; set; }

        /// <summary>
        /// Дата начала грузоперевозки
        /// </summary>
        public DateTime StartTransportation { get; set; }

        /// <summary>
        /// Дата окончания грузоперевозки
        /// </summary>
        public DateTime? EndTransportation { get; set; }

        /// <summary>
        /// Грузовой транспорт, совершивший грузоперевозку
        /// </summary>
        public FreightTransport? FreightTransport { get; set; }
    }
}
