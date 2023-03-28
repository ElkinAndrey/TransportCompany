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

        /// <summary>
        /// Репозиторий, отвечающий за работу с людьми
        /// </summary>
        IPersonRepository PersonRepository { get; }

        /// <summary>
        /// Репозиторий, отвечающий за работу с подчиненностью
        /// </summary>
        ISubordinationRepository SubordinationRepository { get; }

        /// <summary>
        /// Репозиторий, отвечающий за работу с ремонтами
        /// </summary>
        IRepairRepository RepairRepository { get; }
    }
}
