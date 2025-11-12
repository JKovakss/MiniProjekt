using ConsoleApplication.Domain.Entities;   
using ConsoleApplication.Presentation.Helpers;
using ConsoleApplication.Service.Services.Implimentations;

namespace ConsoleApplication.Presentation.Controllers
{
    public class GroupController
    {
        GroupService groupService = new GroupService();

        public void CreateMethod(int selectTrueOption)
        {
        FalseGroup:
            Helper.ConsoleText(ConsoleColor.Green, "Add a group name:");
            string groupName = Console.ReadLine().Trim().ToLower();

            if (string.IsNullOrWhiteSpace(groupName) || int.TryParse(groupName, out selectTrueOption))
            {
                Helper.ConsoleText(ConsoleColor.Red, "Group name cannot be empty or numeric!");
                goto FalseGroup;
            }

            List<Group> groups = groupService.GetAll();

            foreach (Group group2 in groups)
            {
                if (group2.Name == groupName)
                {
                    Helper.ConsoleText(ConsoleColor.Red, $"There is already group with this name: '{groupName}'!");
                    goto FalseGroup;
                }
            }

        FalseName:
            Helper.ConsoleText(ConsoleColor.Green, "Add a group teacher:");
            string teacherName = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(teacherName) ||
                teacherName.Any(char.IsDigit) ||
                teacherName.Contains(" "))
            {
                Helper.ConsoleText(ConsoleColor.Red, "Teacher name cannot be empty, contain numbers, or have spaces!");
                goto FalseName;
            }

            teacherName = Helper.Capitalize(teacherName);

        FalseClass:
            Helper.ConsoleText(ConsoleColor.Green, "Add a room number:");
            string roomName = Console.ReadLine().Trim();
            int roomNumber;

            if (!int.TryParse(roomName, out roomNumber))
            {
                Helper.ConsoleText(ConsoleColor.Red, "Select a correct room number!");
                goto FalseClass;
            }

            Group group = new Group
            {
                Name = groupName,
                Teacher = teacherName,
                Room = roomNumber
            };

            groupService.Create(group);
            Helper.ConsoleText(ConsoleColor.Green, "Group creating...");
            Thread.Sleep(1000);
            Helper.ConsoleText(ConsoleColor.Green, "Group created successfully");
        }

        public void UpdateMethod(int selectTrueOption)
        {
            List<Group> groups = groupService.GetAll();

            if (groups.Count == 0)
            {
                Helper.ConsoleText(ConsoleColor.Red, "There is no group to update!");
                return;
            }

        FalseUpdate:
            Helper.ConsoleText(ConsoleColor.Green, "Enter the ID of the group you want to update:");
            string idStr = Console.ReadLine();

            if (int.TryParse(idStr, out int idInt))
            {
                var findGroup = groupService.GetById(idInt);
                if (findGroup == null)
                {
                    Helper.ConsoleText(ConsoleColor.Red, "No group found with that ID!");
                    goto FalseUpdate;
                }

            FalseGroup:
                Helper.ConsoleText(ConsoleColor.Green, "Add a new group name:");
                string groupName = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrWhiteSpace(groupName) || int.TryParse(groupName, out selectTrueOption))
                {
                    Helper.ConsoleText(ConsoleColor.Red, "Group name cannot be empty or numeric!");
                    goto FalseGroup;
                }

            FalseName:
                Helper.ConsoleText(ConsoleColor.Green, "Add a group teacher:");
                string teacherName = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(teacherName) ||
                    teacherName.Any(char.IsDigit) ||
                    teacherName.Contains(" "))
                {
                    Helper.ConsoleText(ConsoleColor.Red, "Teacher name cannot be empty, contain numbers, or have spaces!");
                    goto FalseName;
                }

                teacherName = Helper.Capitalize(teacherName);

            FalseClass:
                Helper.ConsoleText(ConsoleColor.Green, "Add a room number:");
                string roomName = Console.ReadLine().Trim();
                int roomNumber;

                if (string.IsNullOrWhiteSpace(roomName))
                {
                    roomNumber = findGroup.Room;
                }
                else if (!int.TryParse(roomName, out roomNumber))
                {
                    Helper.ConsoleText(ConsoleColor.Red, "Select a correct room number!");
                    goto FalseClass;
                }

                Helper.ConsoleText(ConsoleColor.Green, "Updating the group...");
                Thread.Sleep(1000);

                Group updatedGroup = new Group
                {
                    Name = groupName,
                    Teacher = teacherName,
                    Room = roomNumber
                };

                groupService.Update(idInt, updatedGroup);
                Helper.ConsoleText(ConsoleColor.DarkCyan, "Group updated successfully");
                Console.WriteLine("");
                Helper.ConsoleText(ConsoleColor.DarkCyan,
                    $"Group ID: {idInt}\nGroup name: {updatedGroup.Name}\nTeacher: {updatedGroup.Teacher}\nGroup room: {updatedGroup.Room}\n");
            }
            else
            {
                Helper.ConsoleText(ConsoleColor.Red, "Incorrect ID format!");
                goto FalseUpdate;
            }
        }

        public void DeleteMethod()
        {
            List<Group> groups = groupService.GetAll();

            if (groups.Count == 0)
            {
                Helper.ConsoleText(ConsoleColor.Red, "There is no group to delete!");
                return;
            }

        FalseDelete:
            Helper.ConsoleText(ConsoleColor.Green, "Enter the ID of the group you want to delete");
            string idStr = Console.ReadLine();

            if (int.TryParse(idStr, out int idInt))
            {
                Helper.ConsoleText(ConsoleColor.Cyan, "Finding the data...");
                Thread.Sleep(1000);

                Group group = groupService.GetById(idInt);

                if (group == null)
                {
                    Helper.ConsoleText(ConsoleColor.Red, "No data found with that ID!");
                    return;
                }

                groupService.Delete(idInt);
                Helper.ConsoleText(ConsoleColor.DarkCyan, "Group deleted successfully");
            }
            else
            {
                Helper.ConsoleText(ConsoleColor.Red, "Incorrect search type!");
                goto FalseDelete;
            }
        }

        public void GetByIdMethod()
        {
            List<Group> groups = groupService.GetAll();

            if (groups.Count == 0)
            {
                Helper.ConsoleText(ConsoleColor.Red, "There is no group to find!");
                return;
            }

        FalseId:
            Helper.ConsoleText(ConsoleColor.Green, "Enter the ID of the group");
            string groupId = Console.ReadLine();
            int id;

            bool isgroupId = int.TryParse(groupId, out id);

            if (isgroupId)
            {
                Group group = groupService.GetById(id);
                Helper.ConsoleText(ConsoleColor.Cyan, "Finding the data...");
                Thread.Sleep(1000);
                Console.WriteLine("");

                if (group == null)
                {
                    Helper.ConsoleText(ConsoleColor.Red, "There is no Group found!");
                    return;
                }

                Helper.ConsoleText(ConsoleColor.DarkCyan,
                    $"Group ID: {group.Id}\nGroup name: {group.Name}\nTeacher: {group.Teacher}\nGroup room: {group.Room}");
                Console.WriteLine("");
            }
            else
            {
                Helper.ConsoleText(ConsoleColor.Red, "Incorrect ID type!");
                goto FalseId;
            }
        }

        public void GetAllMethod()
        {
            List<Group> groups = groupService.GetAll();
            Helper.ConsoleText(ConsoleColor.Cyan, "Finding the datas...");
            Console.WriteLine("");
            Thread.Sleep(1000);

            if (groups != null && groups.Count > 0)
            {
                foreach (Group group in groups)
                {
                    Helper.ConsoleText(ConsoleColor.DarkCyan,
                        $"Group ID: {group.Id}\nGroup name: {group.Name}\nTeacher: {group.Teacher}\nGroup room: {group.Room}\n");
                }
            }
            else
            {
                Helper.ConsoleText(ConsoleColor.Red, "There is no data found!");
            }
        }

        public void GetAllByTeacherMethod()
        {
            List<Group> groups1 = groupService.GetAll();

            if (groups1.Count == 0)
            {
                Helper.ConsoleText(ConsoleColor.Red, "There is no group to find!");
                return;
            }

        FalseTeacher:
            Helper.ConsoleText(ConsoleColor.Green, "Enter the teacher name");
            string teacherSearch = Console.ReadLine().Trim().ToLower();
            int teacherSearchInt;

            bool isTeacherSearchInt = int.TryParse(teacherSearch, out teacherSearchInt);

            if (!isTeacherSearchInt)
            {
                List<Group> groups = groupService.SearchByTeacher(Helper.Capitalize(teacherSearch));
                Helper.ConsoleText(ConsoleColor.Cyan, "Finding the data...");
                Console.WriteLine("");
                Thread.Sleep(1000);

                if (groups.Count == 0)
                {
                    Helper.ConsoleText(ConsoleColor.Red, "There is no data found!");
                    return;
                }

                foreach (Group group in groups)
                {
                    Helper.ConsoleText(ConsoleColor.DarkCyan,
                        $"Group ID: {group.Id}\nGroup name: {group.Name}\nTeacher: {group.Teacher}\nGroup room: {group.Room}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Helper.ConsoleText(ConsoleColor.Red, "Incorrect search type!");
                goto FalseTeacher;
            }
        }

        public void GetAllByRoomMethod()
        {
            List<Group> groups1 = groupService.GetAll();

            if (groups1.Count == 0)
            {
                Helper.ConsoleText(ConsoleColor.Red, "There is no group to find!");
                return;
            }

        FalseRoom:
            Helper.ConsoleText(ConsoleColor.Green, "Enter the room number");
            string roomSearch = Console.ReadLine();
            int roomSearchInt;
            bool isRoomSearchInt = int.TryParse(roomSearch, out roomSearchInt);
            List<Group> groups = groupService.SearchByRoom(roomSearchInt);

            if (isRoomSearchInt)
            {
                Helper.ConsoleText(ConsoleColor.Cyan, "Finding the data...");
                Thread.Sleep(1000);

                if (groups.Count == 0)
                {
                    Helper.ConsoleText(ConsoleColor.Red, "There is no data found!");
                    return;
                }

                foreach (Group group in groups)
                {
                    Helper.ConsoleText(ConsoleColor.DarkCyan,
                        $"Group ID: {group.Id}\nGroup name: {group.Name}\nTeacher: {group.Teacher}\nGroup room: {group.Room}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Helper.ConsoleText(ConsoleColor.Red, "Incorrect search type!");
                goto FalseRoom;
            }
        }

        public void GetGroupByName()
        {
            List<Group> groups1 = groupService.GetAll();

            if (groups1.Count == 0)
            {
                Helper.ConsoleText(ConsoleColor.Red, "There is no group to find!");
                return;
            }

        FalseName:
            Helper.ConsoleText(ConsoleColor.Green, "Enter the group name");
            string groupSearch = Console.ReadLine().Trim().ToLower();
            int groupSearchInt;
            bool isGroupSearchInt = int.TryParse(groupSearch, out groupSearchInt);

            if (!isGroupSearchInt)
            {
                List<Group> groups = groupService.SearchByName(groupSearch);
                Helper.ConsoleText(ConsoleColor.Cyan, "Finding the data...");
                Thread.Sleep(1000);

                if (groups.Count == 0)
                {
                    Helper.ConsoleText(ConsoleColor.Red, "There is no data found!");
                    return;
                }

                foreach (Group group in groups)
                {
                    Console.WriteLine("");
                    Helper.ConsoleText(ConsoleColor.DarkCyan,
                        $"Group ID: {group.Id}\nGroup name: {group.Name}\nTeacher: {group.Teacher}\nGroup room: {group.Room}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Helper.ConsoleText(ConsoleColor.Red, "Incorrect search type!");
                goto FalseName;
            }
        }
    }
}