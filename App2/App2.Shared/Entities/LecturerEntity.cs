using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace App1.Entities
{
    class LecturerEntity : IEntity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AdditionalInformation { get; set; }
        [PrimaryKey, AutoIncrement, Unique]
        public Guid Id { get; set; }
    }
}
