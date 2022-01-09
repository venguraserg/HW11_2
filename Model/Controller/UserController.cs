﻿using HW11.BL.Interfaces;
using HW11.BL.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HW11.BL.Controller
{
    /// <summary>
    /// Класс котроллера пользователя
    /// </summary>
    public class UserController : BaseController
    {

        private static readonly string USER_FILE_NAME = "users.json";
        private static readonly string CLIENT_FILE_NAME = "clients.json";
        /// <summary>
        /// Коллекция пользователей
        /// </summary>
        public List<User> Users { get; set; }
        /// <summary>
        /// Текущий пользователь
        /// </summary>
        public User CurentUser { get; set; }
        /// <summary>
        /// Новый ли пользователь?
        /// </summary>
        public bool IsNewUser { get; } = false;
        /// <summary>
        /// Список клиентов
        /// </summary>
        public List<Client> Clients { get; set; }        

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="userName">имя пользователя</param>
        public UserController(string userName)
        {
            this.Users = LoadUser();

            CurentUser = Users.SingleOrDefault(u => u.Name == userName);
            if(CurentUser == null)
            {
                CurentUser = new Consultant(userName);
                Users.Add((User)CurentUser);
                IsNewUser = true;
                Save();
            }
            Clients = LoadClients();            
        }
        
        /// <summary>
        /// Автозаполнение клиентов для теста
        /// </summary>
        /// <param name="number"></param>
        public void ClientAutofill(int number)
        {
            Clients = new List<Client>();
            for (int i = 0; i < number; i++)
            {
                string tempGuid = Guid.NewGuid().ToString();
                string[] stringMassive = tempGuid.Split(new char[] { '-' });

                Clients.Add(new Client(stringMassive[0], stringMassive[1], stringMassive[2], stringMassive[3], stringMassive[4]));
            }
            Save();
        }

        /// <summary>
        /// Метод смены типа консультанта на клиента
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ChangeUserStatus(string name)
        {
            if(CurentUser is Administrator)
            {
                int index;
                User user = Users.SingleOrDefault(u => u.Name == name);
                if (user != null)
                {
                    index = Users.IndexOf(user);

                    switch (user.Status)
                    {
                        case "consultant":
                            Users[index] = new Manager(user.Id, user.Name, "manager");
                            break;
                        case "manager":
                            Users[index] = new Consultant(user.Id, user.Name, "consultant");
                            break;
                        default:
                            break;
                    }
                                        
                    Save();
                    return true;
                }
            }
            return false;
        }
        


        /// <summary>
        /// Получение списка всех пользователей
        /// </summary>
        /// <returns></returns>
        private List<User> LoadUser()
        {
            List<User> tempUsers = new List<User>();
            var loadData = Load<UserDeserilize>(USER_FILE_NAME);

            if (loadData.Count < 1) { tempUsers.Add(new Administrator()); }

            for (int i = 0; i < loadData.Count; i++)
            {
                switch (loadData[i].Status)
                {
                    case "consultant":
                        tempUsers.Add(new Consultant(loadData[i].Id, loadData[i].Name, loadData[i].Status));
                        break;
                    case "manager":
                        tempUsers.Add(new Manager(loadData[i].Id, loadData[i].Name, loadData[i].Status));
                        break;
                    case "admin":
                        tempUsers.Add(new Administrator(loadData[i].Id, loadData[i].Name, loadData[i].Status));
                        break;
                    default:                            
                        break;
                }
            }
            return tempUsers;

        }
        private List<Client> LoadClients()
        {
            return Load<Client>(CLIENT_FILE_NAME);
        }

        public bool AddClient(string tempSurname, string tempName, string tempPatronymic, string tempPhoneNumber, string tempPassNumber)
        {
            Client newClient = new Client(tempSurname, tempName, tempPatronymic, tempPhoneNumber, tempPassNumber);
            var findItem = Clients.Contains(newClient);
            if (findItem == false) 
            { 
                Clients.Add(newClient);
                Save();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Серилизация пользователей в json файл
        /// </summary>
        private void Save()
        {
            base.Save<User>(USER_FILE_NAME, Users);
            base.Save<Client>(CLIENT_FILE_NAME, Clients);
        }

        public List<Client> GetAllClient()
        {
            return CurentUser.GetAllClient(Clients);
        }

        public void UpdateClient(string surname, string name, string patronymic, string phoneNumber, string passNumber, Client client)
        {
            var newClient = CurentUser.UpdateClient(surname, name, patronymic, phoneNumber, passNumber, client);
            var index = Clients.IndexOf(client);
            if (index != -1)
            {
                Clients[index] = newClient;
                Save();
            }
        }

        public bool DeleteClient(Client client)
        {
            if (CurentUser.DeleteClient(client) != null)
            {

                var index = Clients.IndexOf(client);
                Clients.RemoveAt(index);
                Save();
                return true;
            }
            return false;
            
        }
    }
}
