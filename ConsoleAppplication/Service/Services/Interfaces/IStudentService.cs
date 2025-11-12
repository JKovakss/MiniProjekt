using ConsoleApplication.Domain.Entities;
using System.Text.RegularExpressions;
using Group = System.Text.RegularExpressions.Group;

namespace ConsoleApplication.Service.Services.Interfaces
{
    public interface IStudentSevice
    {
        Student Create(int studentId, Student student);
        Student Update(int id, Student student);
        void Delete(int id);
        Student GetById(int id);
        List<Student> GetAll();
        List<Student> SearchByAge(int age);
        List<Student> SearchByName(string name);
        List<Student> SearchBySurname(string surname);
    }
}