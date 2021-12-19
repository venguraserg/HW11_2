using System;
using System.Collections.Generic;
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

    }
}
