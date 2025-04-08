using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace Lighting_System
{
    public class Light_Spot
    {
        protected Vector2 _position;
        protected float _brightness;
        protected Color _color;
        protected float _radius;
        protected float _focus;
        protected bool _isOn;
        protected Texture2D _texture;
        public Vector2 Position { get; set; }
        public float Brightness { get; set; }
        public Color Color { get; set; }
        public float Radius { get; set; }
        public float Focus { get; set; }
        public bool IsOn { get; set; }
        public Light_Spot(Texture2D texture,Vector2 position, float brightness, Color color, float radius, float focus)
        {
            _texture = texture;
            _position = position;
            _brightness = brightness;
            _color = color;
            _radius = radius;
            _focus = focus;
            _isOn = true;
        }
        public void Toggle()
        {
            _isOn = !_isOn;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            float adjustedRadius = _radius * _focus;
            if (_isOn)
            {
                spriteBatch.Draw(_texture, _position, null, _color * _brightness, 0f,
                new Vector2(_texture.Width / 2, _texture.Height / 2),
                    adjustedRadius / (_texture.Width / 2), SpriteEffects.None, 0f);
            }
        }
    }
}
