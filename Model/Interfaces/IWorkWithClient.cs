using HW11.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.BL.Interfaces
{
    public interface IWorkWithClient
    {

        List<Client> GetAllClient(List<Client> clients);

        //Client UpdateClient();

    }
}
