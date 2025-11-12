using Domain.Models;
using Service.Services;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppplication.Controllers
{
    public class StudentController
    {
        StudentService studentService = new();
        public void Create()
        {
            Console.Write("Name:");
            string name = Console.ReadLine();

            Console.Write("Teacher:");
            string surname = Console.ReadLine();

            Console.Write("Room:");
        Age: string age = Console.ReadLine();
            int ageNumber;
            bool isAgeNumber = int.TryParse(age, out ageNumber);

            if (isAgeNumber)
            {
                Student student = new()
                {
                    Name = name,
                    Surname = surname,
                    Age = ageNumber
                };

                var newGroup = studentService.Create(student);
                Console.WriteLine($"Id: {newGroup.Id} ,Name: {newGroup.Name}, Surname: {newGroup.Surname}");
            }
            else
            {
                Console.WriteLine("Seat count is not correct type!");
                goto Age;
            }
        }

        public void Update()
        {
            Console.WriteLine("Id:");
        StudentId: string studentId = Console.ReadLine();
            int studentIdNumber;
            bool isstudentIdNumber = int.TryParse(studentId, out studentIdNumber);

            if (isstudentIdNumber)
            {
                Group student = studentService.GetById(studentIdNumber);

                if (student != null)
                {
                    Console.WriteLine("Name:");
                    string studentName = Console.ReadLine();

                    Console.WriteLine("Surname:");
                    string studentSurname = Console.ReadLine();

                    Console.WriteLine("Age:");
                uAgeNumer: string? uAgeNumber = Console.ReadLine();



                    Group uGroup = new();
                    uGroup.Name = studentName;

                    if (!string.IsNullOrWhiteSpace(uRoomNumber))
                    {
                        uGroup.Room = Convert.ToInt32(uRoomNumber);
                    }

                    Group updateGroup = groupService.Update(groupIdNumber, uGroup);

                    Console.WriteLine($"Id: {updateGroup.Id} ,Name: {updateGroup.Name}, Teacher: {updateGroup.Teacher}, Room: {updateGroup.Room}");

                }
                else
                {
                    Console.WriteLine("Data not found!");
                    goto GroupId;
                }
            }
            else
            {
                Console.WriteLine("Id is not correct type!");
                goto GroupId;
            }


        }

    }
}
