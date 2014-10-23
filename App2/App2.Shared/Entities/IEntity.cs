using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace App1.Entities
{
    public interface IEntity
    {
        [PrimaryKey, AutoIncrement, Unique]
        Guid Id { get; set; }
    }
}
