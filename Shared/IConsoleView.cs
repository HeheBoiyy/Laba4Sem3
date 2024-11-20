using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IConsoleView
    {
        /// <summary>
        /// Событие, возникающее при удалении студента.
        /// </summary>
        event EventHandler<ViewStudentSelectEventArgs> EventViewStudentDelete;

        /// <summary>
        /// Событие, возникающее при загрузке списка студентов.
        /// </summary>
        event EventHandler<ViewStudentLoadListEventArgs> EventViewStudentLoadList;

        /// <summary>
        /// Событие, возникающее при добавлении нового студента.
        /// </summary>
        event EventHandler<ViewStudentAddEventArgs> EventViewStudentAdd;

        /// <summary>
        /// Событие, возникающее при обновлении информации о студенте.
        /// </summary>
        event EventHandler<ViewStudentUpdateEventArgs> EventViewStudentUpdate;

        /// <summary>
        /// Событие, возникающее при просмотре гистограммы распределения студентов.
        /// </summary>
        event EventHandler<ViewStudentHistogramEventArgs> ViewStudentHistogram;
        /// <summary>
        /// Событие, возникающее при загрузке студента.
        /// </summary>
        event EventHandler<ViewStudentLoadStudentEventArgs> EventViewStudentLoadStudent;
        /// <summary>
        /// Добавляет нового студента на основе введенных данных.
        /// </summary>
        public void AddStudent();
        /// <summary>
        /// Удаляет студента на основе введенного номера.
        /// </summary>
        public void RemoveStudent();
        /// <summary>
        /// Обновляет данные студента на основе введенного номера.
        /// </summary>
        public void UpdateStudent();
        /// <summary>
        /// Отображает список всех студентов.
        /// </summary>
        public void LoadStudents(List<List<string>> students);
        /// <summary>
        /// Показывает распределение студентов по специальностям в виде гистограммы.
        /// </summary>
        public void LoadChart(Dictionary<string, int> data);
        List<List<string>> GetStudent(Student student);
    }
}
