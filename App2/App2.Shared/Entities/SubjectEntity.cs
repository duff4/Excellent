using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App2.Entities
{
    class SubjectEntity : IActivityEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [PrimaryKey, AutoIncrement, Unique]
        public Guid Id { get; set; }
    }
}
