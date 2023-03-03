using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyAPI.Service.Exceptions
{
    public sealed class NegativeStartScoreException : Exception
    {
        public NegativeStartScoreException (long offset) :
            base($"Отчет был начат с {offset}. Число должно быть больше 0.")
        {

        }
    }
}
