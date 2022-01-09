using HW11.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.BL.Model
{
    public class Manager : User
    {

        public Manager(string name) : base(name)
        {
            Status = "manager";
        }
        public Manager(Guid id, string name, string status) : base(id, name, status)
        {

        }

        public override Client DeleteClient(Client client)
        {
            return client;
        }

        public override List<Client> GetAllClient(List<Client> clients)
        {
            return clients;
        }

        public override Client UpdateClient(string surname, string name, string patronymic, string phoneNumber, string passNumber, Client client)
        {
            return new Client(surname, name, patronymic, phoneNumber, passNumber);
        }
    }
}
