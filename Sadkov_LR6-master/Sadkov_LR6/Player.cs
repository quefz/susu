using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sadkov_LR6
{
    public class Player : MovingGameObject
    {
        private const float _speed = 200f;
        private const float _jumpForce = 400f;
        private bool _isJump;
        private float _gravity = 800f;
        private float _verticalVelocity;
        private Texture2D _textureFacingRight;
        private Texture2D _textureFacingLeft;
        private bool _facingRight = true;
        public float VerticalVelocity
        {
            get => _verticalVelocity;
            set => _verticalVelocity = value;
        }
        public bool IsJump
        {
            get => _isJump;
            set => _isJump = value;
        }
        public Player(Texture2D textureFacingRight, Texture2D textureFacingLeft, Vector2 position, Vector2 velocity)
        : base(textureFacingRight, position, velocity)
        {
            _textureFacingRight = textureFacingRight;
            _textureFacingLeft = textureFacingLeft;
            _isJump = false;
            _verticalVelocity = 0;
        }
        public void KeyInput(GameTime gameTime) 
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Left))
            {
                _velocity = new Vector2(-_speed, _velocity.Y);
                _facingRight = false;
            }
            else if (ks.IsKeyDown(Keys.Right))
            {
                _velocity = new Vector2(_speed, _velocity.Y);
                _facingRight = true;
            }
            else
            { 
                _velocity = new Vector2 (0, _velocity.Y);
            }
            if (ks.IsKeyDown(Keys.Up) && !_isJump)
            {
                _verticalVelocity = -_jumpForce;
                _isJump = true;
            }
        }
        public void StopJump(float newYPosition)
        {
            _position.Y = newYPosition;
            _isJump = false;
            _verticalVelocity = 0;
        }
        public override void Update(GameTime gameTime)
        {
            KeyInput(gameTime);
            if (_position.X < 1)
            {
                _position.X = 1;
            }
                
            if(_position.X > 999 - _texture.Width)
            {
                _position.X = 999 - _texture.Width;
            }

            if (_isJump)
            {
                _position.Y += _verticalVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_isJump) { _verticalVelocity += _gravity * (float)gameTime.ElapsedGameTime.TotalSeconds; }
                if (_position.Y >= 300)
                {
                    _isJump = false;
                    _verticalVelocity = 0;
                }
            }
            _position += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Texture2D currentTexture = _facingRight ? _textureFacingRight : _textureFacingLeft;
            spriteBatch.Draw(currentTexture, _position, Color.White);
        }
    }
}
