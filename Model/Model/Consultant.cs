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



        public override List<Client> GetAllClient(List<Client> clients)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].PassNumber != null) clients[i].PassNumber = "*************";
            } 
            return clients;
        }

        //public override Client UpdateClient(string f)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
