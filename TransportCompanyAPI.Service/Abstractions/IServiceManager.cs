using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyAPI.Domain.Repositories;

namespace TransportCompanyAPI.Service.Abstractions
{
    /// <summary>
    /// Сервис для связи с остальными сервисами
    /// </summary>
    public interface IServiceManager
    {
        /// <summary>
        /// Сервис, отвечающий за работу с транспортом
        /// </summary>
        ITransportService TransportService { get; }
    }
}
