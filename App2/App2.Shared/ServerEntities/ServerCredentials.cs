using System;
using App2.Entities;
using SQLite;

namespace App2.Pages
{
    public class ServerCredentials: IEntity
    {
        public string login { get; set; }
        //public string id { get; set; }
        public string email { get; set; }
        public string birthday { get; set; }

        [PrimaryKey, AutoIncrement, Unique]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Cookies { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}