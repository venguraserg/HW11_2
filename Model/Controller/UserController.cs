using HW11.BL.Interfaces;
using HW11.BL.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HW11.BL.Controller
{
    /// <summary>
    /// Класс котроллера пользователя
    /// </summary>
    public class UserController : BaseController , IWorkWithClient
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
        /// <summary>
        /// Новый ли пользователь?
        /// </summary>
        public bool IsNewUser { get; } = false;

        

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="userName">имя пользователя</param>
        public UserController(string userName)
        {
            this.Users = Load();

            CurentUser = Users.SingleOrDefault(u => u.Name == userName);
            if(CurentUser == null)
            {
                CurentUser = new Consultant(userName);
                Users.Add((User)CurentUser);
                IsNewUser = true;
                Save();
            }
            
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
        private List<User> Load()
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

        /// <summary>
        /// Серилизация пользователей в json файл
        /// </summary>
        private void Save()
        {
            base.Save<User>(USER_FILE_NAME, Users);
        }

        public List<Client> GetAllClient(List<Client> clients)
        {
            return CurentUser.GetAllClient(clients);
        }

        public Client UpdateClient()
        {
            throw new System.NotImplementedException();
        }
    }
}
