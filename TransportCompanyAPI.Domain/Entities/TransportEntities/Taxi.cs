namespace TransportCompanyAPI.Domain.Entities.TransportEntities
{
    /// <summary>
    /// Такси
    /// </summary>
    public class Taxi : Transport
    {
        /// <summary>
        /// Количество сидячих мест
        /// </summary>
        public int NumberSeats { get; set; }
    }
}
