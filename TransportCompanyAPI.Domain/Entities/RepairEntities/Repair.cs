using TransportCompanyAPI.Domain.Entities.TransportEntities;

namespace TransportCompanyAPI.Domain.Entities.RepairEntities
{
    /// <summary>
    /// Ремонт
    /// </summary>
    public class Repair
    {
        /// <summary>
        /// Уникальный Id ремонта
        /// </summary>
        public long RepairId { get; set; }

        /// <summary>
        /// Цена ремонта
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Дополнительная информация о ремонте
        /// </summary>
        public string Information { get; set; }

        /// <summary>
        /// Дата начала ремонта
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Дата окончания ремонта
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// Транспорт, который ремонтируют
        /// </summary>
        public Transport Transport { get; set; }

        /// <summary>
        /// Список с частями ремонта
        /// </summary>
        public List<RepairPart> RepairParts { get; set; }
    }
}