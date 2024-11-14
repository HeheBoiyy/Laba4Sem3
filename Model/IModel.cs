using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace ModelLayer
{
    /// <summary>
    /// Интерфейс, определяющий контракт для модели в приложении,
    /// предоставляющий методы для управления данными студентов и события
    /// для уведомления об изменениях в данных студентов.
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Добавляет нового студента в систему.
        /// </summary>
        /// <param name="student">Объект студента, который нужно добавить.</param>
        void AddStudent(Student student);

        /// <summary>
        /// Обновляет данные существующего студента.
        /// </summary>
        /// <param name="student">Объект студента с обновлёнными данными.</param>
        void UpdateStudent(Student student);

        /// <summary>
        /// Удаляет студента из системы по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор студента, которого нужно удалить.</param>
        void DeleteStudent(int id);

        /// <summary>
        /// Загружает список всех студентов.
        /// </summary>
        void LoadStudents();

        /// <summary>
        /// Генерирует отчёт о распределении студентов по специальностям.
        /// </summary>
        void ReportStudentHistogram();

        /// <summary>
        /// Событие, возникающее при добавлении нового студента.
        /// </summary>
        event EventHandler<StudentAddEventArgs> EventStudentAdded;

        /// <summary>
        /// Событие, возникающее при обновлении данных студента.
        /// </summary>
        event EventHandler<StudentUpdateEventArgs> EventStudentUpdated;

        /// <summary>
        /// Событие, возникающее при удалении студента.
        /// </summary>
        event EventHandler<StudentSelectEventArgs> EventStudentDeleted;

        /// <summary>
        /// Событие, возникающее при загрузке списка студентов.
        /// </summary>
        event EventHandler<StudentLoadListEventArgs> EventStudentList;

        /// <summary>
        /// Событие, возникающее при генерации отчёта о распределении студентов.
        /// </summary>
        event EventHandler<StudentHistogramEventArgs> EventStudentHistogram;
    }
}
