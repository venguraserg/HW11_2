using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.BL.Model
{
    public class Client
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string PassNumber { get; set; }


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
