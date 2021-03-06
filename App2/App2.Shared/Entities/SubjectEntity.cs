﻿/*
 * Excellent - Student Organizer
 * Copyright (c ) 2014, Alexander Davydov, All rights reserved.
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3.0 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library.
 */

using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App2.Entities
{
    class SubjectEntity : IActivityEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [PrimaryKey, AutoIncrement, Unique]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public EvaluationType EvaluationType { get; set; }
        public DateTime Updated { get; set; }
    }
}
