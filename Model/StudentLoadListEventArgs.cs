using Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    /// <summary>
    /// Аргументы события для загрузки студентов в список
    /// </summary>
    public class StudentLoadListEventArgs
    {
        public List<List<string>> students;
        public StudentLoadListEventArgs(List<List<string>> students)
        {
            this.students = students;
        }
    }
}
