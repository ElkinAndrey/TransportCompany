using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyAPI.Infrastructure.ViewModels.Subordination
{
    /// <summary>
    /// Параметры для получения количества подчиненных
    /// </summary>
    public class GetSubordinationCountViewModel
    {
        /// <summary>
        /// Уникальный Id участка
        /// </summary>
        public long RegionId { get; set; } = 0;

        /// <summary>
        /// Уникальный Id мастерской
        /// </summary>
        public long WorkshopId { get; set; } = 0;

        /// <summary>
        /// Уникальный Id участка
        /// </summary>
        public long BrigadeId { get; set; } = 0;
    }
}
