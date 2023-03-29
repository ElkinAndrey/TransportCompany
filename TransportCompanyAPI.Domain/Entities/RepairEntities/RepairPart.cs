using TransportCompanyAPI.Domain.Entities.PersonEntities;

namespace TransportCompanyAPI.Domain.Entities.RepairEntities
{
    /// <summary>
    /// Часть ремонта
    /// </summary>
    public class RepairPart
    {
        /// <summary>
        /// Ремонтируемая деталь
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// Выполненное действие
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Человек, выполнивший часть ремонта
        /// </summary>
        public Person Person { get; set; }

        /// <summary>
        /// Ремонт к которому относится часть ремонта
        /// </summary>
        public Repair Repair { get; set; }
    }
}
