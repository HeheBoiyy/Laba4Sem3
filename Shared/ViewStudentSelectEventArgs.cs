using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ViewStudentSelectEventArgs
    {
        public int Id;
        public ViewStudentSelectEventArgs(int Id)
        {
            this.Id = Id;
        }
    }
}
