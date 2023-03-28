using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyAPI.Infrastructure.ViewModels.Repair
{
    /// <summary>
    /// Параметры для получения количества деталей по категории 
    /// </summary>
    public class GetDetailsByCategoryIdViewModel
    {
        /// <summary>
        /// Id марки транспорта
        /// </summary>
        public short CategoryId { get; set; }

        /// <summary>
        /// Начало отчета
        /// </summary>
        public DateTime? Start { get; set; }

        /// <summary>
        /// Конец отчета
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>
        /// Список с Id деталей, у которых нужно найти количество
        /// </summary>
        public List<short> DetailsId { get; set; } = new List<short>();
    }
}
