using AngryKoala.Services;

namespace AngryKoala.Pooling
{
    public interface IPoolService : IService
    {
        public FloorPool FloorPool { get; }
        public WallPool WallPool { get; }
        public ObstaclePool ObstaclePool { get; }
        public ExitPool ExitPool { get; }
    }
}