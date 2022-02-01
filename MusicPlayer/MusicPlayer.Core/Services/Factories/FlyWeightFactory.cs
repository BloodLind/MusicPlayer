using MusicPlayer.Core.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Services.Factories
{
    public abstract class FlyWeightFactory<TKey, TValue> : IFlyWeightFactory<TKey, TValue>
    {
        protected Dictionary<TKey, TValue> CachedData { get; private set; }

        public FlyWeightFactory()
        {
            CachedData = new Dictionary<TKey, TValue>();
        }
        public TValue GetData(TValue value)
        {
            TKey key = GetKey(value);
            if (IsKeyAvaible(key))
            {
                CachedData.Add(key, value);
            }
            return value;
        }

        public TValue GetData(TKey key)
        {
            if (IsKeyAvaible(key))
            {
                return default(TValue);
            }
            else
                return CachedData[key];
        }

        public abstract TKey GetKey(TValue value);

        public bool IsKeyAvaible(TKey key)
        {
            return !CachedData.ContainsKey(key);
        }

        public TValue RemoveData(TKey key)
        {
            TValue value = CachedData[key];
            CachedData.Remove(key);
            Console.WriteLine(CachedData.Count);
            return value;
        }

        public bool TryAddData(TKey key, TValue value)
        {
            if (CachedData.ContainsKey(key))
                return false;
            else
                CachedData.Add(key, value);
            return true;
        }

        public void AddData(TKey key, TValue value)
        {
            CachedData.Add(key, value);
        }

        public void ReleaseData()
        {
            CachedData.Clear();
        }
    }
}
