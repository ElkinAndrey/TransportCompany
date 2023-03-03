using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyAPI.Service.Exceptions
{
    public sealed class NegativeLengthException : Exception
    {
        public NegativeLengthException(long length) :
            base($"Длина {length}. Длина должна быть не менее 0.")
        {

        }
    }
}
