using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyAPI.Domain.Entities.TransportEntities;

namespace TransportCompanyAPI.Domain.Entities.PersonEntities
{
    /// <summary>
    /// Водитель
    /// </summary>
    public class Driver : ServiceStaff
    {
        /// <summary>
        /// Номер водительского удостоверения
        /// </summary>
        public string LicenseNumber { get; set; }

        /// <summary>
        /// Дата выдачи водительского удостоверения
        /// </summary>  
        public DateTime DateIssueLicense { get; set; }

        /// <summary>
        /// Автотранспорт, которым управляет водитель
        /// </summary>
        public IEnumerable<Transport> Transports { get; set;}
    }
}
