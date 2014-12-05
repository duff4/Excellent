﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App2.Entities
{
    class EventEntity : IScheduleAction
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool WithNotification { get; set; }
        public bool ShowOnDisplay { get; set; }
        [PrimaryKey, AutoIncrement, Unique]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public ScheduleActionPriority Priority { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string Place { get; set; }
        public DateTime Updated { get; set; }
    }
}
