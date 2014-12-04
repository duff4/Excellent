using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App2.Entities
{
    interface IScheduleAction: IEntity
    {
        string Name { get; set; }
        string Description { get; set; }
        bool WithNotification { get; set; }
        bool ShowOnDisplay { get; set; }
        ScheduleActionPriority Priority { get; set; }
    }
}
