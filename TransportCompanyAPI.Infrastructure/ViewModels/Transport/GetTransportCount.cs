using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyAPI.Infrastructure.ViewModels.Transport
{
    /// <summary>
    /// Параметры для получения количества транспорта
    /// </summary>
    public class GetTransportCount
    {
        /// <summary>
        /// Только транспорт, содержащий часть серии
        /// </summary>
        public string Series { get; set; } = "";

        /// <summary>
        /// Только транспорт с таким номером
        /// </summary>
        public string Number { get; set; } = "";

        /// <summary>
        /// Только транспорт, содержащий часть кода региона
        /// </summary>
        public string RegionCode { get; set; } = "";

        /// <summary>
        /// Только транспорт такой страны
        /// </summary>
        public short TransportCountryId { get; set; } = 0;

        /// <summary>
        /// Только транспорт такой категории
        /// </summary>
        public short TransportCategoryId { get; set; } = 0;

        /// <summary>
        /// Начало периода даты начала эксплуатации
        /// </summary>
        public DateTime? StartBuy { get; set; } = null;

        /// <summary>
        /// Конец периода даты начала эксплуатации
        /// </summary>
        public DateTime? EndBuy { get; set; } = null;

        //// <summary>
        /// Начало периода даты начала эксплуатации
        /// </summaray>
        public DateTime? StartWriteOff { get; set; } = null;

        /// <summary>
        /// Конец периода даты окончания эксплуатации
        /// </summary>
        public DateTime? EndWriteOff { get; set; } = null;
    }
}
