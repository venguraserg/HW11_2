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

        Client UpdateClient(string surname, string name, string patronymic, string phoneNumber, string passNumber, Client currentClient);
        Client DeleteClient(Client client);
    }
}
