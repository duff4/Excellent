using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App2.Entities
{
    class TaskEntity : IScheduleAction
    {
        public string type
        {
            get { return "Task"; }
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool WithNotification { get; set; }
        public bool ShowOnDisplay { get; set; }
        [PrimaryKey, AutoIncrement, Unique]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public ScheduleActionPriority Priority { get; set; }
        public DateTimeOffset DeadLine { get; set; }
        public bool Completed { get; set; }
        public TaskEntityDifficulty Difficulty { get; set; }
        public string LecturerId { get; set; }
        public string ActivityId { get; set; }
        public DateTime Updated { get; set; }
    }
}
