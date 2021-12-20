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

            Console.WriteLine($"Здраствуйте {userController.CurentUser.Name} вы {userController.CurentUser.GetType().Name}");
            switch (userController.CurentUser.GetType().Name)
            {
                case "Administrator":
                    Console.WriteLine("Вы наделены лишь правом изменить статус сотрудника");
                    Console.WriteLine("Консультант <-> Менеджер");
                    Console.WriteLine("--------------------------------------------------------------------");
                    Console.WriteLine("                         СПИСОК СОТРУДНИКОВ                         ");
                    for(int i=0;i<userController.Users.Count;i++)
                    {
                        Console.WriteLine($"{i+1}.{userController.Users[i].Name}   {userController.Users[i].Status}");
                    }
                    Console.Write("Введите имя сотрудника: ");
                    var nameUserChangeStatus = Console.ReadLine();
                    if (userController.ChangeUserStatus(nameUserChangeStatus))
                        Console.WriteLine("Данные изменены");
                    else
                        Console.WriteLine($"Пользователь с именем {nameUserChangeStatus} не найден");
                    break;


                case "Consultant":
                    var tempClient = userController.CurentUser.GetAllClient(clients);
                    for (int i = 0; i < tempClient.Count; i++)
                    {
                        Console.WriteLine($"{i+1}. {tempClient[i].Name}  {tempClient[i].Surname}  {tempClient[i].Patronymic} {tempClient[i].PhoneNumber}  {tempClient[i].PassNumber}");
                    }
                    
                    break;
                case "Manager":
                   tempClient = userController.CurentUser.GetAllClient(clients);
                    for (int i = 0; i < tempClient.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {tempClient[i].Name}  {tempClient[i].Surname}  {tempClient[i].Patronymic} {tempClient[i].PhoneNumber}  {tempClient[i].PassNumber}");
                    }
                    break;

                default:
                    break;
            }

            Console.WriteLine("Конец программы, нажмите любую клавишу...");
            Console.ReadKey();

        }

       
       


    }
}
