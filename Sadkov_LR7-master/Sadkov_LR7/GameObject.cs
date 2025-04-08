using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sadkov_LR7
{
    public class GameObject
    {
        protected Texture2D _texture;
        protected Vector2 _position;
        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }
        public GameObject(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
        public virtual Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
            }
        }
    }
}
