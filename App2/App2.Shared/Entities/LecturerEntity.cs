using System;
using SQLite;

namespace App2.Entities
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
