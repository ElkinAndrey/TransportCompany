using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyAPI.Service.Exceptions
{
    /// <summary>
    /// Ошибка о том, что длина должна быть не отрицательной
    /// </summary>
    public sealed class NegativeLengthException : Exception
    {
        /// <summary>
        /// Конструкто
        /// </summary>
        /// <param name="length">Длина</param>
        public NegativeLengthException(long length) :
            base($"Длина {length}. Длина должна быть не менее 0.")
        {

        }
    }
}
