using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ViewStudentUpdateEventArgs
    {
        public int Id { get; set; }
        public Student StudentToUpdate { get; set; }

        public ViewStudentUpdateEventArgs(int id, Student studentToUpdate)
        {
            Id = id;
            StudentToUpdate = studentToUpdate;
        }
        public ViewStudentUpdateEventArgs(Student studentToUpdate)
        {
            StudentToUpdate = studentToUpdate;
        }
    }
}
