namespace TransportCompanyAPI.Domain.Entities.TransportEntities
{
    /// <summary>
    /// Автобус
    /// </summary>
    public class Bus : Transport
    {
        /// <summary>
        /// Количество сидячих мест
        /// </summary>
        public int NumberSeats { get; set; }

        /// <summary>
        /// Количество стоячих мест
        /// </summary>
        public int NumberStandingPlaces { get; set; }

        /// <summary>
        /// Количество мест для инвалидов
        /// </summary>
        public int NumberPlacesForDisabled { get; set; }
    }
}
