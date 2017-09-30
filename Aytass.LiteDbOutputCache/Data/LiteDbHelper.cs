using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aytass.LiteDbOutputCache.Data
{
    public class LiteDbHelper
    {
        private static readonly string Path = Constants.DbPath;
        public static bool Add<T>(T obj) where T : new()
        {
            using (LiteDatabase db = new LiteDatabase(Path))
            {
                var collection = db.GetCollection<T>(GetCollectionName(typeof(T)));

                bool result;
                try
                {
                    collection.Insert(obj);
                    result = true;
                }
                catch 
                {
                    result = false;
                }

                return result;
            }
        }
          
        public static bool Update<T>(T obj) where T : new()
        {
            using (LiteDatabase db = new LiteDatabase(Path))
            {
                var collection = db.GetCollection<T>(GetCollectionName(typeof(T)));
                var result = collection.Update(obj);
                return result;
            }
        }
         
        public static bool Delete<T>(object id) where T : new()
        {
            using (LiteDatabase db = new LiteDatabase(Path))
            {
                var collection = db.GetCollection<T>(GetCollectionName(typeof(T)));
                var result = collection.Delete(new BsonValue(id));
                return result;
            }
        }

        public static List<T> QueryAll<T>() where T : new()
        {
            using (LiteDatabase db = new LiteDatabase(Path))
            {
                var collection = db.GetCollection<T>(GetCollectionName(typeof(T)));
                var result = collection.FindAll().ToList();
                return result;
            }
        }

        public static LiteCollection<T> GetCollection<T>(string collectionName)
        {
            LiteCollection<T> list = null;
            using (var db = new LiteDatabase(Constants.DbPath))
            {
                list = db.GetCollection<T>(Constants.CollectionName);
            }

            return list;
        }

        private static string GetCollectionName(Type t)
        {
            return t.FullName?.Replace(".", "");
        }
    }
}
