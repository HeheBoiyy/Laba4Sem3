using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    /// <summary>
    /// Аргументы события для выбора студента.
    /// Содержит идентификатор студента, который был выбран.
    /// </summary>
    public class StudentSelectEventArgs
    {
        public int Id;
        public StudentSelectEventArgs(int Id)
        {
            this.Id = Id;
        }
    }
}
