using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.BL.Model
{
    /// <summary>
    /// Класс описывающий Администратора,
    /// экземплят создается автоматически один раз при создании серилизованого файла
    /// назначение администратора изменять типы пользователей, так сказать изменять уровень доступа к информации
    /// </summary>
    public class Administrator : User
    {
       
        public Administrator() : base()
        {
            
            Name = "Admin";
            Status = "admin";
        }
        public Administrator(Guid id, string name, string status) : base(id, name, status)
        {

        }

        public void ChangeUsertType(ref List<User> users)
        {

        }


        

    }
}
