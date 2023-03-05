using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyAPI.Service.Exceptions
{
    /// <summary>
    /// Транспорт не найден
    /// </summary>
    public sealed class TransportNotFoundException : Exception
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="transportId">Id транспорта</param>
        public TransportNotFoundException(long transportId) :
            base($"Транспорт с Id {transportId} не найден")
        {

        }
    }
}
