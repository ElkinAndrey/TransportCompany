using System.Data.SqlClient;
using System.Data;

namespace TransportCompanyAPI.Persistence
{
    /// <summary>
    /// Класс для выполениня запростов к базе данных
    /// </summary>
    public class SqlQueries
    {
        /// <summary>
        /// Объект для доступа к базе данных
        /// </summary>
        private SqlConnection connection;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="connection">Объект для доступа к базе данных</param>
        public SqlQueries(SqlConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Метод для получения таблицы из базы данных
        /// </summary>
        /// <param name="queryString">Строка запроса</param>
        /// <returns>Таблица с данными</returns>
        public DataTable QuerySelect(string queryString)
        {
            Console.WriteLine(queryString);
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            return ds.Tables[0];
        }

        /// <summary>
        /// Метод для изменения базы данных
        /// </summary>
        /// <param name="queryString">Строка запроса</param>
        public void QueryChanges(string queryString)
        {
            Console.WriteLine(queryString);
            connection.Open();
            using (SqlCommand cmd = new SqlCommand(queryString, connection))
            {
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}
