using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyAPI.Infrastructure.ViewModels.Transport
{
    /// <summary>
    /// Параметры для получения пробега транспорта
    /// </summary>
    public class GetMileageByTransportIdViewModel
    {
        /// <summary>
        /// Уникальный Id транспорта, у которого нужно найти пробег
        /// </summary>
        public long TransportId { get; set; }

        /// <summary>
        /// Начало отчета
        /// </summary>
        public DateTime? Start { get; set; }

        /// <summary>
        /// Конец отчета
        /// </summary>
        public DateTime? End { get; set; }
    }
}
