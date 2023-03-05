using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyAPI.Service.Exceptions
{
    /// <summary>
    /// Ошибка о том, что нужно ввести число больше 0
    /// </summary>
    public sealed class NegativeStartScoreException : Exception
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="offset">Начало отчета</param>
        public NegativeStartScoreException (long offset) :
            base($"Отчет был начат с {offset}. Число должно быть больше 0.")
        {

        }
    }
}
