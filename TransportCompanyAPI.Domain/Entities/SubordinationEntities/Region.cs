using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyAPI.Domain.Entities.PersonEntities;

namespace TransportCompanyAPI.Domain.Entities.SubordinationEntities
{
    /// <summary>
    /// Участок
    /// </summary>
    public class Region
    {
        /// <summary>
        /// Уникальный Id участка
        /// </summary>
        public long RegionId { get; set; }

        /// <summary>
        /// Название участка
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Мастерские, которые располагаются на участке
        /// </summary>
        /// public IEnumerable<Workshop> Workshops { get; set; }

        /// <summary>
        /// Начальник участка
        /// </summary>
        public RegionChief RegionChief { get; set; }
    }
}
