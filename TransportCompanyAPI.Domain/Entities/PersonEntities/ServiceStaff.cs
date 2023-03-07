using TransportCompanyAPI.Domain.Entities.SubordinationEntities;

namespace TransportCompanyAPI.Domain.Entities.PersonEntities
{
    /// <summary>
    /// Обслуживающий персонал
    /// </summary>
    public abstract class ServiceStaff : Person
    {
        /// <summary>
        /// Бригада
        /// </summary>
        public Brigade Brigade { get; set; }
    }
}
