using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyAPI.Persistence.Features
{
    static class Helpers
    {
        /// <summary>
        /// Перевести время из DateTime в формат ISO8601 
        /// (например 2023-01-23T02:45:01.548)
        /// </summary>
        /// <param name="date">Дата и время</param>
        /// <returns>Строка с датой в формате ISO8601</returns>
        static public string ConvertDateTimeInISO8601(DateTime? date)
        {
            if (date == null)
                return "";

            DateTime dateNotNull = (DateTime)date;
            return $"{dateNotNull.Year}-{dateNotNull.Month.ToString("D2")}-{dateNotNull.Day.ToString("D2")}T{dateNotNull.Hour.ToString("D2")}:{dateNotNull.Minute.ToString("D2")}:{dateNotNull.Second.ToString("D2")}.{dateNotNull.Millisecond.ToString("D3")}";
        }
    }
}
