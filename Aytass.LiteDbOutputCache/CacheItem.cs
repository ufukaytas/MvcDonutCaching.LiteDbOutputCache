using System;
using LiteDB;

namespace Aytass.LiteDbOutputCache
{
    [Serializable]
    public class CacheItem
    {
        public CacheItem()
        {
            Id = new ObjectId();
        }

        public ObjectId Id { get; set; }
        public string Key { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Expiration { get; set; }
        public byte[] Entry { get; set; }
    }
}