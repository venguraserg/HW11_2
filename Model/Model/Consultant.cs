using HW11.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.BL.Model
{
    public class Consultant : User
    {
        public Consultant(string name) : base(name)
        {
            Status = "consultant";
        }
        public Consultant(Guid id, string name, string status) : base(id, name, status)
        {
            
        }

        public override Client DeleteClient(Client client)
        {
            return null;
        }

        public override List<Client> GetAllClient(List<Client> clients)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].PassNumber != null) clients[i].PassNumber = "*************";
            } 
            return clients;
        }

        public override Client UpdateClient(string surname, string name, string patronymic, string phoneNumber, string passNumber, Client client)
        {
            return new Client(client.Surname, client.Name, client.Patronymic, phoneNumber, client.PassNumber);
        }
    }
}
