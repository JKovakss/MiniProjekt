using Service.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppplication.Controllers
{
    public class GroupController
    {
        GroupService groupService = new();
        public void Create()
        {
            Console.Write("Name:");
            string name = Console.ReadLine();

            Console.Write("Teacher:");
            string teacher = Console.ReadLine();

            Console.Write("Room:");
        Room: string room = Console.ReadLine();
            int roomNumber;
            bool isRoomNumber = int.TryParse(room, out roomNumber);

            if (isRoomNumber)
            {
                Group group = new()
                {
                    Name = name,
                    Teacher = teacher,
                    Room = roomNumber
                };

                var newGroup = groupService.Create(group);
                Console.WriteLine( $"Id: {newGroup.Id} ,Name: {newGroup.Name}, Teacher: {newGroup.Teacher}, Room: {newGroup.Room}");
            }
            else
            {
                Console.WriteLine( "Seat count is not correct type!");
                goto Room;
            }
        }

        public void Update()
        {
            Console.WriteLine("Id:");
        GroupId: string groupId = Console.ReadLine();
            int groupIdNumber;
            bool islibraryIdNumber = int.TryParse(groupId, out groupIdNumber);

            if (islibraryIdNumber)
            {
                Group library = groupService.GetById(groupIdNumber);

                if (library != null)
                {
                    Console.WriteLine("Name:");
                    string groupName = Console.ReadLine();

                    Console.WriteLine("Teacher:");
                    string teacherName = Console.ReadLine();

                    Console.WriteLine("Room:");
                uRoomNumer: string? uRoomNumber = Console.ReadLine();



                    Group uGroup = new();
                    uGroup.Name = groupName;

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

        public void Delete()
        {
            groupService.Delete(Convert.ToInt32(Console.ReadLine()));
        }

        public void GetById()
        {
            Console.WriteLine("Id:");
        Id: string id = Console.ReadLine();
            int idNumber;
            bool isIdNumber = int.TryParse(id, out idNumber);

            if (isIdNumber)
            {
                Group existData = groupService.GetById(idNumber);

                if (existData != null)
                {
                    Console.WriteLine($"Id: {existData.Id} ,Name: {existData.Name}, Teacher: {existData.Teacher}, Room: {existData.Room}");
                }
                else
                {
                    Console.WriteLine("Data not found!");
                    goto Id;
                }
            }
            else
            {
                Console.WriteLine("Id is not correct type!");
                goto Id;
            }
        }
    }
}
