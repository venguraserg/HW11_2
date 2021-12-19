using HW11.BL.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.BL.Controller
{
    public class UserController
    {
        private static readonly string USER_FILE_NAME = "users.json";
        /// <summary>
        /// Коллекция пользователей
        /// </summary>
        public List<User> Users { get; set; }
        /// <summary>
        /// Текущий пользователь
        /// </summary>
        public User CurentUser { get; set; }
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="userName">имя пользователя</param>
        public UserController(string userName)
        {
            this.Users = GetUserData();

            CurentUser = Users.SingleOrDefault(u => u.Name == userName);
            if(CurentUser == null)
            {
                CurentUser = new Consultant(userName);
                Users.Add(CurentUser);
                IsNewUser = true;
                Save();
            }
        }

        public void ChangeUserToManager(string name)
        {
            if(CurentUser is Administrator)
            {
                int index;
                User user = (User)Users.SingleOrDefault(u => u.Name == name);
                if (user != null)
                {
                    index = Users.IndexOf(user);
                    Users[index] =  (Manager)user;
                }
                
                
                





            }
        }
        


        /// <summary>
        /// Получение списка всех пользователей
        /// </summary>
        /// <returns></returns>
        private List<User> GetUserData()
        {
            List<User> tempUsers = new List<User>();

            if (File.Exists(USER_FILE_NAME) == false)
            {
                using (File.Create(USER_FILE_NAME)) { };
                List<User> tempUserList = new();
                tempUserList.Add(new Administrator());
                return tempUserList;
            }
            else
            {
                string json = File.ReadAllText(USER_FILE_NAME);
                if(string.IsNullOrEmpty(json)) return new List<User>();
                var users = JsonConvert.DeserializeObject<List<User>>(json);

                for(int i = 0; i < users.Count; i++)
                {
                    switch (users[i].Status)
                    {
                        case "consultant":
                            tempUsers.Add(new Consultant(users[i].Id, users[i].Name, users[i].Status));
                            break;
                        case "manager":
                            tempUsers.Add(new Manager(users[i].Id, users[i].Name, users[i].Status));
                            break;
                        case "admin":
                            tempUsers.Add(new Administrator(users[i].Id, users[i].Name, users[i].Status));
                            break;
                        default:                            
                            break;
                    }
                }


                return tempUsers;
            }
        }

        /// <summary>
        /// Серилизация пользователей в json файл
        /// </summary>
        private void Save()
        {
            if (File.Exists(USER_FILE_NAME) == false)
            {
                using (File.Create(USER_FILE_NAME)) { };                
            }

            string json = JsonConvert.SerializeObject(Users);
            File.WriteAllText(USER_FILE_NAME, json);

        }

        


    }
}
