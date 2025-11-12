using ConsoleAppplication.Controllers;
using Service.Enums;

namespace ConsoleAppplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowMenu();
            GroupController groupController = new GroupController();

            while (true)
            {
            Input: string input = Console.ReadLine();
                int number;

                bool isConvert = int.TryParse(input, out number);

                if (isConvert)
                {
                    switch (number)
                    {
                        case (int)GroupMethod.Create:
                            groupController.Create();
                            break;
                        case (int)GroupMethod.Update:
                            groupController.Update();
                            break;
                        case (int)GroupMethod.Delete:
                            groupController.Delete();
                            break;
                        case (int)GroupMethod.GetById:
                            groupController.GetById();
                            break;
                        case (int)GroupMethod.GetAll:
                            groupController.GetAll();
                            break;
                        case (int)GroupMethod.Exit:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Select option is not correct!");
                            goto Input;

                    }
                }
                else
                {
                    Console.WriteLine("Input is not correct type!");
                    goto Input;
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Select option:");
            Console.WriteLine("1. Create Group");
            Console.WriteLine("2. Update Group");
            Console.WriteLine("3. Delete Group");
            Console.WriteLine("4. GetById Group");
            Console.WriteLine("5. GetAll Groups");
            Console.WriteLine("0. Exit");
        }
    }
}
