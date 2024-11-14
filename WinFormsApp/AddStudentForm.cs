using Ninject;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp
{
    public partial class AddStudentForm : Form
    {
        public event EventHandler<ViewStudentAddEventArgs> StudentAddedOnAddForm = delegate { };
        /// <summary>
        /// Конструктор для инициализации объекта AddStudentForm
        /// </summary>
        /// <param name="logic">Бизнес логика</param>
        public AddStudentForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Добавляет студента при нажатии соответсвующей кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Аргументы события</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string speciality = txtSpeciality.Text;
            string group = txtGroup.Text;
            if (name.Length > 0 && speciality.Length > 0 && group.Length > 0)
            {
                StudentAddedOnAddForm(this, new ViewStudentAddEventArgs(name, speciality, group));
                MessageBox.Show("Студент добавлен.");
            }
            else
            {
                MessageBox.Show("Насяльника у тебя поле пустое. Пока");
            }
            txtName.Text = "";
            txtSpeciality.Text = "";
            txtGroup.Text = "";
            this.Close();
        }
    }
}
