using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lighting_System
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        LightManager _lightManager;
        List<Light_Spot> _lightSpots;
        Cursor_Light_Spot _cursor;
        Texture2D _lightTexture;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            _lightTexture = Content.Load<Texture2D>("Spot");
            _cursor = new Cursor_Light_Spot(_lightTexture, new Vector2(100, 100), 1f, Color.White, 100f, 0.5f);
            _lightSpots = new List<Light_Spot>
            {
                new Light_Spot(_lightTexture, new Vector2(366, 100), 1f, Color.Violet, 200f, 0.5f),
                new Light_Spot(_lightTexture, new Vector2(632, 100), 2f, Color.Peru, 200f, 0.1f),
                new Light_Spot(_lightTexture, new Vector2(100, 366), 1f, Color.LemonChiffon, 200f, 2f),
                new Light_Spot(_lightTexture, new Vector2(366, 366), 1f, Color.RoyalBlue, 200f, 0.5f)
            };
            _lightManager = new LightManager(_lightSpots, _cursor);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState mouseState = Mouse.GetState();
            Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);
            _cursor.Update(mousePosition);

            _lightManager.KeyHandler(gameTime);

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);
            _lightManager.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
