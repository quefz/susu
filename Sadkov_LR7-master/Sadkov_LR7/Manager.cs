using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Sadkov_LR7
{
    public delegate void CollisionPlayer(GameObject gameObject, Player player);
    public delegate void CollisionMovingObjectToGameObject(GameObject gameObject, MovingGameObject movingObj);
    public delegate void CollisionMovingObjectToMovingGameObjectX(MovingGameObject movObj1, MovingGameObject movObj2, Rectangle intersection);
    public delegate void CollisionMovingObjectToMovingGameObjectY(MovingGameObject movObj1, MovingGameObject movObj2, Rectangle intersection);

    public class Manager
    {
        private List<GameObject> _gameObjects;
        private List<MovingGameObject> _movingGameObjects;
        private Player _player;
        private CollisionHandlerPlayer _playerCollisionHandler;
        private CollisionHandlerMovingObject _movingObjectCollisionHandler;

        public event CollisionPlayer OnPlayerCollision;
        public event CollisionMovingObjectToGameObject OnMovingObjectToGameObjectCollision;
        public event CollisionMovingObjectToMovingGameObjectX OnMovingObjectToMovingObjectCollisionX;
        public event CollisionMovingObjectToMovingGameObjectY OnMovingObjectToMovingObjectCollisionY;

        public Manager(List<GameObject> gameObjects, List<MovingGameObject> movingGameObjects, Player player)
        {
            _gameObjects = gameObjects;
            _movingGameObjects = movingGameObjects;
            _player = player;
            _playerCollisionHandler = new CollisionHandlerPlayer();
            _movingObjectCollisionHandler = new CollisionHandlerMovingObject();
        }

        public void CheckCollisions(GameTime gameTime)
        {
            CheckCollisionsForPlayer();
            CheckCollisionsForMovingObjects();
        }

        private void CheckCollisionsForPlayer()
        {
            bool isOnPlatform = false;

            foreach (var platform in _gameObjects)
            {
                if (_player.BoundingBox.Bottom >= platform.BoundingBox.Top &&
                    _player.BoundingBox.Bottom <= platform.BoundingBox.Top + 5 &&
                    _player.BoundingBox.Right > platform.BoundingBox.Left &&
                    _player.BoundingBox.Left < platform.BoundingBox.Right &&
                    _player.VerticalVelocity >= 0)
                {
                    isOnPlatform = true;
                    _playerCollisionHandler.HandlePlayerCollision(platform, _player);
                    OnPlayerCollision?.Invoke(platform, _player);
                    break;
                }
            }

            if (!isOnPlatform && _player.Position.Y < 400 - _player.BoundingBox.Height)
            {
                _player.IsJump = true;
            }
        }

        private void CheckCollisionsForMovingObjects()
        {
            foreach (var platform in _gameObjects)
            {
                foreach (var movObj in _movingGameObjects)
                {
                    if (movObj.BoundingBox.Bottom >= platform.BoundingBox.Top &&
                        movObj.BoundingBox.Bottom <= platform.BoundingBox.Top + 5 &&
                        movObj.BoundingBox.Right > platform.BoundingBox.Left &&
                        movObj.BoundingBox.Left < platform.BoundingBox.Right)
                    {
                        OnMovingObjectToGameObjectCollision?.Invoke(platform, movObj);
                    }
                }
            }

            for (int i = 0; i < _movingGameObjects.Count; i++)
            {
                for (int j = i + 1; j < _movingGameObjects.Count; j++)
                {
                    var movObj1 = _movingGameObjects[i];
                    var movObj2 = _movingGameObjects[j];

                    if (movObj1.BoundingBox.Intersects(movObj2.BoundingBox))
                    {
                        // Рассчитываем пересечение
                        Rectangle intersection = Rectangle.Intersect(movObj1.BoundingBox, movObj2.BoundingBox);

                        // Определяем, столкновение ли это по вертикали или горизонтали
                        if (intersection.Width > intersection.Height)
                        {
                            // Вертикальное столкновение
                            OnMovingObjectToMovingObjectCollisionX?.Invoke(movObj1, movObj2, intersection);
                        }
                        else
                        {
                            // Горизонтальное столкновение
                            OnMovingObjectToMovingObjectCollisionY?.Invoke(movObj1, movObj2, intersection);
                        }
                    }
                }
            }
        }
    }

}
