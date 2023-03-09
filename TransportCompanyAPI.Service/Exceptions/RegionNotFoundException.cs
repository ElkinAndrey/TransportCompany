namespace TransportCompanyAPI.Service.Exceptions
{
    /// <summary>
    /// Участок не найден
    /// </summary>
    public sealed class RegionNotFoundException : Exception
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="regionId">Id транспорта</param>
        public RegionNotFoundException(long regionId) :
            base($"Участок с Id {regionId} не найден")
        {

        }
    }
}
