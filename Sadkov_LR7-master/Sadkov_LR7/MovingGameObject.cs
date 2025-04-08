using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sadkov_LR7
{
    public class MovingGameObject : GameObject
    {
        protected Vector2 _velocity;
        public Vector2 Velocity { get; }
        public MovingGameObject(Texture2D texture, Vector2 position, Vector2 velocity) : base(texture, position)
        {
            _velocity = velocity;
        }
        public void ChangeVelocityVertical(float newYPosition)
        {
            _velocity.Y = -_velocity.Y;
            _position.Y = newYPosition;
        }
        public void ChangeHorisontalVelocity(float newXPosition)
        {
            _velocity.X = -_velocity.X;
            _position.X = newXPosition;
        }
        public virtual void Update(GameTime gameTime)
        {
            if (_position.X < 0 || _position.X > 1000 - _texture.Width)
            {
                _velocity.X = -_velocity.X;
            }
            if (_position.Y < 0 || _position.Y > 500 - _texture.Height)
            {
                _velocity.Y = -_velocity.Y;
            }
            _position += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
