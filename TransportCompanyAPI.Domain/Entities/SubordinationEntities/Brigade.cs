using TransportCompanyAPI.Domain.Entities.PersonEntities;
using TransportCompanyAPI.Domain.Entities.TransportEntities;

namespace TransportCompanyAPI.Domain.Entities.SubordinationEntities
{
    /// <summary>
    /// Бригада
    /// </summary>
    public class Brigade
    {
        /// <summary>
        /// Уникальный Id бригады
        /// </summary>
        public long BrigadeId { get; set; }

        /// <summary>
        /// Название бригады
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Бригадир
        /// </summary>
        public Foreman Foreman { get; set; }

        /// <summary>
        /// Участники бригады
        /// </summary>
        public IEnumerable<Person> ServiceStaffs { get; set; }

        /// <summary>
        /// Мастерская бригады
        /// </summary>
        public Workshop Workshop { get; set; }

        /// <summary>
        /// Транспорт, который находится в обслуживанни бригадой
        /// </summary>
        public IEnumerable<Transport> Transports { get; set; }
    }
}
