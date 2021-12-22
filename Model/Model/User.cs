﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HW11.BL.Model
{
    public abstract class User
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
        public virtual ObservableCollection<Client> GetAllClient(ObservableCollection<Client> clients)
        {
            return clients;
        }







        #endregion

        public override string ToString()
        {
            return $"{Name}";
        }



    }
}
