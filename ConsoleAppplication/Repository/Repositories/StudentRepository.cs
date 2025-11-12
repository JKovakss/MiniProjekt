using Domain.Common;
using Domain.Models;
using Repository.Data;
using Repository.Exeptions;
using Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        public void Create(Student data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data not found!");

                AppDbContext<Student>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(int id)
        {
            Student student = AppDbContext<Student>.datas.Find(m => m.Id == id);
            AppDbContext<Student>.datas.Remove(student);
        }

        public void Update(int id, Student data)
        {
            Student existData = AppDbContext<Student>.datas.Find(m => m.Id == id);

            if (!string.IsNullOrWhiteSpace(data.Name))
                existData.Name = data.Name;

            if (!string.IsNullOrWhiteSpace(data.Surname))
                existData.Surname = data.Surname;

            if (!string.IsNullOrWhiteSpace(data.Age.ToString()))
                existData.Age = data.Age;
        }

        public Student Get(Predicate<Student>? predicate)
        {
            Student existData = AppDbContext<Student>.datas.Find(predicate);
            return existData;
        }
    }
}

