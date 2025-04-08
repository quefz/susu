using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sadkov_LR7;
using System.Collections.Generic;

namespace Sadkov_LR7
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player _player;
        private MovingGameObject _witch;
        private MovingGameObject _DVD1;
        private MovingGameObject _DVD2;
        private MovingGameObject _fly1;
        private MovingGameObject _fly2;
        private Texture2D _background;
        private List<GameObject> _platforms;
        private List<MovingGameObject> _movingGameObjects;
        private Manager _collisionManager;

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
            // Загружаем платформы
            _platforms = new List<GameObject>
            {
                new GameObject(Content.Load<Texture2D>("floor1"), new Vector2(0, 400)),
                new GameObject(Content.Load<Texture2D>("platform"), new Vector2(300, 300))
            };

            // Создаем игрока
            _player = new Player(
                Content.Load<Texture2D>("player"),
                Content.Load<Texture2D>("player_mirror"),
                new Vector2(200, 300),
                new Vector2(0, 0)
            );

            // Создаем движущиеся объекты
            _witch = new MovingGameObject(Content.Load<Texture2D>("witch"), new Vector2(800, 100), new Vector2(-25, 30));
            _DVD1 = new MovingGameObject(Content.Load<Texture2D>("dvd"), new Vector2(0, 0), new Vector2(14, 40));
            _DVD2 = new MovingGameObject(Content.Load<Texture2D>("dvd"), new Vector2(850, 200), new Vector2(14, 40));
            _fly1 = new MovingGameObject(Content.Load<Texture2D>("fly"), new Vector2(400, 200), new Vector2(14, 40));
            _fly2 = new MovingGameObject(Content.Load<Texture2D>("fly"), new Vector2(200, 200), new Vector2(-65, -50));

            // Добавляем движущиеся объекты в список
            _movingGameObjects = new List<MovingGameObject> { _witch, _DVD1, _DVD2, _fly1, _fly2 };

            // Инициализируем менеджер столкновений
            _collisionManager = new Manager(_platforms, _movingGameObjects, _player);

            // Обработчики столкновений
            var collisionHandlerPlayer = new CollisionHandlerPlayer();
            _collisionManager.OnPlayerCollision += collisionHandlerPlayer.HandlePlayerCollision;

            var collisionHandlerMovingObject = new CollisionHandlerMovingObject();
            _collisionManager.OnMovingObjectToGameObjectCollision += collisionHandlerMovingObject.HandleMovingObjectToGameObjectCollision;
            _collisionManager.OnMovingObjectToMovingObjectCollisionX += collisionHandlerMovingObject.HandleVerticalCollision;
            _collisionManager.OnMovingObjectToMovingObjectCollisionY += collisionHandlerMovingObject.HandleHorizontalCollision;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _background = Content.Load<Texture2D>("background");
        }

        protected override void Update(GameTime gameTime)
        {
            // Выход из игры
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Обновляем движущиеся объекты
            foreach (var moveObj in _movingGameObjects)
            {
                moveObj.Update(gameTime);
            }

            // Обновляем игрока
            _player.Update(gameTime);

            // Проверка столкновений
            _collisionManager.CheckCollisions(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Очистка экрана
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // Рисуем фон
            _spriteBatch.Draw(_background, Vector2.Zero, Color.White);

            // Рисуем движущиеся объекты
            foreach (var moveObj in _movingGameObjects)
            {
                moveObj.Draw(_spriteBatch);
            }

            // Рисуем платформы
            foreach (var platform in _platforms)
            {
                platform.Draw(_spriteBatch);
            }

            // Рисуем игрока
            _player.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
