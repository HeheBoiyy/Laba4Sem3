using ModelLayer;
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
using Shared;

namespace WinFormsApp
{
    public partial class UpdateStudentForm : Form
    {
        public event EventHandler<ViewStudentUpdateEventArgs> ViewStudentUpdate;
        public List<string> CurrentStudent;
        /// <summary>
        /// Конструктор для инициализации UpdateStudentForm
        /// </summary>
        /// <param name="logic">Бизнес логика</param>
        /// <param name="name">Имя студента</param>
        public UpdateStudentForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод для обновления данных о студенте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string newName = NameTextBox.Text;
            string newSpeciality = txtSpeciality.Text;
            string newGroup = txtGroup.Text;
            if (newName == string.Empty)
            {
                newName = CurrentStudent[1];
            }
            if (newSpeciality == string.Empty) 
            { 
                newSpeciality = CurrentStudent[2];
            }
            if (newGroup == string.Empty) 
            {
                newGroup = CurrentStudent[3];
            }
            if (newName == string.Empty && newSpeciality == string.Empty && newGroup == string.Empty)
            {
                MessageBox.Show("Вот и в чём смысл делать студента с пустыми полями?");
            }
            else 
            {
                ViewStudentUpdate(this, new ViewStudentUpdateEventArgs(new Student(int.Parse(CurrentStudent[0]), newName, newSpeciality, newGroup)));
            }
            NameTextBox.Text = "";
            txtSpeciality.Text = "";
            txtGroup.Text = "";
            this.Close();
        }
        
    }
}
