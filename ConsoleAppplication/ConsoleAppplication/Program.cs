using ConsoleApplication.Presentation.Controllers;
using ConsoleApplication.Presentation.Helpers;

namespace ConsoleApplication.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GroupController groupController = new GroupController();
            StudentController studentController = new StudentController();

            Helper.ConsoleText(ConsoleColor.DarkBlue, "Welcome to the Acedemy System! Select an option.");
        SelectOption: Helper.ConsoleText(ConsoleColor.Cyan, "1 - Create group, 2 - Update group, 3 - Delete group, 4 - Get group by id, " +
            "5 - Get all groups by teacher, 6 - Get all groups by room, 7 - Get all groups, 8 - Create Student, 9 - Update Student, 10 - Get " +
            "student by id, 11 - Delete student, 12 - Get students by age, 13 - Get all students by group id, 14 - Search method for groups by " +
            "name, 15 - Search method for students by name or surname");

            while (true)
            {
                string selectOption = Console.ReadLine();
                int selectTrueOption;

                bool isSelectOption = int.TryParse(selectOption, out selectTrueOption);

                if (selectTrueOption >= 16)
                {
                    Helper.ConsoleText(ConsoleColor.Red, "Select a correct option!");
                    goto SelectOption;
                }
                if (isSelectOption)
                {
                    switch (selectTrueOption)
                    {
                        case (int)Menus.CreateGroup:
                            groupController.CreateMethod(selectTrueOption);
                            goto SelectOption;
                        case (int)Menus.UpdateGroup:
                            groupController.UpdateMethod(selectTrueOption);
                            goto SelectOption;
                        case (int)Menus.DeleteGroup:
                            groupController.DeleteMethod();
                            goto SelectOption;
                        case (int)Menus.GetgroupById:
                            groupController.GetByIdMethod();
                            goto SelectOption;
                        case (int)Menus.GetAllGroupsByTeacher:
                            groupController.GetAllByTeacherMethod();
                            goto SelectOption;
                        case (int)Menus.GetAllGroupsByRoom:
                            groupController.GetAllByRoomMethod();
                            goto SelectOption;
                        case (int)Menus.GetAllGroups:
                            groupController.GetAllMethod();
                            goto SelectOption;
                        case (int)Menus.CreateStudent:
                            studentController.CreateMethod();
                            goto SelectOption;
                        case (int)Menus.UpdateStudent:
                            studentController.UpdateMethod(selectTrueOption);
                            goto SelectOption;
                        case (int)Menus.DeleteStudent:
                            studentController.DeleteMethod();
                            goto SelectOption;
                        case (int)Menus.GetStudentsByAge:
                            studentController.GetAllByAgeMethod();
                            goto SelectOption;
                        case (int)Menus.GetStudentById:
                            studentController.GetByIdMethod();
                            goto SelectOption;
                        case (int)Menus.GetAllStudentsByGroupId:
                            studentController.GetAllByGroupIdMethod();
                            goto SelectOption;
                        case (int)Menus.SearchMethodForGroupsByName:
                            groupController.GetGroupByName();
                            goto SelectOption;
                        case (int)Menus.SearchMethodForStudentsByNameOrSurname:
                            studentController.GetAllByNameOrSurnameMethod();
                            goto SelectOption;
                    }
                }
                else
                {
                    Helper.ConsoleText(ConsoleColor.Red, "Select a correct option type!");
                    goto SelectOption;
                }
            }
        }
    }
}