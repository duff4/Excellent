using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SQLite;

namespace App2.Entities
{
    class Language : IEntity
    {
        public string SelectedCultureString { get; set; }

        [PrimaryKey, AutoIncrement, Unique]
        public Guid Id { get; set; }
    }
}
