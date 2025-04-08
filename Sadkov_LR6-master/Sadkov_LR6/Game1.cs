using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sadkov_LR6
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player _player;
        private MovingGameObject _witch;
        private Texture2D _background;
        private List<GameObject> _platforms;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 500;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _platforms = new List<GameObject>
            {
                new GameObject(Content.Load<Texture2D>("floor1"), new Vector2(0, 400)),
                new GameObject(Content.Load<Texture2D>("platform"), new Vector2(300, 300))
            };
            _player = new Player(Content.Load<Texture2D>("player"), Content.Load<Texture2D>("player_mirror"), new Vector2(200, 300), new Vector2(0, 0));
            _witch = new MovingGameObject(Content.Load<Texture2D>("witch"), new Vector2(600, 100), new Vector2(-25, 30));;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _background = Content.Load<Texture2D>("background");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _witch.Update(gameTime);
            _player.Update(gameTime);
            bool isOnPlatform = false;
            foreach (var platform in _platforms)
            {
                if (_player.BoundingBox.Bottom >= platform.BoundingBox.Top &&
                    _player.BoundingBox.Bottom <= platform.BoundingBox.Top + 5 &&
                    _player.BoundingBox.Right > platform.BoundingBox.Left &&
                    _player.BoundingBox.Left < platform.BoundingBox.Right &&
                    _player.VerticalVelocity >= 0)
                {
                    _player.StopJump(platform.BoundingBox.Top - _player.BoundingBox.Height);
                    isOnPlatform = true;
                    break;
                }
            }
            if (!isOnPlatform && _player.Position.Y < 400 - _player.BoundingBox.Height)
            {
                _player.IsJump = true;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(_background, Vector2.Zero, Color.White);
            // TODO: Add your drawing code here
            foreach (var platform in _platforms)
            {
                platform.Draw(_spriteBatch);
            }
            _witch.Draw(_spriteBatch);
            _player.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
