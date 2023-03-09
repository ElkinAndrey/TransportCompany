using TransportCompanyAPI.Domain.Entities.SubordinationEntities;

namespace TransportCompanyAPI.Domain.Entities.PersonEntities
{
    /// <summary>
    /// Бригадир
    /// </summary>
    public class Foreman : Person
    {
        /// <summary>
        /// Бригада
        /// </summary>
        public Brigade Brigade { get; set; }
    }
}
