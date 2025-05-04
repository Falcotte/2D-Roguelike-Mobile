using System;
using System.Collections.Generic;
using AngryKoala.Pooling;
using AngryKoala.Services;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Roguelike.Board
{
    public class BoardService : BaseService<BoardService>, IBoardService
    {
        [SerializeField] private int _width;
        [SerializeField] private int _height;

        [SerializeField] private int _minObstacleCount;
        [SerializeField] private int _maxObstacleCount;

        [SerializeField] private int _minFoodCount;
        [SerializeField] private int _maxFoodCount;

        private IPoolService _poolService;

        private List<Vector3> _gridPositions = new();

        private void Start()
        {
            _poolService = ServiceLocator.Get<IPoolService>();

            SetupScene(1);
        }

        public void SetupScene(int level)
        {
            InitializeGridPositions();

            CreateBoard();
            CreateObstacles();
        }

        private void InitializeGridPositions()
        {
            _gridPositions.Clear();

            for (int x = 2; x < _width - 2; x++)
            {
                for (int y = 2; y < _height - 2; y++)
                {
                    _gridPositions.Add(new Vector3(x, y, 0));
                }
            }
        }

        private void CreateBoard()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    if (x == 0 || x == _width - 1 || y == 0 || y == _height - 1)
                    {
                        _poolService.WallPool.Get(PoolKey.Wall, new Vector3(x, y, 0), Quaternion.identity, transform);
                    }
                    else
                    {
                        _poolService.FloorPool.Get(PoolKey.Floor, new Vector3(x, y, 0), Quaternion.identity, transform);
                    }
                }
            }

            _poolService.ExitPool.Get(PoolKey.Exit, new Vector3(_width - 2, _height - 2, 0), Quaternion.identity,
                transform);
        }

        private Vector3 GetRandomPosition()
        {
            if (_gridPositions.Count == 0)
            {
                Debug.LogWarning("No more grid positions available");
                return Vector3.zero;
            }

            int randomIndex = Random.Range(0, _gridPositions.Count);

            Vector3 randomPosition = _gridPositions[randomIndex];
            _gridPositions.RemoveAt(randomIndex);

            return randomPosition;
        }

        private void CreateObstacles()
        {
            int obstacleCount = Random.Range(_minObstacleCount, _maxObstacleCount + 1);

            for (int i = 0; i < obstacleCount; i++)
            {
                Vector3 position = GetRandomPosition();
                _poolService.ObstaclePool.Get(PoolKey.Obstacle, position, Quaternion.identity, transform);
            }
        }
    }
}