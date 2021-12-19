using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.BL.Model
{
    public class Client
    {
        private string Surname { get; }
        private string Name { get;}
        private string Patronymic { get; }
        private string PhoneNumber { get; }
        private string PassNumber { get; }


        public Client(string surname, string name, string patronymic, string phoneNumber, string passNumber)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            PassNumber = passNumber;
        }
        /// <summary>
        /// Автогенерация списка клиентов
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static List<Client> AutoCompliteClient(int number)
        {
            List<Client> clients = new();
            for(int i=0; i< number; i++)
            {
                string tempGuid = Guid.NewGuid().ToString();
                string[] stringMassive = tempGuid.Split(new char[] { '-' });

                clients.Add(new Client(stringMassive[0], stringMassive[1], stringMassive[2], stringMassive[3], stringMassive[4]));
            }
            return clients;
        }
                
    }
}
