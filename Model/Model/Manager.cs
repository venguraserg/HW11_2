using System;
using System.Collections.Generic;
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

    }
}
