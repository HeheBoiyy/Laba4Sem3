using System.Drawing;
using Spectre.Console;
using System.Collections.Generic;
using Ninject;
using Shared;
using static System.Runtime.InteropServices.JavaScript.JSType;
using StudentModel;
 
namespace ConsoleApp
{
    /// <summary>
    /// Главный класс приложения ConsoleApp.
    /// </summary>
    /// <remarks>
    /// Этот класс инициализирует контейнер зависимостей Ninject, 
    /// получает экземпляр бизнес-логики и запускает пользовательский интерфейс.
    /// </remarks>
    public class Program: IMainView
    {
        public event EventHandler<ViewStudentSelectEventArgs> EventViewStudentDelete = delegate { };
        public event EventHandler<ViewStudentLoadListEventArgs> EventViewStudentLoadList = delegate { };
        public event EventHandler<ViewStudentAddEventArgs> EventViewStudentAdd = delegate { };
        public event EventHandler<ViewStudentUpdateEventArgs> EventViewStudentUpdate = delegate { };
        public event EventHandler<ViewStudentHistogramEventArgs> EventViewStudentHistogram = delegate { };
        private List<List<string>> _students;
        public Program()
        {
            _students = new List<List<string>>();
        }
        public void Run()
        {
            string command; 
            do
            {
                Console.WriteLine("\nВведите команду: 1.Add, 2.Remove, 3.Update, 4.List, 5.Distribution, 6.Exit programm");
                command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "1":
                        CheckStudentCharacteristics(); // Используем текущий экземпляр
                        break;
                    case "2":
                        CheckRemoveStudent(); // Используем текущий экземпляр
                        break;
                    case "3":
                        CheckOnUpdateStudent(); // Используем текущий экземпляр
                        break;
                    case "4":
                        EventViewStudentLoadList(this, new ViewStudentLoadListEventArgs()); // Используем текущий экземпляр
                        break;
                    case "5":
                        ShowDistribution(); // Используем текущий экземпляр
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                }
            } while (command != "exit");
        }
        /// <summary>
        /// Метод ввода и проверки данных для добавления студента
        /// </summary>
        public void CheckStudentCharacteristics()
        {
            Console.Clear();
            Console.Write("Введите имя студента: ");
            string name = Console.ReadLine();

            Console.Write("Введите специальность студента: ");
            string speciality = Console.ReadLine();

            Console.Write("Введите группу студента: ");
            string group = Console.ReadLine();
            if (name == string.Empty || speciality == string.Empty || group == string.Empty)
            {
                Console.WriteLine("Одно из пулей пустое");
                return;
            }
            else
            {
                EventViewStudentAdd(this,new ViewStudentAddEventArgs(name,speciality,group));
                return;
            }
        }
        public void AddStudent(Student student)
        {
            Console.WriteLine("Студент успешно добавлен!");
            return;
        }
        /// <summary>
        /// Метод ввода данных для удаления студента
        /// </summary>
        public void CheckRemoveStudent()
        {
            Console.WriteLine("Введите Id Студента:");
            EventViewStudentLoadList(this,new ViewStudentLoadListEventArgs());
            string id = Console.ReadLine();
            try
            {
                int Id = int.Parse(id);
                EventViewStudentDelete(this,new ViewStudentSelectEventArgs(Id));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Бро, нужно вводить число");
            }
        }
        public void DeleteStudent(int id)
        {
            Console.WriteLine("Студент успешно удалён!");
            return;
        }
        public void LoadStudents(List<List<string>> students)
        {
            _students = students;
            if (students.Count > 0)
            {
                foreach (var student in students)
                {
                    Console.WriteLine($"ID : {student[0]} Имя: {student[1]}, Специальность: {student[2]}, Группа: {student[3]}");
                }
            }
            else
            {
                Console.WriteLine("Студентов нет");
            }
        }
        /// <summary>
        /// Метод ввода данных для обновления студента
        /// </summary>
        public void CheckOnUpdateStudent()
        {
            Console.WriteLine("Выберите номер студента для изменения:");
            EventViewStudentLoadList(this, new ViewStudentLoadListEventArgs());
            string id = Console.ReadLine();
            if (!int.TryParse(id, out int chosenNumber))
            {
                Console.WriteLine("Ошибка! Введите корректный номер студента.");
                return;
            }

            Console.Write("Введите новое имя студента (оставьте пустым, чтобы не менять): ");
            string name = Console.ReadLine();

            Console.Write("Введите новую специальность (оставьте пустым, чтобы не менять): ");
            string speciality = Console.ReadLine();

            Console.Write("Введите новую группу (оставьте пустым, чтобы не менять): ");
            string group = Console.ReadLine();

            int studentposition = _students.FindIndex(student => Convert.ToInt16(student[0]) == chosenNumber);
            List<string> currentStudent = _students[studentposition];
            name = string.IsNullOrWhiteSpace(name) ? currentStudent[1] : name;
            speciality = string.IsNullOrWhiteSpace(speciality) ? currentStudent[2] : speciality;
            group = string.IsNullOrWhiteSpace(group) ? currentStudent[3] : group;
            EventViewStudentUpdate(this, new ViewStudentUpdateEventArgs(new Student(chosenNumber, name, speciality, group)));

        }
        public void UpdateStudent(Student student)
        {
            Console.WriteLine("Студент обновлён!");
        }
        public void ShowDistribution()
        {
            EventViewStudentHistogram(this,new ViewStudentHistogramEventArgs());
        }
        public void LoadChart(Dictionary<string,int> data)
        {
            var chart = new BarChart().Width(60).Label("[green bold]Гистограмма[/]");
            foreach (var entry in data)
            {
                chart.AddItem(entry.Key, entry.Value, Spectre.Console.Color.Aqua);
            }

            AnsiConsole.Write(chart);
        }
    }
}
