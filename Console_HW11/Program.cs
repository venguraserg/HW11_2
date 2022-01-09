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
            //Создание списка клиентов методом автоматической генерации для тестирования
            //var clientController = new ClientController(50);
            var clientController = new ClientController();


            //Ввод имени пользователя
            //пароль применять не стал изза соображений скорости
            //можно добавть поле пароля и прверять по хешу
            Console.WriteLine("Вас приветствует инфосистема какого банка");
            UserController userController = InputUser();


            //*************************
            //Такое себе меню
            //*************************
            bool quit = false;
            while (!quit)
            {
                Console.Clear();
                Console.WriteLine($"Пользователь - {userController.CurentUser.Name}, статус - {userController.CurentUser.Status}");
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("                                M E N U                             ");
                Console.WriteLine("--------------------------------------------------------------------");
                if (userController.CurentUser is Administrator)
                {
                    //Так как любой новый пользователь вносится в список как консультант
                    //администратор может поменять статус сотрудника
                    Console.WriteLine("Вы наделены лишь правом изменить статус сотрудника");
                    Console.WriteLine("Консультант <-> Менеджер");
                    Console.WriteLine("C - изменить статус пользователя");
                    Console.WriteLine("N - смена пользователя");
                    Console.WriteLine("Q - выход из приложения");
                    var key = Console.ReadKey();
                    Console.WriteLine();
                    switch (key.Key)
                    {
                        case ConsoleKey.C:
                            Console.WriteLine("--------------------------------------------------------------------");
                            Console.WriteLine("                         СПИСОК СОТРУДНИКОВ                         ");
                            Console.WriteLine("--------------------------------------------------------------------");
                            for (int i = 0; i < userController.Users.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}.{userController.Users[i].Name}   {userController.Users[i].Status}");
                            }
                            Console.Write("Введите имя сотрудника: ");
                            string nameUserChangeStatus = Console.ReadLine();
                            if (userController.ChangeUserStatus(nameUserChangeStatus))
                            {
                                Console.WriteLine("Данные изменены");
                            }
                            else
                            {
                                Console.WriteLine($"Пользователь с именем {nameUserChangeStatus} не найден");
                            }
                            Console.WriteLine("Для продолжения нажмите любую клавишу...");
                            Console.ReadKey();
                            break;
                        case ConsoleKey.N:
                            userController = InputUser();
                            break;
                        case ConsoleKey.Q:
                            quit = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("V - просмотр клиентов");
                    Console.WriteLine("C - редактировать клиента");
                    Console.WriteLine("N - смена пользователя");
                    Console.WriteLine("Q - выход из приложения");

                    var key = Console.ReadKey();
                    Console.WriteLine();
                    switch (key.Key)
                    {
                        case ConsoleKey.V:
                            PrintUsers(userController.GetAllClient());
                            Console.ReadKey();
                            break;

                        case ConsoleKey.C:
                            // изменения данных клиента
                            PrintUsers(userController.GetAllClient());
                            Console.WriteLine("--------------------------------------------------------------------");
                            Console.WriteLine("Введите номер клиента");
                            var clientNumber = int.Parse(Console.ReadLine());
                            var currentClient = clientController.GetClient(clientNumber);
                            if(userController.CurentUser is Consultant)
                            {

                            }
                            else
                            {

                            }
                            
                            break;

                        case ConsoleKey.N:
                            userController = InputUser();
                            break;

                        case ConsoleKey.Q:
                            quit = true;
                            break;
                        default:
                            break;
                    }

                }
                
            }

            Console.WriteLine("Конец программы, нажмите любую клавишу...");
            Console.ReadKey();
        }

        /// <summary>
        /// Выбор пользователя
        /// </summary>
        /// <returns></returns>
        private static UserController InputUser()
        {
            Console.Write("Введите ваше имя:  ");
            var tempName = Console.ReadLine();

            var userController = new UserController(tempName);

            if (userController.IsNewUser)
            {
                Console.WriteLine($"Пользователя с именем {userController.CurentUser.Name} не зарегистриван");
                Console.WriteLine($"Вы будете зарегистрированы с именем {userController.CurentUser.Name} в качестве консультанта");
                Console.WriteLine("Для продолжения нажмите любую клавишу...");
            }
            else
            {
                Console.WriteLine($"Здраствуйте {userController.CurentUser.Name} вы {userController.CurentUser.GetType().Name}");
                Console.WriteLine("Для продолжения нажмите любую клавишу...");
            }

            Console.ReadKey(true);
            return userController;
        }

        /// <summary>
        /// Метод вывода клиентов на экран
        /// </summary>
        /// <param name="tempClient"></param>
        private static void PrintUsers(List<Client> tempClient)
        {
            Console.WriteLine("№п/п Имя   Фамилия   Отч. №тел   №паспорта");
            for (int i = 0; i < tempClient.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {tempClient[i].Name}  {tempClient[i].Surname}  {tempClient[i].Patronymic} {tempClient[i].PhoneNumber}  {tempClient[i].PassNumber}");
            }

        }




    }
}
