using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyAPI.Domain.Entities.SubordinationEntities
{
    /// <summary>
    /// Объект гаражного хозяйства (гараж, цех, бокс), где 
    /// находятся транспортные средства и мастерская 
    /// </summary>
    public class GarageFacility
    {
        /// <summary>
        /// Уникальный Id объекта гаражного хозяйства
        /// </summary>
        public long GarageFacilityId { get; set; }

        /// <summary>
        /// Адрес объекта гаражного хозяйства
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Категория объекта гаражного хозяйства
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Мастерская, которая располагается в объекте гаражного хозяйства
        /// </summary>
        public Workshop Workshop { get; set; }
    }
}
