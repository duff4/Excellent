/*
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
using App2.Entities;
using SQLite;

namespace App2.Pages
{
    public class ServerCredentials: IEntity
    {
        public string login { get; set; }
        //public string id { get; set; }
        public string email { get; set; }
        public string birthday { get; set; }

        [PrimaryKey, AutoIncrement, Unique]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Cookies { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}