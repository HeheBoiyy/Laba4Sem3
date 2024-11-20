using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    /// <summary>
    /// Интерфейс представления распределения, определяющий контракт для взаимодействия с пользователем.
    /// </summary>
    public interface IDistributionView
    {
        /// <summary>
        /// Событие, возникающее при просмотре гистограммы распределения студентов.
        /// </summary>
        event EventHandler<ViewStudentHistogramEventArgs> ViewStudentHistogram;
        /// <summary>
        /// Метод отрисовки гистаграммы
        /// </summary>
        void LoadChart(Dictionary<string,int> data);
    }
}
