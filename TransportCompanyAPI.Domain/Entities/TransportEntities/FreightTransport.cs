namespace TransportCompanyAPI.Domain.Entities.TransportEntities
{
    /// <summary>
    /// Грузовой транспорт
    /// </summary>
    public class FreightTransport : Transport
    {
        /// <summary>
        /// Грузоподьемность (в килограммах)
        /// </summary>
        public int LoadCapacity { get; set; }

        /// <summary>
        /// Высота
        /// </summary>
        public double Height { get; set; }
    }
}
