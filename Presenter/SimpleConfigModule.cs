using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ModelLayer;
using StudentModel;
using Ninject.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
namespace Presenter
{
    /// <summary>
    /// Модуль конфигурации для Ninject, который управляет зависимостями в приложении.
    /// </summary>
    /// <remarks>
    /// Этот класс загружает настройки из файла appsettings.json, 
    /// настраивает контекст базы данных и связывает интерфейсы с их реализациями.
    /// Поддерживает выбор между Dapper и Entity Framework для доступа к данным.
    /// </remarks>
    public class SimpleConfigModule:NinjectModule
    {
        public override void Load()
        {
            var projectRootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

            var jsonFilePath = Path.Combine(projectRootPath, "DataAccessLayer");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(jsonFilePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string framework = configuration["DataAccessFramework"];
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // DBContext для EF
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            Bind<DbContextOptions<AppDbContext>>().ToConstant(optionsBuilder.Options);
            Bind<AppDbContext>().ToSelf().InSingletonScope();


            switch (framework)
            {
                case "Dapper":
                    Bind<IRepository<Student>>().To<DapperStudentRepository>().InSingletonScope().WithConstructorArgument("_connectionString",connectionString);
                    break;
                case "EntityFramework":
                    Bind<IRepository<Student>>().To<EFStudentRepository>().InSingletonScope();
                    break;
                default:
                    throw new ArgumentException("Неподдерживаемый фреймворк доступа к данным");
            }
        }
    }
}
