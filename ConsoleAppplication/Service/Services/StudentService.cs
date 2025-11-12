using Domain.Models;
using Repository.Repositories;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private StudentRepository _studentRepository;
        public int count;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }

        public Student Create(Student student)
        {
            student.Id = count;

            _studentRepository.Create(student);
            count++;

            return student;
        }

        public void Delete(int id)
        {
            _studentRepository.Delete(id);
        }

        public Student Update(int id, Student student)
        {
            Student existData = _studentRepository.Get(m => m.Id == id);
            _studentRepository.Update(id, student);
            return existData;
        }

        public Student GetById(int id)
        {
            Student existData = _studentRepository.Get(m => m.Id == id);
            return existData;
        }
    }
}
