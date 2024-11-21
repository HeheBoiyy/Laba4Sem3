using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using StudentModel;
using Shared;
using Ninject;

namespace Presenter
{
    /// <summary>
    /// Презентер, отвечающий за взаимодействие с пользователем для работы с основным представлением приложения.
    /// </summary>
    public class MainPresenter
    {
        public IKernel ninject;
        private readonly IModel model;
        private readonly IMainView view;
        public MainPresenter(IMainView view)
        {
            ninject = new StandardKernel(new SimpleConfigModule());
            model = ninject.Get<Model>();

            this.view = view;

            model.EventStudentDeleted += model_StudentDelete;
            view.EventViewStudentDelete += view_StudentDelete;

            model.EventStudentList += model_StudentLoad;
            view.EventViewStudentLoadList += view_StudentLoad;

            model.EventStudentAdded += model_StudentAdd;
            view.EventViewStudentAdd += view_StudentAdd;

            model.EventStudentUpdated += model_StudentUpdate;
            view.EventViewStudentUpdate += view_StudentUpdate;

            model.EventStudentHistogram += model_DistributionLoad;
            view.EventViewStudentHistogram += view_DistributionLoad;
        }
        public void model_StudentDelete(object sender,StudentSelectEventArgs e)
        {
            view.DeleteStudent(e.Id);
        }
        public void view_StudentDelete(object sender,ViewStudentSelectEventArgs e)
        {
            model.DeleteStudent(e.Id);
        }
        public void model_StudentLoad(object sender,StudentLoadListEventArgs e)
        {
            view.LoadStudents(e.students);
        }
        public void view_StudentLoad(object sender,ViewStudentLoadListEventArgs e)
        {
            model.LoadStudents();
        }
        public void view_StudentAdd(object sender,ViewStudentAddEventArgs e)
        {
            model.AddStudent(new Student(e.Name,e.Speciality,e.Group));
        }
        public void model_StudentAdd(object sender,StudentAddEventArgs e)
        {
            view.AddStudent(e.Student);
        }
        public void view_StudentUpdate(object sender,ViewStudentUpdateEventArgs e)
        {
            model.UpdateStudent(e.StudentToUpdate);
        }
        public void model_StudentUpdate(object sender,StudentUpdateEventArgs e)
        {
            view.UpdateStudent(e.StudentToUpdate);
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
