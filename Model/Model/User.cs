using HW11.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HW11.BL.Model
{
    public abstract class User : IWorkWithClient
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Status { get; set; }
        #region Конструкторы
        protected User(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public User(Guid id, string name, string status)
        {
            Id = id;
            Name = name;
            Status = status;
        }

        public User()
        {
            Id = Guid.Empty;
        }
        #endregion

        #region Методы
        public abstract List<Client> GetAllClient(List<Client> clients);
        public abstract Client UpdateClient(string surname, string name, string patronymic, string phoneNumber, string passNumber, Client client);
        public abstract Client DeleteClient(Client client);


        #endregion

        public override string ToString()
        {
            return $"{Name}  {Status}";
        }

       
    }
}
