using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    /// <summary>
    /// Аргументы события для вывода гистограммы
    /// </summary>
    public class StudentHistogramEventArgs
    {
        public Dictionary<string, int> Histogram;
        public StudentHistogramEventArgs(Dictionary<string, int> histogram)
        {
            Histogram = histogram;
        }
    }
}
