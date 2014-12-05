using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App2.Entities
{
    class MarkEntity : IEntity
    {
        [PrimaryKey, AutoIncrement, Unique]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public float Value { get; set; }
    }
}
