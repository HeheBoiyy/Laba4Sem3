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
using System.Windows.Forms.DataVisualization.Charting;
using Presenter;

namespace WinFormsApp
{
    public partial class DistributionForm : Form, IDistributionView
    {
        public event EventHandler<ViewStudentHistogramEventArgs> ViewStudentHistogram = delegate { };
        private readonly HistogramPresenter histogramPresenter;
        /// <summary>
        /// Конструктор для инициализации объекта DistributionForm
        /// </summary>
        /// <param name="logic">Бизнес логика</param>
        /// <param name="specialityCounts">Словарь</param>
        public DistributionForm()
        {
            InitializeComponent();
            histogramPresenter = new HistogramPresenter(this);
        }
        /// <summary>
        /// Создание и загрузка гистаграммы
        /// </summary>
        /// <param name="specialityCounts">Словарь</param>
        public void LoadChart(Dictionary<string, int> specialityCounts)
        {
            if (specialityCounts.Count > 0)
            {
                chartSpeciality.Series.Clear();

                foreach (var speciality in specialityCounts)
                {
                    Series series = chartSpeciality.Series.Add(speciality.Key);
                    series.Points.Add(speciality.Value);
                }

                chartSpeciality.ChartAreas[0].AxisX.Title = "Специальность";
                chartSpeciality.ChartAreas[0].AxisY.Title = "Количество студентов";
                chartSpeciality.ChartAreas[0].AxisX.Interval = 1;
                chartSpeciality.ChartAreas[0].AxisY.Interval = 1;
            }
            else
            {
                MessageBox.Show("Нет студетов((Нельзя вывести гистаграмму. Пока");
                this.Close();
            }
        }

        private void DistributionForm_Load(object sender, EventArgs e)
        {
            ViewStudentHistogram(this, new ViewStudentHistogramEventArgs());
        }
    }
}
