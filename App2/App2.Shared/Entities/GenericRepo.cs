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

using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Windows.Storage;
using SQLite;

namespace App2.Entities
{
    public static class GenericRepo<TEntity> where TEntity : class, IEntity, new()
    {
        private static string DatabasePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "db.sqlite");

        public static void CreateTable()
        {
            var sqldbConnection = new SQLiteConnection(DatabasePath);

            sqldbConnection.CreateTable<TEntity>();
        }

        public static int Insert(object objectToInsert)
        {
            var sqldbConnection = new SQLiteConnection(DatabasePath);

            return sqldbConnection.Insert(objectToInsert);
        }

        public static int Update(IEnumerable objectsToUpdate)
        {
            var sqldbConnection = new SQLiteConnection(DatabasePath);

            return sqldbConnection.UpdateAll(objectsToUpdate);
        }

        public static int Delete(object primaryKey)
        {
            var sqldbConnection = new SQLiteConnection(DatabasePath);

            return sqldbConnection.Delete<TEntity>(primaryKey);
        }

        public static void DeleteAll()
        {
            var sqldbConnection = new SQLiteConnection(DatabasePath);

            sqldbConnection.DeleteAll<TEntity>();
        }

        public static TEntity Get(object primaryKey)
        {
            var sqldbConnection = new SQLiteConnection(DatabasePath);

            return sqldbConnection.Get<TEntity>(primaryKey);
        }

        public static ObservableCollection<TEntity> GetAll()
        {
            var sqldbConnection = new SQLiteConnection(DatabasePath);
            var itemsToAdd = new ObservableCollection<TEntity>();

            foreach (var entity in sqldbConnection.Table<TEntity>())
            {
                itemsToAdd.Add(entity);
            }
            return itemsToAdd;
        }

        public static TEntity GetFirst()
        {
            var sqldbConnection = new SQLiteConnection(DatabasePath);

            return sqldbConnection.Table<TEntity>().Any() ? sqldbConnection.Table<TEntity>().ElementAt(0) : null;
        }

    }
}

