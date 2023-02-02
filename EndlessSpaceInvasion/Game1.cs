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
        private List<Laser> _laser;

        public Game1()
        {
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
            _laser = new List<Laser>();
        }

        protected override void Update(GameTime gameTime)
        {
            _playerOne.Update();         // updates WhiteShip sprite

            //  if (Keyboard.GetState().IsKeyDown(Keys.Space))
            //      healthRectangle.Width -= 1;                                  // TESTS IF HEALTH DECREASES DELETE AFTER ADDING COLLISIONS AND LAZERS

            foreach (var enemyShip in _enemyShips)
            {
                enemyShip.Update();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                fire();

            UpdateLasers();


            base.Update(gameTime);
        }

        public void UpdateLasers()
        {
            foreach(Laser laser in _laser)
            {
                laser.position += laser.velocity;
                if (Vector2.Distance(laser.position, _playerOne.Position) > 500)
                    laser.isVisible = false;
            }
            for (int i = 0; i < _laser.Count; i++)
            {
                if (!_laser[i].isVisible)
                {
                    _laser.RemoveAt(i);
                    i--;
                }
            }
        }

        public void fire()
        {
            Laser newLaser = new Laser(Content.Load<Texture2D>("LazerBeam"));
            newLaser.position = _playerOne.Position + newLaser.velocity * 5;
            newLaser.isVisible = true;

            if (_laser.Count() > 20)
                _laser.Add(newLaser);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _healthBar.Draw(_spriteBatch);

            _playerOne.Draw(_spriteBatch);

            foreach (Laser laser in _laser)
                laser.Draw(_spriteBatch);

            foreach (var enemyShip in _enemyShips)
            {
                enemyShip.Draw(_spriteBatch);
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
    }
}
