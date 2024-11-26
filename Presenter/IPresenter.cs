using ModelLayer;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public interface IPresenter
    {
        void model_StudentDelete(object sender, StudentSelectEventArgs e);
        void view_StudentDelete(object sender, ViewStudentSelectEventArgs e);
        void model_StudentLoad(object sender, StudentLoadListEventArgs e);
        void view_StudentLoad(object sender, ViewStudentLoadListEventArgs e);
        void view_StudentAdd(object sender, ViewStudentAddEventArgs e);
        void model_StudentAdd(object sender, StudentAddEventArgs e);
        void view_StudentUpdate(object sender, ViewStudentUpdateEventArgs e);
        void model_StudentUpdate(object sender, StudentUpdateEventArgs e);
        void model_DistributionLoad(object sender, StudentHistogramEventArgs e);
        void view_DistributionLoad(object sender, ViewStudentHistogramEventArgs e);
    }
}
