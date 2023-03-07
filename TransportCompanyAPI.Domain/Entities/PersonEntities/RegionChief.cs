using TransportCompanyAPI.Domain.Entities.SubordinationEntities;

namespace TransportCompanyAPI.Domain.Entities.PersonEntities
{
    /// <summary>
    /// Начальник участка
    /// </summary>
    public class RegionChief : Person
    {
        /// <summary>
        /// Участок
        /// </summary>
        public Region Region { get; set; }
    }
}
