using System;
using SQLite;

namespace App2.Entities
{
    public interface IEntity
    {
        [PrimaryKey, AutoIncrement, Unique]
        Guid Id { get; set; }

        Guid UserId { get; set; }
    }
}
