using System;
using SQLite;

namespace App2.Entities
{
    class Entity : IEntity
    {
        [PrimaryKey, AutoIncrement, Unique]
        public Guid Id { get; set; }
    }
}
