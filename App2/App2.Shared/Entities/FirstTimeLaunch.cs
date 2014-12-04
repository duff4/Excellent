using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App2.Entities
{
    class FirstTimeLaunch : IEntity
    {
        public bool IsFirstTimeLaunch;
        [PrimaryKey, AutoIncrement, Unique]
        public Guid Id { get; set; }
    }
}
