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
        public override ObservableCollection<Client> GetAllClient(ObservableCollection<Client> clients)
        {
            //for (int i = 0; i < clients.Count; i++)
            //{
            //    if (clients[i].PassNumber != null) clients[i].PassNumber = "*************";
            //}
            return clients;
        }

    }
}
