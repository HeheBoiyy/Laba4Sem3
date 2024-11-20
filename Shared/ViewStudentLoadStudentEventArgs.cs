using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ViewStudentLoadStudentEventArgs
    {
        public int id;
        public ViewStudentLoadStudentEventArgs(int id)
        {
            this.id = id;
        }
    }
}
