using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IMainView
    {
        event EventHandler<ViewStudentSelectEventArgs> EventViewStudentDelete;

        event EventHandler<ViewStudentLoadListEventArgs> EventViewStudentLoadList;

        event EventHandler<ViewStudentAddEventArgs> EventViewStudentAdd;

        event EventHandler<ViewStudentUpdateEventArgs> EventViewStudentUpdate;
        void DeleteStudent(int id);
        void AddStudent(Student student);
        void LoadStudents(List<List<string>> studentlist);
        void UpdateStudent(Student student);
    }
}
