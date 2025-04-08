using Microsoft.Xna.Framework;
using Sadkov_LR7;
using System;

namespace Sadkov_LR7
{
    public class CollisionHandlerPlayer
    {
        public void HandlePlayerCollision(GameObject platform, Player player)
        {
            // Останавливаем прыжок игрока при столкновении с платформой
            player.StopJump(platform.BoundingBox.Top - player.BoundingBox.Height);
        }
    }

    public class CollisionHandlerMovingObject
    {
        public void HandleMovingObjectToGameObjectCollision(GameObject platform, MovingGameObject movObj)
        {
            // Обработка столкновения движущегося объекта с платформой
            movObj.ChangeVelocityVertical(platform.BoundingBox.Top - movObj.BoundingBox.Height);
        }

        public void HandleVerticalCollision(MovingGameObject movObj1, MovingGameObject movObj2, Rectangle intersection)
        {
            // Вертикальное столкновение
            if (movObj1.Position.Y < movObj2.Position.Y)
            {
                movObj1.Position = new Vector2(movObj1.Position.X, movObj1.Position.Y - intersection.Height / 2f - 1);
                movObj2.Position = new Vector2(movObj2.Position.X, movObj2.Position.Y + intersection.Height / 2f + 1);
            }
            else
            {
                movObj1.Position = new Vector2(movObj1.Position.X, movObj1.Position.Y + intersection.Height / 2f + 1);
                movObj2.Position = new Vector2(movObj2.Position.X, movObj2.Position.Y - intersection.Height / 2f - 1);
            }

            movObj1.ChangeVelocityVertical(movObj1.Position.Y);
            movObj2.ChangeVelocityVertical(movObj2.Position.Y);
        }

        public void HandleHorizontalCollision(MovingGameObject movObj1, MovingGameObject movObj2, Rectangle intersection)
        {
            // Горизонтальное столкновение
            if (movObj1.Position.X < movObj2.Position.X)
            {
                movObj1.Position = new Vector2(movObj1.Position.X - intersection.Width / 2f - 1, movObj1.Position.Y);
                movObj2.Position = new Vector2(movObj2.Position.X + intersection.Width / 2f + 1, movObj2.Position.Y);
            }
            else
            {
                movObj1.Position = new Vector2(movObj1.Position.X + intersection.Width / 2f + 1, movObj1.Position.Y);
                movObj2.Position = new Vector2(movObj2.Position.X - intersection.Width / 2f - 1, movObj2.Position.Y);
            }

            movObj1.ChangeHorisontalVelocity(movObj1.Position.X);
            movObj2.ChangeHorisontalVelocity(movObj2.Position.X);
        }
    }
}
