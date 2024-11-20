using System.Diagnostics;
using Ninject;
using Microsoft.VisualBasic.Logging;
using Shared;
using Presenter;
namespace WinFormsApp
{
    public partial class MainForm : Form, IMainView
    {
        public AddStudentForm addStudentForm;
        public UpdateStudentForm updateStudentForm;
        private readonly MainPresenter presenter;
        public event EventHandler<ViewStudentSelectEventArgs> EventViewStudentDelete = delegate { };
        public event EventHandler<ViewStudentLoadListEventArgs> EventViewStudentLoadList = delegate { };
        public event EventHandler<ViewStudentAddEventArgs> EventViewStudentAdd = delegate { };
        public event EventHandler<ViewStudentUpdateEventArgs> EventViewStudentUpdate = delegate { };
        /// <summary>
        /// Инициализирует новый экземпляр формы MainForm.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            presenter = new MainPresenter(this);
            InitializeListView();

            addStudentForm = new AddStudentForm();
            updateStudentForm = new UpdateStudentForm();
            addStudentForm.StudentAddedOnAddForm += OnStudentAddedInAddForm;
            updateStudentForm.ViewStudentUpdate += OnStudentUpdated;
            EventViewStudentLoadList(this, new ViewStudentLoadListEventArgs());
        }
        /// <summary>
        /// Инициализирует ListView для отображения данных студентов.
        /// </summary>
        private void InitializeListView()
        {
            listViewStudents.View = View.Details;
            listViewStudents.FullRowSelect = true;
            listViewStudents.GridLines = true;
            listViewStudents.Columns.Clear();
            listViewStudents.Columns.Add("Номер", 100);
            listViewStudents.Columns.Add("ФИО", 100);
            listViewStudents.Columns.Add("Специальность", 100);
            listViewStudents.Columns.Add("Группа", 100);
        }

        /// <summary>
        /// Загружает список студентов в ListView.
        /// </summary>
        public void LoadStudents(List<List<string>> studentlist)
        {
            listViewStudents.Items.Clear();

            foreach (List<string> student in studentlist)
            {
                var item = new ListViewItem(student[0]);
                item.SubItems.Add(student[1]);
                item.SubItems.Add(student[2]);
                item.SubItems.Add(student[3]);
                listViewStudents.Items.Add(item);
            }
        }
        public void DeleteStudent(int studentId)
        {
            EventViewStudentLoadList(this, new ViewStudentLoadListEventArgs());
            MessageBox.Show("Студент удалён");
        }
        public void OnStudentAddedInAddForm(object sender,ViewStudentAddEventArgs e)
        {
            EventViewStudentAdd(this, e);
        }
        /// <summary>
        /// Обновляет список студентов в ListView.
        /// </summary>
        public void AddStudent(Student student)
        {
            ListViewItem listViewItem = new ListViewItem(student.Id.ToString());
            listViewItem.SubItems.Add(student.Name);
            listViewItem.SubItems.Add(student.Speciality);
            listViewItem.SubItems.Add(student.Group);
            listViewStudents.Items.Add(listViewItem);
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки удаления студента.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = listViewStudents.SelectedItems[0];
                int studentId = int.Parse(selectedItem.SubItems[0].Text);
                EventViewStudentDelete(this,new ViewStudentSelectEventArgs(studentId));
                EventViewStudentLoadList(this, new ViewStudentLoadListEventArgs());
            }
            catch
            {
                MessageBox.Show("Выберите студента для удаления.");
            }

        }
        /// <summary>
        /// Обрабатывает нажатие кнопки добавления студента.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            addStudentForm.ShowDialog();
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки обновления данных студента.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            if (listViewStudents.SelectedItems.Count > 0) 
            {
                var selectedItem = listViewStudents.SelectedItems[0];
                // Предполагаем, что ID студента хранится в первой колонке ListView
                int studentId = int.Parse(selectedItem.SubItems[0].Text);
                List<string> student = new List<string>()
                {
                selectedItem.SubItems[0].Text,
                selectedItem.SubItems[1].Text,
                selectedItem.SubItems[2].Text,
                selectedItem.SubItems[3].Text,
                };
                updateStudentForm.CurrentStudent = student;
                updateStudentForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите студента для обновления!");
            }
            
        }
        public void OnStudentUpdated(object sender, ViewStudentUpdateEventArgs e)
        {
            EventViewStudentUpdate(this, e);
        }
        /// <summary>
        /// Обрабатывает нажатие кнопки отображения распределения по специальностям.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnShowDistribution_Click(object sender, EventArgs e)
        {
            var distributionForm = new DistributionForm();
            distributionForm.ShowDialog();
        }
        
        /// <summary>
        /// Перенаправляет на сайт сфу при нажатии текста на главной форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = @"https://structure.sfu-kras.ru/ikit", UseShellExecute = true });
        }
        /// <summary>
        /// Обновляет список студентов по нажатию кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateListBtn_Click(object sender, EventArgs e)
        {
            EventViewStudentLoadList(this,new ViewStudentLoadListEventArgs());
        }
        /// <summary>
        /// Обновление студента.
        /// </summary>
        /// <param name="student"></param>
        public void UpdateStudent(Student student)
        {
            EventViewStudentLoadList(this, new ViewStudentLoadListEventArgs());
        }
    }
}
