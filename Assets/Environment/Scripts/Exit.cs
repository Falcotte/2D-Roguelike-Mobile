using AngryKoala.Pooling;
using UnityEngine;

namespace Roguelike.Environment
{
    public class Exit : MonoBehaviour, IPoolable
    {
        public PoolKey PoolKey { get; set; }
        
        public void Initialize()
        {

        }

        public void Terminate()
        {

        }
    }
}