using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyAPI.Domain.Entities.TransportEntities;

namespace TransportCompanyAPI.Service.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса для работы с транспортом 
    /// </summary>
    public interface ITransportService
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
        public Task<IEnumerable<Transport>> GetTransportsAsync(
            long offset,
            long length,
            string series,
            string number,
            string regionCode,
            short transportCountryId,
            short transportCategoryId,
            DateTime? startBuy,
            DateTime? endBuy,
            DateTime? startWriteOff,
            DateTime? endWriteOff
        );

        /// <summary>
        /// Получить транспорт по id
        /// </summary>
        /// <param name="id">id транспорта</param>
        /// <returns>транспорт</returns>
        public Task<Transport> GetTransportByIdAsync(long id);

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
        public Task<IEnumerable<string[]>> GetTransportCategoriesAsync();

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
        public Task<IEnumerable<string[]>> GetTransportCountriesAsync();

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
        public Task<IEnumerable<string[]>> GetTransportCompaniesAsync();

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
        public Task<IEnumerable<string[]>> GetTransportModelsByCompanyIdAsync(long companyId);

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
        public Task<IEnumerable<string[]>> GetTransportYearByModelIdAsync(long modelId);

        /// <summary>
        /// Получить список всех уникальных характеристик транспорта по категории
        /// </summary>
        /// <returns>
        /// Список с уникальными характеристиками
        /// [
        ///     ["1", "Heigth", "Высота", "FLOAT"],
        ///     ["2", "Width", "Ширина", "FLOAT"],
        /// ]
        /// </returns>
        public Task<IEnumerable<string[]>> GetTransportPropertiesByCategoryIdAsync(short categoryId);

        /// <summary>
        /// Получить количество транспорта
        /// </summary>
        /// <param name="series">Серия</param>
        /// <param name="number">Номер</param>
        /// <param name="regionCode">Код региона</param>
        /// <param name="transportCountryId">Id страна госномера</param>
        /// <param name="transportCategoryId">Id категории транспорта</param>
        /// <param name="startBuy">Начало периода даты начала эксплуатации</param>
        /// <param name="endBuy">Конец периода даты начала эксплуатации</param>
        /// <param name="startWriteOff">Начало периода даты окончания эксплуатации</param>
        /// <param name="endWriteOff">Конец периода даты окончания эксплуатации</param>
        /// <returns>Количество транспорта</returns>
        public Task<long> GetTransportCount(
            string series,
            string number,
            string regionCode,
            short transportCountryId,
            short transportCategoryId,
            DateTime? startBuy,
            DateTime? endBuy,
            DateTime? startWriteOff,
            DateTime? endWriteOff
        );

        /// <summary>
        /// Получить количество объектов гаражного хозяйства по категории транспорта
        /// </summary>
        /// <param name="categoryId">Категория транспорта</param>
        /// <returns>Количетво объектов гаражного хозяйства</returns>
        public Task<Dictionary<string, long>> GetGarageFacilityCountByCategoryIdAsync(short categoryId);

        /// <summary>
        /// Получить грузоперевозки за указанный период
        /// </summary>
        /// <param name="length">Количество грузоперевозок</param>
        /// <param name="transportId">Уникальныц Id транспорта, у которого получаются грузоперевозки</param>
        /// <param name="firstTransportation">Начало отчета</param>
        /// <param name="lastTransportation">Конец отчета</param>
        /// <returns>Список с транспортировками</returns>
        public Task<IEnumerable<CargoTransportation>> GetCargoTransportationsAsync(
            long length,
            long transportId,
            DateTime? firstTransportation,
            DateTime? lastTransportation
        );

        /// <summary>
        /// Получить пробег автомобиля за определенный период
        /// </summary>
        /// <param name="transportId">Id траспорта</param>
        /// <param name="start">Начало отчета</param>
        /// <param name="end">Конец отчета</param>
        /// <returns>Пробег</returns>
        public Task<int> GetMileageByTransportIdAsync(long transportId, DateTime? start, DateTime? end);
    }
}
