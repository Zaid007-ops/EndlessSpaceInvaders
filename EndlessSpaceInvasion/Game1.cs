using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Microsoft.Xna.Framework.Content;
using SharpDX;
using Color = Microsoft.Xna.Framework.Color;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Viewport = Microsoft.Xna.Framework.Graphics.Viewport;

namespace EndlessSpaceInvasion
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private PlayerSprite _playerOne;
        //Texture2D _motherShip;
        private string _username;
        private DataStoreService _dataStoreService;
        private List<IGameEntity> _gameEntities;
        private KeyboardState _previousKey;
        private SpriteFont _font;
        private int _level;
        private int _score;
        private int _numberOfEnemyShips;
        private int _numberOfBlueShips;

        public Game1(DataStoreService dataStoreService, string username)
        {
            _username = username;
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _dataStoreService = dataStoreService;
            _gameEntities = new List<IGameEntity>();
            _previousKey = new KeyboardState();
            _level = 1;  
            _score = 0;
            _numberOfEnemyShips = 2;
            _numberOfBlueShips = 1;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _playerOne = CreatePlayerOne();                       //creates playerOne
            _playerOne._position = new Vector2(360, 400);          // sets the position at which PlayerOne spawns

           // _motherShip = this.Content.Load<Texture2D>("MotherShip");

            _gameEntities.Add(CreateHealthBar());
            _gameEntities.Add(_playerOne);
            _gameEntities.AddRange(CreateEnemyShips(_numberOfEnemyShips, _numberOfBlueShips));

            _font = Content.Load<SpriteFont>("font");
        }

        protected override void Update(GameTime gameTime)
        {
            var currentKey = Keyboard.GetState();

            if(currentKey.IsKeyDown(Keys.Escape) || IsPlayerOneDead())
            {
                _dataStoreService.SaveScore(_username, _score, _level);
                Exit();
            }

            if (_gameEntities.All(e => !e.IsEnemy))
            {
                _level += 1;
                _gameEntities.AddRange(CreateEnemyShips(_numberOfEnemyShips * _level, _numberOfBlueShips * _level));
            }

            foreach (var gameEntity in _gameEntities.ToList())
                gameEntity.Update(gameTime, _gameEntities, currentKey, _previousKey);

            var collidedEntities = CollisionDetectionService.DetectCollisions(_gameEntities);                

            HandleCollisions(collidedEntities);

            _previousKey = currentKey;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            foreach (var gameEntity in _gameEntities.ToList())
            {
                gameEntity.Draw(_spriteBatch);

                if (!gameEntity.IsVisible)
                    _gameEntities.Remove(gameEntity);              
            }

            _spriteBatch.DrawString(_font, $"Level: {_level}", new Vector2(10, 10), Color.Green);
            _spriteBatch.DrawString(_font, $"Score: {_score}", new Vector2(10, _graphics.GraphicsDevice.Viewport.Height - 50), Color.Green);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private PlayerSprite CreatePlayerOne()
            => new(Content, _graphics.GraphicsDevice.Viewport);

        private HealthBar CreateHealthBar()
            => new(Content.Load<Texture2D>("HealthBar"), _graphics.GraphicsDevice.Viewport);

        private List<IGameEntity> CreateEnemyShips(int numberOfEnemyShips, int numberOfBlueEnemyShips)
        {
            var enemies = new List<IGameEntity>();

            for (var count = 1; count <= numberOfEnemyShips; count++)
            {
                enemies.Add(CreateEnemy(0.5f, 1.5f, (manager, viewport, speed, level) => new EnemyShipSprite(manager, viewport, speed, level)));
            }

            for (var count = 1; count <= numberOfBlueEnemyShips; count++)
            {
                enemies.Add(CreateEnemy(0.5f, 1.5f, (manager, viewport, speed, level) => new BlueShip(manager, viewport, speed, level)));
            }

            if(_level % 2 == 0) // Add mothership every round 2
                enemies.Add(CreateEnemy(0.7f, 0.9f, (manager, viewport, speed, level) => new MotherShip(manager, viewport, speed, level)));
            
            return enemies;
        }

        private IGameEntity CreateEnemy(float speedMin, float speedMax, Func<ContentManager, Viewport, float, int, IGameEntity> createEnemy)
        {
            var speed = new Random().NextFloat(speedMin, speedMax);

            var enemy = createEnemy.Invoke(Content, _graphics.GraphicsDevice.Viewport, speed, _level);

            return enemy;
        }

        private void HandleCollisions(List<IGameEntity> gameEntities)
        {
            // TODO: Fix same entities colliding

            foreach (var entity in gameEntities)
            {
                entity.Health -= 1;

                if (entity.IsEnemy)
                    _score += 10;

                if (entity.Type == Constants.GameEntityTypes.PlayerOne)
                    UpdateHealthBar();
            }
        }


        private void UpdateHealthBar()
        {
            var healthBar = _gameEntities.Single(e => e.Type == Constants.GameEntityTypes.HealthBar);
            healthBar.Health -= 1;
        }

        private bool IsPlayerOneDead()
            => HealthChecker.IsDead(_gameEntities.First(e => e.Type == Constants.GameEntityTypes.PlayerOne).Health);
    }
}
