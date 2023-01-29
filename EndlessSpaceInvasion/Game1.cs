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
        private EnemyShipSprite _enemyShip;

        private List<EnemyShipSprite> _enemyShips;

        Texture2D healthTexture;              //texture is loaded for the healthbar
        Vector2 _healthVector;               // position of the healthbar
        Rectangle healthRectangle;          //Image of the healthbar

        int screenWidth;
        int screenHeight;

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

            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;

            healthTexture = Content.Load<Texture2D>("HealthBar");       //loads healthbar from content
            _healthVector = new Vector2(50, 30);                       //position of the health bar
            healthRectangle = new Rectangle(0, 0, healthTexture.Width, healthTexture.Height);    // creates healthbar


            _playerOne = CreatePlayerOne();                       //creates playerOne
            _playerOne.Position = new Vector2(360, 400);          // sets the position at which PlayerOne spawns

            _enemyShips = CreateEnemyShips(5);                  // creates EnemyShip
        }

        protected override void Update(GameTime gameTime)
        {
            _playerOne.Update();         // updates WhiteShip sprite

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                healthRectangle.Width -= 1;                                  // TESTS IF HEALTH DECREASES DELETE AFTER ADDING COLLISIONS AND LAZERS

            foreach (var enemyShip in _enemyShips)
            {
                enemyShip.Update();
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _spriteBatch.Draw(healthTexture, _healthVector, healthRectangle, Color.White);

            _playerOne.Draw(_spriteBatch);

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
