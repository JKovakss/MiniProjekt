using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interface
{
    public interface IStudentService
    {
        Student Create(Student data);
        Student Update(int id, Student data);
        void Delete(int id);
        Student GetById(int id);
    }
}
