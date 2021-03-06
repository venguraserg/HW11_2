using HW11.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.BL.Model
{
    /// <summary>
    /// Класс описывающий Администратора,
    /// экземплят создается автоматически один раз при создании серилизованого файла
    /// назначение администратора изменять типы пользователей, так сказать изменять уровень доступа к информации
    /// </summary>
    public class Administrator : User
    {
       
        public Administrator() : base()
        {
            
            Name = "Admin";
            Status = "admin";
        }
        public Administrator(Guid id, string name, string status) : base(id, name, status)
        {

        }

        public override Client DeleteClient(Client client)
        {
            throw new NotImplementedException();
        }

        public override List<Client> GetAllClient(List<Client> clients)
        {
            return clients;
        }

        public override Client UpdateClient(string surname, string name, string patronymic, string phoneNumber, string passNumber, Client client)
        {
            return client;
        }
    }
}
