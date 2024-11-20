using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    /// <summary>
/// Интерфейс главного представления, определяющий контракт для взаимодействия с пользователем.
/// </summary>
public interface IMainView
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
    /// Метод удаления студента по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    void DeleteStudent(int id);

    /// <summary>
    /// Метод добавления нового студента.
    /// </summary>
    /// <param name="student">Информация о новом студенте.</param>
    void AddStudent(Student student);

    /// <summary>
    /// Метод загрузки списка студентов.
    /// </summary>
    /// <param name="studentlist">Список студентов.</param>
    void LoadStudents(List<List<string>> studentlist);

    /// <summary>
    /// Метод обновления информации о студенте.
    /// </summary>
    /// <param name="student">Информация об обновляемом студенте.</param>
    void UpdateStudent(Student student);
}
}
