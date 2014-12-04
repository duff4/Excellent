using System;
using SQLite;

namespace App2.Entities
{
    class ActivityEntity : IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [PrimaryKey, AutoIncrement, Unique]
        public Guid Id { get; set; }
    }
}
