using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Shared
{
    /// <summary>
    /// Аргументы события для добавления нового студента.
    /// </summary>
    public class ViewStudentAddEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Speciality { get; set; }
        public string Group { get; set; }
        public ViewStudentAddEventArgs(string name, string speciality, string group)
        {
            Name = name;
            Speciality = speciality;
            Group = group;
        }
    }
}
