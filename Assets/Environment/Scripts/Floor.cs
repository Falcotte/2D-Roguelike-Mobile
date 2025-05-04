using AngryKoala.Pooling;
using UnityEngine;

namespace Roguelike.Environment
{
    public class Floor : MonoBehaviour, IPoolable
    {
        [SerializeField] private SpriteRenderer _visual;

        [SerializeField] private Sprite[] _floorSprites;

        public PoolKey PoolKey { get; set; }

        public void Initialize()
        {
            _visual.sprite = _floorSprites[Random.Range(0, _floorSprites.Length)];
        }

        public void Terminate()
        {
        }
    }
}