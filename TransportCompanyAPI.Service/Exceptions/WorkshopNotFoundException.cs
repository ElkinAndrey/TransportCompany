using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyAPI.Service.Exceptions
{
    /// <summary>
    /// Мастерская не найдена
    /// </summary>
    public sealed class WorkshopNotFoundException : Exception
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="workshopId">Id мастерской</param>
        public WorkshopNotFoundException(long workshopId) :
            base($"Мастерская с Id {workshopId} не найден")
        {

        }
    }
}
