using Presenter;
using System.Drawing;
using Spectre.Console;
using System.Collections.Generic;
using Ninject;
using Shared;
using ModelLayer;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace ConsoleApp
{
    /// <summary>
    /// Главный класс приложения ConsoleApp.
    /// </summary>
    /// <remarks>
    /// Этот класс инициализирует контейнер зависимостей Ninject, 
    /// получает экземпляр бизнес-логики и запускает пользовательский интерфейс.
    /// </remarks>
    internal class Program: IConsoleView
    {
        public event EventHandler<ViewStudentSelectEventArgs> EventViewStudentDelete = delegate { };
        public event EventHandler<ViewStudentLoadListEventArgs> EventViewStudentLoadList = delegate { };
        public event EventHandler<ViewStudentAddEventArgs> EventViewStudentAdd = delegate { };
        public event EventHandler<ViewStudentUpdateEventArgs> EventViewStudentUpdate = delegate { };
        public event EventHandler<ViewStudentHistogramEventArgs> ViewStudentHistogram = delegate { };
        public event EventHandler<ViewStudentLoadStudentEventArgs> EventViewStudentLoadStudent = delegate { };
        private readonly ConsolePresenter presenter;
        public Program()
        {
            presenter = new ConsolePresenter(this);
        }
        static void Main(string[] args)
        {
            string command;
            Program program = new Program();
            do
            {
                Console.WriteLine("\nВведите команду: 1.Add, 2.Remove, 3.Update, 4.List, 5.Distribution, 6.Exit programm");
                command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "1":
                        program.CheckStudentCharacteristics();
                        break;
                    case "2":
                        program.CheckRemoveStudent();
                        break;
                    case "3":
                        program.UpdateStudent();
                        break;
                    case "4":
                        program.EventViewStudentLoadList(program,new ViewStudentLoadListEventArgs());
                        break;
                    case "5":
                        program.ShowDistribution();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                }
            } while (command != "exit");
        }
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
        public void AddStudent()
        {
            Console.WriteLine("Студент успешно добавлен!");
            return;
        }
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
        public void RemoveStudent()
        {
            Console.WriteLine("Студент успешно удалён!");
            return;
        }
        public void LoadStudents(List<List<string>> students)
        {
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
        public void CheckOnUpdateStudent()
        {
            Console.WriteLine("Выберите номер студента для изменения:");
            EventViewStudentLoadList(this, new ViewStudentLoadListEventArgs());
            if (!int.TryParse(Console.ReadLine(), out int chosenNumber))
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


        }
        public void UpdateStudent()
        {
            Console.WriteLine("Студент обновлён!");
        }
        public void CheckStudentId(int id)
        {
            EventViewStudentLoadStudent(this,new ViewStudentLoadStudentEventArgs(id));
        }
        public List<List<string>> GetStudent(Student student)
        {
            List<List<string>> Student = new List<List<string>>()
            {
                new List<string>
                {
                    student.Name,
                    student.Speciality,
                    student.Group
                }
            };
            return Student;
        }
        public void ShowDistribution()
        {
            ViewStudentHistogram(this,new ViewStudentHistogramEventArgs());
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
