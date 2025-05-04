using AngryKoala.Pooling;
using UnityEngine;

namespace Roguelike.Environment
{
    public class Wall : MonoBehaviour, IPoolable
    {
        [SerializeField] private SpriteRenderer _visual;
        
        [SerializeField] private Sprite[] _wallSprites;
        
        public PoolKey PoolKey { get; set; }
        
        public void Initialize()
        {
            _visual.sprite = _wallSprites[Random.Range(0, _wallSprites.Length)];
        }

        public void Terminate()
        {
        }
    }
}