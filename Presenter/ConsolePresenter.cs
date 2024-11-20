using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Shared;
using ModelLayer;

namespace Presenter
{
    /// <summary>
    /// Презентер, отвечающий за взаимодействие с пользователем для работы с основным представлением приложения в консольном приложении.
    /// </summary>
    public class ConsolePresenter : IPresenter
    {
        private IKernel ninject;
        private IConsoleView view;
        private Model model;

        public ConsolePresenter(IConsoleView view)
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
            view.ViewStudentHistogram += view_DistributionLoad;

            view.EventViewStudentLoadStudent += view_LoadStudent;
            model.EventStudentLoaded += model_StudentLoaded;
        }

        private void model_StudentDelete(object sender, StudentSelectEventArgs e)
        {
            view.RemoveStudent();
        }

        private void view_StudentDelete(object sender, ViewStudentSelectEventArgs e)
        {
            model.DeleteStudent(e.Id);
        }

        private void model_StudentLoad(object sender, StudentLoadListEventArgs e)
        {
            view.LoadStudents(e.students);
        }

        private void view_StudentLoad(object sender, ViewStudentLoadListEventArgs e)
        {
            model.LoadStudents();
        }

        private void model_StudentAdd(object sender, StudentAddEventArgs e)
        {
            view.AddStudent();
        }

        private void view_StudentAdd(object sender, ViewStudentAddEventArgs e)
        {
            model.AddStudent(new Student(e.Name, e.Speciality, e.Group));
        }

        private void model_StudentUpdate(object sender, StudentUpdateEventArgs e)
        {
            view.UpdateStudent();
        }

        private void view_StudentUpdate(object sender, ViewStudentUpdateEventArgs e)
        {
            model.UpdateStudent(e.StudentToUpdate);
        }

        public void model_DistributionLoad(object sender, StudentHistogramEventArgs e)
        {
            view.LoadChart(e.Histogram);
        }
        public void view_DistributionLoad(object sender, ViewStudentHistogramEventArgs e)
        {
            model.ReportStudentHistogram();
        }
        public void view_LoadStudent(object sender,ViewStudentLoadStudentEventArgs e)
        {
            model.LoadStudent(e.id);
        }
        public void model_StudentLoaded(object sender, StudentLoadedEventArgs e)
        {
            view.GetStudent(e.Student);
        }
    }
}
