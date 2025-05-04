using AngryKoala.Services;
using UnityEngine;

namespace AngryKoala.Pooling
{
    public class PoolService : BaseService<IPoolService>, IPoolService
    {
        [SerializeField] private FloorPool _floorPool;
        public FloorPool FloorPool => _floorPool;
        [SerializeField] private WallPool _wallPool;
        public WallPool WallPool => _wallPool;
        [SerializeField] private ObstaclePool _obstaclePool;
        public ObstaclePool ObstaclePool => _obstaclePool;
        [SerializeField] private ExitPool _exitPool;
        public ExitPool ExitPool => _exitPool;
    }
}