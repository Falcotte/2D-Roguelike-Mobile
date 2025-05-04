using AngryKoala.Pooling;
using UnityEngine;

namespace Roguelike.Environment
{
    public class Obstacle : MonoBehaviour, IPoolable
    {
        [SerializeField] private SpriteRenderer _visual;

        [SerializeField] private Sprite[] _obstacleSprites;

        public PoolKey PoolKey { get; set; }

        private int _obstacleIndex;
        
        public void Initialize()
        {
            _obstacleIndex = Random.Range(0, _obstacleSprites.Length);
            _visual.sprite = _obstacleSprites[_obstacleIndex];
        }

        public void Terminate()
        {
        }
    }
}