namespace TransportCompanyAPI.Domain.Entities.TransportEntities
{
    /// <summary>
    /// Маршрутное такси
    /// </summary>
    public class ShuttleTaxi : Transport
    {
        /// <summary>
        /// Количество сидячих мест
        /// </summary>
        public int NumberSeats { get; set; }
    }
}
