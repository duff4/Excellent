﻿using System;
using System.Collections.Generic;
using System.Text;
using App1.Entities;
using SQLite;

namespace App2.Entities
{
    interface IActivityEntity : IEntity
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}