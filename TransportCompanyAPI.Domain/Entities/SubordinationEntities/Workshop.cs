using TransportCompanyAPI.Domain.Entities.PersonEntities;

namespace TransportCompanyAPI.Domain.Entities.SubordinationEntities
{
    /// <summary>
    /// Мастерская
    /// </summary>
    public class Workshop
    {
        /// <summary>
        /// Уникальный Id мастерской
        /// </summary>
        public long WorkshopId { get; set; }

        /// <summary>
        /// Название мастерской
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Объект гаражного хозяйства
        /// </summary>
        public GarageFacility GarageFacility { get; set; }

        /// <summary>
        /// Бригады в мастерской
        /// </summary>
        public IEnumerable<Brigade> Brigades { get; set; }

        /// <summary>
        /// Мастер в мастерской
        /// </summary>
        public Master Master { get; set; }

        /// <summary>
        /// Участок, на котором располагается мастерская
        /// </summary>
        public Region Region { get; set; }
    }
}
