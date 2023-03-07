using TransportCompanyAPI.Domain.Entities.SubordinationEntities;

namespace TransportCompanyAPI.Domain.Entities.PersonEntities
{
    /// <summary>
    /// Мастер
    /// </summary>
    public class Master : Person
    {
        /// <summary>
        /// Мастерская мастера
        /// </summary>
        public Workshop Workshop { get; set; }
    }
}
