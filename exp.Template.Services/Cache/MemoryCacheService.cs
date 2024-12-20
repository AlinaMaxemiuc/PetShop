using Microsoft.Extensions.Caching.Memory;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Caching;

namespace exp.Template.Services.Cache
{
    public class MemoryCacheService : ICacheService
    {
        private readonly int _cacheTime;

        public MemoryCacheService(int cacheTime = 60)
        {
            _cacheTime = cacheTime;
        }

        protected ObjectCache Cache => MemoryCache.Default;

        public T Get<T>(string key)
        {
            if (!IsSet(key)) return default;
            var deserializer = new BinaryFormatter();
            using var memStream = new MemoryStream((byte[])Cache[key]);
            return (T)deserializer.Deserialize(memStream);
        }

        public void Set(string key, object data, int? cacheTime = null)
        {
            if (data == null) return;

            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(cacheTime ?? _cacheTime)
            };

            var serializer = new BinaryFormatter();
            using var memStream = new MemoryStream();
            serializer.Serialize(memStream, data);
            Cache.Add(new CacheItem(key, memStream.ToArray()), policy);
        }

        public bool IsSet(string key) => Cache.Contains(key);

        public void Remove(string key) => Cache.Remove(key);

        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }
    }
}
