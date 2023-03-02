using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyAPI.Persistence.Settings
{
    static public class ADOSettings
    {
        static public string connectionString { get; } =
            "Server = (localdb)\\mssqllocaldb; Database = TransportCompanyDatabase; Trusted_Connection = True";
    }
}
