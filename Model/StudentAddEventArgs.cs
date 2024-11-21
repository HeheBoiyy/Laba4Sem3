using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using StudentModel;

namespace ModelLayer
{
    /// <summary>
    /// Аргументы события для добавления студента.
    /// </summary>
    public class StudentAddEventArgs : EventArgs
    {
        public Student Student { get; set; }
        public StudentAddEventArgs(Student student)
        {
            Student = student;
        }
    }
}
