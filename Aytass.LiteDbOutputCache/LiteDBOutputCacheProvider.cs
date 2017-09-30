using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Caching;
using System.Linq;
using Aytass.LiteDbOutputCache.Data;
using LiteDB;

namespace Aytass.LiteDbOutputCache
{
    /// <summary>
    /// Output cache provider.
    /// </summary>
    /// <remarks>http://msdn.microsoft.com/en-us/magazine/gg650661.aspx</remarks>
    public class LiteDbOutputCacheProvider : OutputCacheProvider
    {
        
        private readonly string _collectionName;

        public LiteDbOutputCacheProvider()
        { 
            _collectionName = Constants.CollectionName;
        }

        public override object Add(string key, object entry, DateTime utcExpiry)
        {

           var item =  LiteDbHelper.QueryAll<CacheItem>().Find(q => q.Key == key);
  
            if (item != null)
            {
                if (item.Expiration <= DateTime.Now)
                {
                    LiteDbHelper.Delete<CacheItem>(item.Id); 
                }
                else
                {
                    return BinarySerializer.Deserialize(item.Entry);
                }
            }


            LiteDbHelper.Add(new CacheItem
            { 
                Key = key,
                Entry = BinarySerializer.Serialize(entry),
                Expiration = utcExpiry,
                CreatedDate = DateTime.UtcNow
            });

            return entry;
        }

        public override object Get(string key)
        {
            var item = LiteDbHelper.QueryAll<CacheItem>().Find(q => q.Key == key);

            if (item != null)
            {
                if (item.Expiration <= DateTime.Now)
                {
                    LiteDbHelper.Delete<CacheItem>(item.Id);
                }
                else
                {
                    return BinarySerializer.Deserialize(item.Entry);
                }
            }

            return null;
        }

        public override void Remove(string key)
        {
            var item = LiteDbHelper.QueryAll<CacheItem>().Find(q => q.Key == key);
            if (item != null)
            {
                LiteDbHelper.Delete<CacheItem>(item.Id);
            }
        }

        public override void Set(string key, object entry, DateTime utcExpiry)
        {
            var item = LiteDbHelper.QueryAll<CacheItem>().Find(q => q.Key == key);

            if (item != null)
            {
                item.Entry = BinarySerializer.Serialize(entry);
                item.Expiration = utcExpiry;
                LiteDbHelper.Update(item);
            }
            else
            {
                LiteDbHelper.Add(new CacheItem
                {
                    Key = key,
                    Entry = BinarySerializer.Serialize(entry),
                    Expiration = utcExpiry,
                    CreatedDate = DateTime.UtcNow
                });
            }
        } 
    }
}