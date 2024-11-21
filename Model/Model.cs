using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Shared;
using StudentModel;

namespace ModelLayer
{
    public class Model : IModel
    {

        private readonly IRepository<Student> _studentRepository;
        
        public event EventHandler<StudentAddEventArgs> EventStudentAdded = delegate { };
        public event EventHandler<StudentUpdateEventArgs> EventStudentUpdated = delegate { };
        public event EventHandler<StudentSelectEventArgs> EventStudentDeleted = delegate { };
        public event EventHandler<StudentLoadListEventArgs> EventStudentList = delegate { };
        public event EventHandler<StudentHistogramEventArgs> EventStudentHistogram = delegate { };
        public event EventHandler<StudentLoadedEventArgs> EventStudentLoaded = delegate { };

        public Model(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void AddStudent(Student student)
        {
            _studentRepository.Create(student);
            EventStudentAdded(this, new StudentAddEventArgs(student));
        }

        public void LoadStudents()
        {
            var students = _studentRepository.GetAll();
            List<List<string>> StudentList = new List<List<string>>();
            foreach (var student in students) 
            {
                StudentList.Add(new List<string> { student.Id.ToString(),student.Name,student.Speciality,student.Group });
            }

            EventStudentList(this, new StudentLoadListEventArgs(StudentList));
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
            EventStudentUpdated(this, new StudentUpdateEventArgs(student));
        }

        public void DeleteStudent(int id)
        {
            var student = _studentRepository.Get(id);
            _studentRepository.Delete(id);
            EventStudentDeleted(this, new StudentSelectEventArgs(student.Id));
        }
        public void ReportStudentHistogram()
        {
            var students = _studentRepository.GetAll();
            EventStudentHistogram(this, new StudentHistogramEventArgs(students.GroupBy(s => s.Speciality)
                                                                              .ToDictionary(g => g.Key, g => g.Count())));
        }
    }
}
