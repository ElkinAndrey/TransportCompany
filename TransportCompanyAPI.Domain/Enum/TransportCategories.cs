using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyAPI.Domain.Enum
{
    /// <summary>
    /// Категории транспорта
    /// </summary>
    public enum TransportCategories : int
    {
        /// <summary>
        /// Автобус
        /// </summary>
        Bus = 1,

        /// <summary>
        /// Такси
        /// </summary>
        Taxi = 2,

        /// <summary>
        /// Маршртное такси
        /// </summary>
        ShuttleTaxi = 3,

        /// <summary>
        /// Грузовой транспорт
        /// </summary>
        FreightTransport = 4,

        /// <summary>
        /// Вспомогательный транспорт
        /// </summary>
        CargoTransportation = 5,
    }
}
