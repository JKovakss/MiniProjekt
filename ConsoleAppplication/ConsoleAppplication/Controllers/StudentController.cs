using ConsoleApplication.Domain.Entities;
using ConsoleApplication.Presentation.Helpers;
using ConsoleApplication.Service.Services.Implimentations;


namespace ConsoleApplication.Presentation.Controllers
{
    public class StudentController
    {
        StudentService studentService = new StudentService();
        GroupService groupService = new GroupService();

        public void CreateMethod()
        {
            List<Group> groups = groupService.GetAll();

            if (groups.Count == 0)
            {
                Helper.ConsoleText(ConsoleColor.Red, "There is no group yet!");
                return;
            }

        FalseId:
            Helper.ConsoleText(ConsoleColor.Green, "Add the group ID:");
            string groupId = Console.ReadLine();

            if (!int.TryParse(groupId, out int groupIdInt))
            {
                Helper.ConsoleText(ConsoleColor.Red, "Incorrect ID format!");
                goto FalseId;
            }

            var group = groupService.GetById(groupIdInt);
            if (group == null)
            {
                Helper.ConsoleText(ConsoleColor.Red, "There is no group with this ID!");
                goto FalseId;
            }

        FalseStudent:
            Helper.ConsoleText(ConsoleColor.Green, "Add a student name:");
            string studentName = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(studentName) ||
                studentName.Any(char.IsDigit) ||
                studentName.Contains(" "))
            {
                Helper.ConsoleText(ConsoleColor.Red, "Incorrect student name!");
                goto FalseStudent;
            }

        FalseSurname:
            Helper.ConsoleText(ConsoleColor.Green, "Add a student surname:");
            string studentSurname = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(studentSurname) ||
                studentSurname.Any(char.IsDigit) ||
                studentSurname.Contains(" "))
            {
                Helper.ConsoleText(ConsoleColor.Red, "Incorrect student surname!");
                goto FalseSurname;
            }

        FalseClass:
            Helper.ConsoleText(ConsoleColor.Green, "Add the age of the student:");
            string studentAge = Console.ReadLine().Trim();

            if (!int.TryParse(studentAge, out int studentAgeInt))
            {
                Helper.ConsoleText(ConsoleColor.Red, "Incorrect age format!");
                goto FalseClass;
            }
            else if (studentAgeInt < 18 || studentAgeInt > 65)
            {
                Helper.ConsoleText(ConsoleColor.Red, "Age must be between 18 and 65!");
                goto FalseClass;
            }

            Student student = new Student
            {
                Name = Helper.Capitalize(studentName),
                Surname = Helper.Capitalize(studentSurname),
                Age = studentAgeInt
            };

            var result = studentService.Create(groupIdInt, student);

            Helper.ConsoleText(ConsoleColor.Green, "Student creating...");
            Thread.Sleep(1000);

            if (result != null)
            {
                Helper.ConsoleText(ConsoleColor.Green, "Student created successfully");
                Console.WriteLine("");
                Helper.ConsoleText(ConsoleColor.DarkCyan,
                    $"Student ID: {student.Id}\n" +
                    $"Student name: {student.Name}\n" +
                    $"Student surname: {student.Surname}\n" +
                    $"Student age: {student.Age}\n" +
                    $"Student group: {student.Group.Name}");
            }
            else
            {
                Helper.ConsoleText(ConsoleColor.Red, "Group not found!");
            }
        }

        public void UpdateMethod(int selectTrueOption)
        {
            List<Student> students = studentService.GetAll();

            if (students.Count == 0)
            {
                Helper.ConsoleText(ConsoleColor.Red, "There is no student to update!");
                return;
            }

        FalseUpdate:
            Helper.ConsoleText(ConsoleColor.Green, "Enter the ID of the student you want to update:");
            string idStr = Console.ReadLine();

            if (!int.TryParse(idStr, out int idInt))
            {
                Helper.ConsoleText(ConsoleColor.Red, "Incorrect ID format!");
                goto FalseUpdate;
            }

            var findStudent = studentService.GetById(idInt);
            if (findStudent == null)
            {
                Helper.ConsoleText(ConsoleColor.Red, "No student found with that ID!");
                goto FalseUpdate;
            }

        FalseStudent:
            Helper.ConsoleText(ConsoleColor.Green, "Add a new student name:");
            string studentName = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(studentName) ||
                studentName.Any(char.IsDigit) ||
                studentName.Contains(" "))
            {
                Helper.ConsoleText(ConsoleColor.Red, "Incorrect student name!");
                goto FalseStudent;
            }

        FalseSurname:
            Helper.ConsoleText(ConsoleColor.Green, "Add a new student surname:");
            string studentSurname = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(studentSurname) ||
                studentSurname.Any(char.IsDigit) ||
                studentSurname.Contains(" "))
            {
                Helper.ConsoleText(ConsoleColor.Red, "Incorrect student surname!");
                goto FalseSurname;
            }

        FalseClass:
            Helper.ConsoleText(ConsoleColor.Green, "Add a new student age:");
            string studentAge = Console.ReadLine().Trim();

            int studentAgeInt;
            if (string.IsNullOrWhiteSpace(studentAge))
            {
                studentAgeInt = findStudent.Age;
            }
            else if (!int.TryParse(studentAge, out studentAgeInt) ||
         studentAgeInt < 18 || studentAgeInt > 65)

            {
                Helper.ConsoleText(ConsoleColor.Red, "Age must be between 18 and 65!");
                goto FalseClass;
            }

        FalseGroup:
            Helper.ConsoleText(ConsoleColor.Green, "Add a new student group:");
            string studentGroup = Console.ReadLine().Trim().ToLower();

            if (string.IsNullOrWhiteSpace(studentGroup))
                studentGroup = findStudent.Group.Name;

            List<Group> groups = groupService.GetAll();
            Group groupToAssign = groups.FirstOrDefault(g => g.Name == studentGroup);

            if (groupToAssign == null)
            {
                Helper.ConsoleText(ConsoleColor.Red, "There is no such group!");
                goto FalseGroup;
            }

            Helper.ConsoleText(ConsoleColor.Green, "Updating the student...");
            Thread.Sleep(1000);

            Student updatedStudent = new Student
            {
                Name = Helper.Capitalize(studentName),
                Surname = Helper.Capitalize(studentSurname),
                Age = studentAgeInt,
                Group = groupToAssign
            };

            studentService.Update(idInt, updatedStudent);
            Helper.ConsoleText(ConsoleColor.DarkCyan, "Student updated successfully");
            Console.WriteLine("");

            Helper.ConsoleText(ConsoleColor.DarkCyan,
                $"Student ID: {idInt}\n" +
                $"Student name: {updatedStudent.Name}\n" +
                $"Student surname: {updatedStudent.Surname}\n" +
                $"Student age: {updatedStudent.Age}\n" +
                $"Student group: {updatedStudent.Group.Name}");
        }

        public void DeleteMethod()
        {
            List<Student> students = studentService.GetAll();

            if (students.Count == 0)
            {
                Helper.ConsoleText(ConsoleColor.Red, "There is no student to delete!");
                return;
            }

        FalseDelete: Helper.ConsoleText(ConsoleColor.Green, "Enter the ID of the student you want to delete");
            string idStr = Console.ReadLine();

            if (int.TryParse(idStr, out int idInt))
            {
                Helper.ConsoleText(ConsoleColor.Cyan, "Finding the data...");
                Thread.Sleep(1000);

                Student student = studentService.GetById(idInt);

                if (student == null)
                {
                    Helper.ConsoleText(ConsoleColor.Red, "No data found with that ID!");
                    return;
                }
                studentService.Delete(idInt);
                Helper.ConsoleText(ConsoleColor.DarkCyan, "Student deleted successfully");
            }
            else
            {
                Helper.ConsoleText(ConsoleColor.Red, "Incorrect search type!");
                goto FalseDelete;
            }
        }

        public void GetByIdMethod()
        {
            List<Student> students = studentService.GetAll();

            if (students.Count == 0)
            {
                Helper.ConsoleText(ConsoleColor.Red, "There is no student to find!");
                return;
            }

        FalseId: Helper.ConsoleText(ConsoleColor.Green, "Enter the ID of the student");
            string studentId = Console.ReadLine();
            int id;

            bool isstudentId = int.TryParse(studentId, out id);

            if (isstudentId)
            {
                Student student = studentService.GetById(id);

                Helper.ConsoleText(ConsoleColor.Cyan, "Finding the data...");

                Thread.Sleep(1000);

                if (student == null)
                {
                    Helper.ConsoleText(ConsoleColor.Red, "Student not found!");
                    return;
                }

                Console.WriteLine("");

                Helper.ConsoleText(ConsoleColor.DarkCyan, $"Student ID: {student.Id}\nStudent name: " +
                    $"{student.Name}\nStudent Surname: {student.Surname}\nStudent Age: {student.Age}\nStudent group : {student.Group.Name}");

                Console.WriteLine("");
            }
            else
            {
                Helper.ConsoleText(ConsoleColor.Red, "Incorrect ID type!");
                goto FalseId;
            }
        }

        public void GetAllByGroupIdMethod()
        {
            List<Group> groups = groupService.GetAll();

            if (groups.Count == 0)
            {
                Helper.ConsoleText(ConsoleColor.Red, "There is no group yet!");
                return;
            }

        FalseId: Helper.ConsoleText(ConsoleColor.Green, "Enter the ID of the group");
            string groupId = Console.ReadLine();
            int groupIdInt;

            bool isGroupId = int.TryParse(groupId, out groupIdInt);

            if (isGroupId)
            {
                List<Student> students = studentService.GetAll();

                Helper.ConsoleText(ConsoleColor.Cyan, "Finding the datas...");
                Thread.Sleep(1000);

                if (students != null && students.Count > 0)
                {
                    foreach (Student student in students)
                    {
                        if (student.Group.Id == groupIdInt)
                        {
                            Console.WriteLine("");

                            Helper.ConsoleText(ConsoleColor.DarkCyan, $"Student ID: {student.Id}\nStudent name: " +
                                $"{student.Name}\nStudent Surname: {student.Surname}\nStudent Age: {student.Age}\nStudent group : {student.Group.Name}");
                        }
                        else
                        {
                            Helper.ConsoleText(ConsoleColor.Red, "There is no student found in this group!");
                            break;
                        }
                    }

                    Console.WriteLine("");
                }
                else
                {
                    Helper.ConsoleText(ConsoleColor.Red, "There is no data found!");
                }
            }
            else
            {
                Helper.ConsoleText(ConsoleColor.Red, "Incorrect ID type!");
                goto FalseId;
            }
        }

        public void GetAllByAgeMethod()
        {
            List<Student> students1 = studentService.GetAll();

            if (students1.Count == 0)
            {
                Helper.ConsoleText(ConsoleColor.Red, "There is no student yet!");
                return;
            }

        FalseAge: Helper.ConsoleText(ConsoleColor.Green, "Enter the age");
            string ageSearch = Console.ReadLine();
            int ageSearchInt;

            bool isAgeSearchInt = int.TryParse(ageSearch, out ageSearchInt);

            List<Student> students = studentService.SearchByAge(ageSearchInt);

            if (isAgeSearchInt)
            {
                Helper.ConsoleText(ConsoleColor.Cyan, "Finding the data...");

                Console.WriteLine("");

                Thread.Sleep(1000);

                if (students.Count == 0)
                {
                    Helper.ConsoleText(ConsoleColor.Red, "There is no data found!");
                    return;
                }

                foreach (Student student in students)
                {
                    Helper.ConsoleText(ConsoleColor.DarkCyan, $"Student ID: {student.Id}\nStudent name: " +
                    $"{student.Name}\nStudent Surname: {student.Surname}\nStudent Age: {student.Age}\nStudent group : {student.Group.Name}");

                    Console.WriteLine("");
                }
            }
            else
            {
                Helper.ConsoleText(ConsoleColor.Red, "Incorrect search type!");
                goto FalseAge;
            }
        }

        public void GetAllByNameOrSurnameMethod()
        {
            List<Student> students = studentService.GetAll();

            if (students.Count == 0)
            {
                Helper.ConsoleText(ConsoleColor.Red, "There is no student yet!");
                return;
            }

        FalseName:
            Helper.ConsoleText(ConsoleColor.Green, "Enter the student name or surname:");
            string nameSearch = Console.ReadLine().Trim();

            if (int.TryParse(nameSearch, out _))
            {
                Helper.ConsoleText(ConsoleColor.Red, "Incorrect search type!");
                goto FalseName;
            }

            List<Student> studentsByName = studentService.SearchByName(Helper.Capitalize(nameSearch));
            List<Student> studentsBySurname = studentService.SearchBySurname(Helper.Capitalize(nameSearch));

            Helper.ConsoleText(ConsoleColor.Cyan, "Finding the data...");
            Thread.Sleep(1000);

            if (studentsByName.Count == 0 && studentsBySurname.Count == 0)
            {
                Helper.ConsoleText(ConsoleColor.Red, "There is no data found!");
                return;
            }

            foreach (Student student in studentsByName)
            {
                Console.WriteLine("");
                Helper.ConsoleText(ConsoleColor.DarkCyan,
                    $"Student ID: {student.Id}\nStudent name: {student.Name}\nStudent Surname: {student.Surname}\nStudent Age: {student.Age}\nStudent group : {student.Group.Name}");
                Console.WriteLine("");
            }

            foreach (Student student in studentsBySurname)
            {
                Console.WriteLine("");
                Helper.ConsoleText(ConsoleColor.DarkCyan,
                    $"Student ID: {student.Id}\nStudent name: {student.Name}\nStudent Surname: {student.Surname}\nStudent Age: {student.Age}\nStudent group : {student.Group.Name}");
                Console.WriteLine("");
            }
        }
    }
}