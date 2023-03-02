using TransportCompanyAPI.Domain.Entities.TransportEntities;

namespace TransportCompanyAPI.Domain.Repositories
{
    /// <summary>
    /// Интерфейс для работы с транспортом в базе данных.
    /// </summary>
    public interface ITransportRepository
    {
        /// <summary>
        /// Получить срез транспорта
        /// </summary>
        /// <param name="offset">Начало отчета</param>
        /// <param name="length">Длина среда</param>
        /// <param name="series">Серия</param>
        /// <param name="number">Номер</param>
        /// <param name="regionCode">Код региона</param>
        /// <param name="transportCountryId">Id страна госномера</param>
        /// <param name="transportCategoryId">Id категории транспорта</param>
        /// <param name="startBuy">Начало периода даты начала эксплуатации</param>
        /// <param name="endBuy">Конец периода даты начала эксплуатации</param>
        /// <param name="startWriteOff">Начало периода даты окончания эксплуатации</param>
        /// <param name="endWriteOff">Конец периода даты окончания эксплуатации</param>
        /// <returns>Список транспорта</returns>
        public Task<IEnumerable<Transport>> GetTransports(
            long offset,
            long length,
            string series,
            string number,
            string regionCode,
            short transportCountryId,
            short transportCategoryId,
            DateTime startBuy,
            DateTime endBuy,
            DateTime startWriteOff,
            DateTime endWriteOff
        );

        /// <summary>
        /// Получить транспорт по id
        /// </summary>
        /// <param name="id">id транспорта</param>
        /// <returns>транспорт</returns>
        public Task<Transport> GetTransportById(Guid id);

        /// <summary>
        /// Получить все категории транспорта 
        /// </summary>
        /// <returns>
        /// Список с категориями 
        /// [
        ///     ["1", "Такси"],
        ///     ["2", "Автобус"],
        /// ]
        /// </returns>
        public Task<IEnumerable<string[]>> GetTransportCategories();

        /// <summary>
        /// Получить все коды стран
        /// </summary>
        /// <returns>
        /// Список со странами 
        /// [
        ///     ["1", "RUS", "Российская федерация"],
        ///     ["2", "BY", "Белорусь"],
        /// ]
        /// </returns>
        public Task<IEnumerable<string[]>> GetTransportCountries();

        /// <summary>
        /// Получить все компании, производящие транспорт
        /// </summary>
        /// <returns>
        /// Список с компаниями
        /// [
        ///     ["1", "ВАЗ"],
        ///     ["2", "КИА"],
        /// ]
        /// </returns>
        public Task<IEnumerable<string[]>> GetTransportCompanies();

        /// <summary>
        /// Получить все модели транспорта по названию компании
        /// </summary>
        /// <param name="companyId">Номер компании производителя</param>
        /// <returns>
        /// Список с моделями
        /// [
        ///     ["1", "RAW4"],
        ///     ["2", "RAW2"],
        /// ]
        /// </returns>
        public Task<IEnumerable<string[]>> GetTransportModelsByCompanies(int companyId);

        /// <summary>
        /// Получить все годы транспорта по названию компании и модели
        /// </summary>
        /// <param name="modelId">Id модели</param>
        /// <returns>
        /// Список с годами
        /// [
        ///     ["1", "2019"],
        ///     ["2", "2016"],
        /// ]
        /// </returns>
        public Task<IEnumerable<string[]>> GetTransportYearByModel(int modelId);

        /// <summary>
        /// Получить список всех уникальных характеристик транспорта по категории
        /// </summary>
        /// <returns>
        /// Список с уникальными характеристиками
        /// [
        ///     ["1", "Heigth"],
        ///     ["2", "Width"],
        /// ]
        /// </returns>
        public Task<IEnumerable<string[]>> GetPropertiesByCategoryId();
    }
}
