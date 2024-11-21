using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentModel;

namespace ModelLayer
{
    /// <summary>
    /// Аргументы события для обновления данных студента.
    /// Содержит объект студента с обновлёнными данными.
    /// </summary>
    public class StudentUpdateEventArgs
    {
        public Student StudentToUpdate { get; set; }

        public StudentUpdateEventArgs(Student studentToUpdate)
        {
            StudentToUpdate = studentToUpdate;
        }
    }
}
