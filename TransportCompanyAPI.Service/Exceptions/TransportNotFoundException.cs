using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyAPI.Service.Exceptions
{
    public sealed class TransportNotFoundException : Exception
    {
        public TransportNotFoundException(long transportId) :
            base($"Транспорт с Id {transportId} не найден")
        {

        }
    }
}
