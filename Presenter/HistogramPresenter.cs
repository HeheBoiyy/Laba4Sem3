using Ninject;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace Presenter
{
    public class HistogramPresenter : IPresenter
    {
        public IKernel ninject;
        private readonly IModel model;
        private readonly IDistributionView view;
        public HistogramPresenter(IDistributionView view)
        {
            ninject = new StandardKernel(new SimpleConfigModule());
            model = ninject.Get<Model>();
            this.view = view;

            model.EventStudentHistogram += model_DistributionLoad;
            view.ViewStudentHistogram += view_DistributionLoad;
        }
        public void model_DistributionLoad(object sender, StudentHistogramEventArgs e)
        {
            view.LoadChart(e.Histogram);
        }
        public void view_DistributionLoad(object sender, ViewStudentHistogramEventArgs e)
        {
            model.ReportStudentHistogram();
        }
    }
}
