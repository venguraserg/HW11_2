using HW11.BL.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.BL.Controller
{
    public class ClientController
    {
        private static readonly string USER_FILE_NAME = "clients.json"; 

        public List<Client> Clients { get; set; }

        /// <summary>
        /// Конструктор с автозаполнением
        /// </summary>
        /// <param name="number"></param>
        public ClientController(int number)
        {
            Clients = new List<Client>();
            for (int i = 0; i < number; i++)
            {
                string tempGuid = Guid.NewGuid().ToString();
                string[] stringMassive = tempGuid.Split(new char[] { '-' });

                Clients.Add(new Client(stringMassive[0], stringMassive[1], stringMassive[2], stringMassive[3], stringMassive[4]));
            }
            Save();
        }

        /// <summary>
        /// Серилизация пользователей в json файл
        /// </summary>
        private void Save()
        {
            if (File.Exists(USER_FILE_NAME) == false)
            {
                using (File.Create(USER_FILE_NAME)) { };
            }

            string json = JsonConvert.SerializeObject(Clients);
            File.WriteAllText(USER_FILE_NAME, json);

        }


    }
}
