using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp.Template.Services.Cache
{
    public interface ICacheService
    {
        T Get<T>(string key);
        void Set(string key, object data, int? cacheTime = null);
        bool IsSet(string key);
        void Remove(string key);
        void Clear();
    }
}
