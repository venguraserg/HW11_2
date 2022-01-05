using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.BL.Model
{
    /// <summary>
    /// Вспомогательный класс для проведения десирилизации, так как с абстракным не работает
    /// </summary>
    public class UserDeserilize : User
    {
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="status"></param>
        public UserDeserilize(Guid id, string name, string status) : base(id, name, status) { }

        public override List<Client> GetAllClient(List<Client> clients)
        {
            return null;
        }

        public override Client UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
