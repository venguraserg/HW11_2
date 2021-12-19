using HW11.BL.Controller;
using HW11.BL.Model;
using System;
using System.Collections.Generic;

namespace Console_HW11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Client> clients = Client.AutoCompliteClient(10);
            Console.WriteLine("Вас приветствует инфосистема какого банка");
            Console.Write("Введите ваше имя:  ");
            var tempName = Console.ReadLine();
            
            var userController = new UserController(tempName);
            
            if (userController.IsNewUser)
            {
                Console.WriteLine($"Пользователя с именем {userController.CurentUser.Name} не зарегистриван");
                Console.WriteLine($"Вы будете зарегистрированы с именем {userController.CurentUser.Name} в качестве консультанта");
                Console.WriteLine("Для продолжения нажмите любую клавишу...");
                Console.ReadKey(true);
            }
            Console.Clear();


            if (userController.CurentUser.GetType() == typeof(Administrator)) MenuAdmin(ref userController);
            
            if (userController.CurentUser.GetType() == typeof(Consultant)) MenuConsult(ref userController);
           
            if (userController.CurentUser.GetType() == typeof(Manager)) MenuManager(ref userController);
            



            Console.ReadKey();

        }

        public static void MenuAdmin(ref UserController userController)
        {
            Console.WriteLine("Admin");
            userController.CurentUser = (Administrator)userController.CurentUser;
            userController.ChangeUserToManager("Serg");
        }
        public static void MenuConsult(ref UserController userController)
        {
            Console.WriteLine("Consult");
        }
        public static void MenuManager(ref UserController userController)
        {
            Console.WriteLine("Manager");
        }


    }
}
