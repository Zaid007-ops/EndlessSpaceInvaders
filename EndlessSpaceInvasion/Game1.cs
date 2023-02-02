using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Collections.Generic;
using System.Linq;

namespace EndlessSpaceInvasion
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private PlayerSprite _playerOne;
        private string _username;
        private DataStoreService _dataStoreService;
        private List<IGameEntity> _gameEntities;

        public Game1(string username)
        {
            _username = username;
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _dataStoreService = new DataStoreService();
            _gameEntities = new List<IGameEntity>();
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
            _playerOne.Position = new Vector2(360, 400);          // sets the position at which PlayerOne spawns

            _gameEntities.Add(CreateHealthBar());
            _gameEntities.Add(_playerOne);
            _gameEntities.AddRange(CreateEnemyShips(5));
        }

        protected override void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _dataStoreService.SaveScore(_username, DateTime.Now.Second);
                Exit();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                Fire();

            foreach (var gameEntity in _gameEntities)
                gameEntity.Update();

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

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private PlayerSprite CreatePlayerOne()
            => new(Content.Load<Texture2D>("PlayerOneShip"), _graphics.GraphicsDevice.Viewport);

        private HealthBar CreateHealthBar()
            => new(Content.Load<Texture2D>("HealthBar"));

        private List<EnemyShipSprite> CreateEnemyShips(int numberOfEnemyShips)
        {
            var enemyShips = new List<EnemyShipSprite>();

            for (var count = 1; count <= numberOfEnemyShips; count++)
            {
                var enemyShip = new EnemyShipSprite(Content.Load<Texture2D>("RedEnemyShip"), _graphics.GraphicsDevice.Viewport);

                enemyShips.Add(enemyShip);
            }

            return enemyShips;
        }

        private void Fire()
        {
            var newLaser = new Laser(Content.Load<Texture2D>("LazerBeam"), _graphics.GraphicsDevice.Viewport, _playerOne.Position)
            {
                Position = _playerOne.Position,
                IsVisible = true
            };

            _gameEntities.Add(newLaser);
        }
    }
}
