using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyAPI.Domain.Repositories
{
    /// <summary>
    /// Менеджер репозиториев, интерфейс отвечает за управление всеми репозиториями приложения
    /// </summary>
    public interface IRepositoryManager
    {
        /// <summary>
        /// Репозиторий, отвечающий за работу с транспортом
        /// </summary>
        ITransportRepository TransportRepository { get; }
    }
}
