using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyAPI.Domain.Enum
{
    /// <summary>
    /// Должности человека
    /// </summary>
    public enum PersonPositions : int
    {
        /// <summary>
        /// Водитель
        /// </summary>
        Driver = 1,

        /// <summary>
        /// Техник
        /// </summary>
        Technician = 2,

        /// <summary>
        /// Сварщик
        /// </summary>
        Welder = 3,

        /// <summary>
        /// Слесарь
        /// </summary>
        Locksmith = 4,

        /// <summary>
        /// Бригадир
        /// </summary>
        Foreman = 5,

        /// <summary>
        /// Мастер
        /// </summary>
        Master = 6,

        /// <summary>
        /// Начальник участка
        /// </summary>
        RegionChief = 7,
    }
}
