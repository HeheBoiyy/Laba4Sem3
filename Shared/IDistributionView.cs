using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IDistributionView
    {
        event EventHandler<ViewStudentHistogramEventArgs> ViewStudentHistogram;
        void LoadChart(Dictionary<string, int> Histogram);
    }
}
