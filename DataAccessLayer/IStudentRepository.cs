﻿using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentModel;
namespace DataAccessLayer
{
    /// <summary>
    /// Интерфейс репозитория для работы с данными студентов.
    /// </summary>
    public interface IStudentRepository : IRepository<Student>
    {
        
    }
}
