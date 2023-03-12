namespace TransportCompanyAPI.Domain.Entities.TransportEntities
{
    /// <summary>
    /// Маршрут
    /// </summary>
    public class Route
    {
        /// <summary>
        /// Уникальный Id маршрута
        /// </summary>
        public long RouteId { get; set; }

        /// <summary>
        /// Номер маршрута
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Список остановок маршрута
        /// </summary>
        public IEnumerable<string> Stops { get; set; }
    }
}
