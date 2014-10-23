using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using SQLite;

namespace App1.Entities
{
    public static class GenericRepo<TEntity> where TEntity : class, IEntity, new()
    {
        public static string DatabasePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "db.sqlite");

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

        public static int Update(object objectToUpdate)
        {
            var sqldbConnection = new SQLiteConnection(DatabasePath);

            return sqldbConnection.Update(objectToUpdate);
        }

        public static int Delete(object objectToDelete)
        {
            var sqldbConnection = new SQLiteConnection(DatabasePath);

            return sqldbConnection.Delete<TEntity>(objectToDelete);
        }

        public static TEntity Get(object primaryKey)
        {
            var sqldbConnection = new SQLiteConnection(DatabasePath);

            return sqldbConnection.Get<TEntity>(primaryKey);
        }

        public static ObservableCollection<TEntity> GetSome(int quantity = -1)
        {
            var sqldbConnection = new SQLiteConnection(DatabasePath);
            var itemsToAdd = new ObservableCollection<TEntity>();

            if (quantity == -1)
            {
                foreach (var entity in sqldbConnection.Table<TEntity>())
                {
                    itemsToAdd.Add(entity);
                }
                return itemsToAdd;
            }

            return itemsToAdd;
            //var itemsToAdd = sqldbConnection.Table<TEntity>().Take(quantity);

            //return itemsToAdd as ObservableCollection<TEntity>;
        }
    }
}

