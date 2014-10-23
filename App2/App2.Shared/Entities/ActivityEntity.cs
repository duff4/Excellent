using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace App1.Entities
{
    class ActivityEntity : IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [PrimaryKey, AutoIncrement, Unique]
        public Guid Id { get; set; }
    }
}
