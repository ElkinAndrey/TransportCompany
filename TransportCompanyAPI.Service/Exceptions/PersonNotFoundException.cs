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
    public sealed class PersonNotFoundException : Exception
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="personId">Id человека</param>
        public PersonNotFoundException(long personId) :
            base($"Человек с Id {personId} не найден")
        {

        }
    }
}
