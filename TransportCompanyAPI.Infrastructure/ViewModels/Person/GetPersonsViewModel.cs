namespace TransportCompanyAPI.Infrastructure.ViewModels.Person
{
    /// <summary>
    /// Параметры для поиска нужных людей
    /// </summary>
    public class GetPersonsViewModel
    {
        /// <summary>
        /// Начало отчета
        /// </summary>
        public long OffSet { get; set; }

        /// <summary>
        /// Количество человек
        /// </summary>
        public long Length { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; } = "";

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; } = "";

        /// <summary>
        /// Должность человека
        /// </summary>
        public short PositionId { get; set; } = 0;

        /// <summary>
        /// Начало периода даты начала эксплуатации
        /// </summary>
        public DateTime? StartHireDate { get; set; } = null;

        /// <summary>
        /// Конец периода даты начала эксплуатации
        /// </summary>
        public DateTime? EndHireDate { get; set; } = null;

        //// <summary>
        /// Начало периода даты начала эксплуатации
        /// </summary>
        public DateTime? StartDismissalDate { get; set; } = null;

        /// <summary>
        /// Конец периода даты окончания эксплуатации
        /// </summary>
        public DateTime? EndDismissalDate { get; set; } = null;
    }
}
