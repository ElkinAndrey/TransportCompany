using TransportCompanyAPI.Domain.Entities.SubordinationEntities;

namespace TransportCompanyAPI.Domain.Repositories
{
    /// <summary>
    /// Интерфейс для работы с подчиненностью персонала в базе данных
    /// </summary>
    public interface ISubordinationRepository
    {
        /// <summary>
        /// Получить список участков
        /// </summary>
        /// <returns>Список участков</returns>
        public Task<IEnumerable<Region>> GetRegions();

        /// <summary>
        /// Получить участок с начальником и списком мастерских на участке
        /// </summary>
        /// <param name="regionId">Id участка, на котором нужно получить мастерские</param>
        /// <returns>Участок</returns>
        public Task<Region> GetRegion(long regionId);

        /// <summary>
        /// Получить мастерскую с мастером и списком бригад в мастерской
        /// </summary>
        /// <param name="workshopId">Id мастерской</param>
        /// <returns>Мастерская</returns>
        public Task<Workshop> GetWorkshop(long workshopId);

        /// <summary>
        /// Получить бригаду с бригадиром и списком работников бригады
        /// </summary>
        /// <param name="brigadeId">Id мастерской</param>
        /// <returns>Бригада</returns>
        public Task<Brigade> GetBrigade(long brigadeId);

        /// <summary>
        /// Получить колчиество подчиненных 
        /// </summary>
        /// <param name="RegionId">Id участка</param>
        /// <param name="WorkshopId">Id мастерской</param>
        /// <param name="BrigadeId">Id бригады</param>
        /// <returns>Количество подчиненных</returns>
        public Task<SubordinationCount> GetSubordinationCount(long RegionId, long WorkshopId, long BrigadeId);
    }
}
