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
    public class ClientController : BaseController
    {
        private static readonly string CLIENT_FILE_NAME = "clients.json"; 

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
        /// Конструктор с загрузкой клиентов из файла
        /// </summary>
        public ClientController()
        {
            this.Clients = Load();

        }

        /// <summary>
        /// Получение клиента по индексу
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public Client GetClient(int number)
        {            
            return this.Clients[number - 1];
        }




        /// <summary>
        /// Серилизация клиентов в json файл
        /// </summary>
        private void Save()
        {
            base.Save<Client>(CLIENT_FILE_NAME, Clients);          
        }

        /// <summary>
        /// Десерилизация клиентов
        /// </summary>
        /// <returns></returns>
        private List<Client> Load()
        {            
            return Load<Client>(CLIENT_FILE_NAME);
        }


    }
}
