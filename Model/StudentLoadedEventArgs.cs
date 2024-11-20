using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class StudentLoadedEventArgs
    {
        public Student Student;
        public StudentLoadedEventArgs(Student student) {  this.Student = student; }
    }
}
