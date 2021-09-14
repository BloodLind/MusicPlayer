using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Infrastructure.Interfaces
{
    public interface IFlyWeightFactory<TKey,TValue>
    {

        TValue GetData(TValue value);
        TValue RemoveData(TKey key);
        TValue GetData(TKey key);
        bool IsKeyAvaible(TKey key);
        bool TryAddData(TKey key, TValue value);
        void AddData(TKey key, TValue value);

        void ReleaseData();
    }
}
