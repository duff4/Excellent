using System;
using SQLite;

namespace App2.Entities
{
    class ScheduleActionEntity : IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool WithNotification { get; set; }
        public bool ShowOnDisplay { get; set; }
        [PrimaryKey, AutoIncrement, Unique]
        public Guid Id { get; set; }
        public ScheduleActionPriority Priority { get; set; }
    }
}
