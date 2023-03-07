namespace TransportCompanyAPI.Domain.Entities.SubordinationEntities
{
    /// <summary>
    /// Количества подчиненных
    /// </summary>
    public class SubordinationCount
    {
        /// <summary>
        /// Количество участков
        /// </summary>
        public long? RegionCount { get; set; }

        /// <summary>
        /// Количество мастерских
        /// </summary>
        public long? WorkshopCount { get; set; }

        /// <summary>
        /// Количество бригад
        /// </summary>
        public long? BrigadeCount { get; set; }

        /// <summary>
        /// Количество подчиненных
        /// </summary>
        public long? PersonCount { get; set; }

    }
}
