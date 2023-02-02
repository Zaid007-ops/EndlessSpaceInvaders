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
        private HealthBar _healthBar;
        private List<EnemyShipSprite> _enemyShips;
        private List<Laser> _lasers;
        private string _username;

        public Game1(string username)
        {
            _username = username;
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _healthBar = CreateHealthBar();
            _playerOne = CreatePlayerOne();                       //creates playerOne
            _playerOne.Position = new Vector2(360, 400);          // sets the position at which PlayerOne spawns
            _enemyShips = CreateEnemyShips(5);                  // creates EnemyShip
            _lasers = new List<Laser>();
        }

        protected override void Update(GameTime gameTime)
        {
            _playerOne.Update();         // updates WhiteShip sprite

            foreach (var enemyShip in _enemyShips)
            {
                enemyShip.Update();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                Fire();

            foreach(var laser in _lasers)
            {
                laser.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _healthBar.Draw(_spriteBatch);

            _playerOne.Draw(_spriteBatch);

            foreach (Laser laser in _lasers)
                laser.Draw(_spriteBatch);

            foreach (var enemyShip in _enemyShips)
            {
                enemyShip.Draw(_spriteBatch);
            }

            foreach (var laser in _lasers.ToList())
            {
                if (!laser.IsVisible)
                    _lasers.Remove(laser);
            }

            foreach (var enemyShip in _enemyShips.ToList())
            {
                if (enemyShip.Position.Y > 400)
                    _enemyShips.Remove(enemyShip);
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

            _lasers.Add(newLaser);
        }
    }
}
