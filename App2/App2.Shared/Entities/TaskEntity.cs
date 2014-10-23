using System;
using System.Collections.Generic;
using System.Text;
using App1.Entities;
using SQLite;

namespace App2.Entities
{
    class TaskEntity : IScheduleAction
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool WithNotification { get; set; }
        public bool ShowOnDisplay { get; set; }
        [PrimaryKey, AutoIncrement, Unique]
        public Guid Id { get; set; }
        public ScheduleActionPriority Priority { get; set; }
        public DateTimeOffset DeadLine { get; set; }
        public bool IsCompleted { get; set; }
        public TaskEntityDifficulty Difficulty { get; set; }
        public string Lecturer { get; set; }
        public string Subject { get; set; }
    }
}
