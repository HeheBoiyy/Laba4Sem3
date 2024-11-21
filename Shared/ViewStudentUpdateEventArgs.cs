using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentModel;

namespace Shared
{
    /// <summary>
    /// Аргументы события для обновления информации о студенте.
    /// </summary>
    public class ViewStudentUpdateEventArgs
    {
        public Student StudentToUpdate { get; set; }
        public ViewStudentUpdateEventArgs(Student studentToUpdate)
        {
            StudentToUpdate = studentToUpdate;
        }
    }
}
