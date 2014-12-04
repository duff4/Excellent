using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App2.Entities
{
    internal class PlaceEntity : IEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }

        [PrimaryKey, AutoIncrement, Unique]
        public Guid Id { get; set; }
    }
}
