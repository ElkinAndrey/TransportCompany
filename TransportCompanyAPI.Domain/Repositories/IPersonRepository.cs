using TransportCompanyAPI.Domain.Entities.PersonEntities;

namespace TransportCompanyAPI.Domain.Repositories
{
    /// <summary>
    /// Интерфейс для работы с людьми в базе данных.
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Получить список людей
        /// </summary> 
        /// <param name="offset">Начало среза</param>
        /// <param name="length">Длина среза</param>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="patronymic">Отчество</param>
        /// <param name="positionId">Id должности</param>
        /// <param name="startHireDate">Начало периода даты начала эксплуатации</param>
        /// <param name="endHireDate">Конец периода даты начала эксплуатации</param>
        /// <param name="startDismissalDate">Начало периода даты конца эксплуатации</param>
        /// <param name="endDismissalDate">Конец периода даты окончания эксплуатации</param>
        /// <returns>Список людей</returns>
        public Task<IEnumerable<Person>> GetPersons(
            long offset, 
            long length, 
            string name, 
            string surname,
            string patronymic,
            short positionId,
            DateTime? startHireDate,
            DateTime? endHireDate,
            DateTime? startDismissalDate,
            DateTime? endDismissalDate
        );

        /// <summary>
        /// Получить количество людей, удовлетворяющих условию
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="patronymic">Отчество</param>
        /// <param name="positionId">Id должности</param>
        /// <param name="startHireDate">Начало периода даты начала эксплуатации</param>
        /// <param name="endHireDate">Конец периода даты начала эксплуатации</param>
        /// <param name="startDismissalDate">Начало периода даты конца эксплуатации</param>
        /// <param name="endDismissalDate">Конец периода даты окончания эксплуатации</param>
        /// <returns>Количество людей</returns>
        public Task<long> GetPersonCount(
            string name,
            string surname,
            string patronymic,
            short positionId,
            DateTime? startHireDate,
            DateTime? endHireDate,
            DateTime? startDismissalDate,
            DateTime? endDismissalDate
        );

        /// <summary>
        /// Получить список людей
        /// </summary>
        /// <param name="personId">Id человека</param>
        /// <returns>Человек</returns>
        public Task<Person> GetPersonById(long personId);

        /// <summary>
        /// Получить список со всеми должностями людей
        /// </summary>
        /// <returns>
        /// Список с должностями 
        /// [
        ///     ["1", "Слесарь"],
        ///     ["2", "Водитель"],
        /// ]
        /// </returns>
        public Task<IEnumerable<string[]>> GetPersonPositions();
    }
}
