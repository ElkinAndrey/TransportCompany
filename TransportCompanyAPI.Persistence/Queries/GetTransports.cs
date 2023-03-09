using System.Data;
using TransportCompanyAPI.Domain.Entities.TransportEntities;
using TransportCompanyAPI.Persistence.Features;

namespace TransportCompanyAPI.Persistence.Queries
{

    /// <summary>
    /// Получить список транспорта
    /// </summary>
    public class GetTransports
    {
        /// <summary>
        /// Объект для отправки SQL запросов
        /// </summary>
        private SqlQueries sqlQueries;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sqlQueries">Объект для отправки SQL запросов</param>
        public GetTransports(SqlQueries sqlQueries)
        {
            this.sqlQueries = sqlQueries;
        }

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
        /// <param name="brigadeId">Id бригады</param>
        /// <param name="personId">Id человека</param>
        /// <returns>Список транспорта</returns>
        public IEnumerable<Transport> Action(
            long offset = 0,
            long length = 0,
            string series = "",
            string number = "",
            string regionCode = "",
            short transportCountryId = 0,
            short transportCategoryId = 0,
            DateTime? startBuy = null,
            DateTime? endBuy = null,
            DateTime? startWriteOff = null,
            DateTime? endWriteOff = null,
            long brigadeId = 0,
            long personId = 0
        )
        {
            List<Transport> transports = new List<Transport>();
            string query = @$"
                SELECT * 
                FROM GetTransports(
                    {offset},
                    {length}, 
                    N'{series}',
                    N'{number}',
                    N'{regionCode}',
                    {transportCountryId},
                    {transportCategoryId},
                    N'{Helpers.ConvertDateTimeInISO8601(startBuy)}',
                    N'{Helpers.ConvertDateTimeInISO8601(endBuy)}',
                    N'{Helpers.ConvertDateTimeInISO8601(startWriteOff)}',
                    N'{Helpers.ConvertDateTimeInISO8601(endWriteOff)}',
                    {brigadeId},
                    {personId}
                )
            ";

            DataTable dataTable = sqlQueries.QuerySelect(query);

            foreach (DataRow row in dataTable.Rows)
                transports.Add(ConvertDataRow.ConvertTransport(row));

            return transports;
        }
    }
}
