using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyAPI.Domain.Entities.TransportEntities
{
    /// <summary>
    /// Транспортное средство
    /// </summary>
    public class Transport
    {
        /// <summary>
        /// Уникальный Id Транспортного средства
        /// </summary>
        public long TransportId { get; set; } = 0;

        /// <summary>
        /// Серия (например, ААА)
        /// </summary>
        public string Series { get; set; } = "";

        /// <summary>
        /// Государственный номер (например, 731)
        /// </summary>
        public string Number { get; set; } = "";

        /// <summary>
        /// Код региона (например, 59 в россии и AA в украине)
        /// </summary>
        public string RegionCode { get; set; } = "";

        /// <summary>
        /// Дата начала эксплуатации (покупка)
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Дата окончания эксплуатации (списание)
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>
        /// Пробег транспортного средства (в километрах)
        /// </summary>
        public int Mileage { get; set; } = 0;

        /// <summary>
        /// Категория транспорта (например грузовой)
        /// </summary>
        public string Category { get; set; } = "";

        /// <summary>
        /// Код страны (например RUS)
        /// </summary>
        public string CountryCode { get; set; } = "";

        /// <summary>
        /// Расшифровка кода страны (например Россия)
        /// </summary>
        public string DecipheringCountry { get; set; } = "";

        /// <summary>
        /// Компания произоводитель транспортного средства
        /// </summary>
        public string ManufacturerCompany { get; set; } = "";

        /// <summary>
        /// Модель транспорта
        /// </summary>
        public string TransportModel { get; set; } = "";

        /// <summary>
        /// Год издания транспорта
        /// </summary>
        public int YearPublishing { get; set; } = 0; 
    }
}
