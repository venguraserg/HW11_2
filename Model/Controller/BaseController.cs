using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.BL.Controller
{
    public class BaseController
    {
        /// <summary>
        /// Серилизация  в json файл
        /// </summary>
        public void Save<T>(string fileName, List<T> items)
        {
            if (File.Exists(fileName) == false)
            {
                using (File.Create(fileName)) { };
            }

            string json = JsonConvert.SerializeObject(items);
            File.WriteAllText(fileName, json);

        }

        /// <summary>
        /// Получение списка всех пользователей
        /// </summary>
        /// <returns></returns>
        public List<T> Load<T>(string fileName) where T : class
        {
            List<T> tempItems = new List<T>();

            if (File.Exists(fileName) == false)
            {
                using (File.Create(fileName)) { };
                List<T> tempItemList = new();
                return tempItemList;
            }
            else
            {
                string json = File.ReadAllText(fileName);
                if (string.IsNullOrEmpty(json)) return new List<T>();

                
                
                var items = JsonConvert.DeserializeObject<List<T>> (json);

                return items;
            }
        }

    } 
}
