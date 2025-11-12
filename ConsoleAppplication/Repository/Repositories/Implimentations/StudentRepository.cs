using ConsoleApplication.Domain.Entities;
using ConsoleApplication.Repository.Data;
using ConsoleApplication.Repository.Exceptions;
using ConsoleApplication.Repository.Repositories.Interfaces;

namespace ConsoleApplication.Repository.Repositories.Implimentations
{
    public class StudentRepository : IRepository<Student>
    {
        public void Create(Student data)
        {
            try
            {
                if (data == null) throw new NotFoundException("Student not found!");

                AppDbContext<Student>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Student data)
        {
            AppDbContext<Student>.datas.Remove(data);
        }

        public Student Get(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.Find(predicate) : null;
        }

        public List<Student> GetAll(Predicate<Student> predicate = null)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate) : AppDbContext<Student>.datas;
        }

        public void Update(Student data)
        {
            Student student = Get(s => s.Id == data.Id);

            student.Name = data.Name;

            student.Surname = data.Surname;

            student.Age = data.Age;

            student.Group = data.Group;
        }
    }
}
