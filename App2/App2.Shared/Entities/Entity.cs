using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace App1.Entities
{
    class Entity : IEntity
    {
        [PrimaryKey, AutoIncrement, Unique]
        public Guid Id { get; set; }
    }
}
