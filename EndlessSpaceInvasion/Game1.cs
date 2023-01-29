using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace EndlessSpaceInvasion
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private PlayerSprite _playerOne;
        private PlayerSprite _enemyPlayer;

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

         

            _playerOne = new PlayerSprite(Content.Load<Texture2D>("WhiteShip"), this._graphics.GraphicsDevice.Viewport);                     //loads WhiteShip Sprite
            _playerOne.Position = new Vector2(375, 400);                                            // Position of the WhiteShip Sprite when the game is started

            _enemyPlayer = new PlayerSprite(Content.Load<Texture2D>("RedShip"), this._graphics.GraphicsDevice.Viewport);                     //loads RedShip Sprite
            _enemyPlayer.Position = new Vector2(375, 100);                                           // Position of the RedShip Sprite when the game is started
        }

        protected override void Update(GameTime gameTime)
        {
            _playerOne.Update();         // updates WhiteShip sprite

      

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            _enemyPlayer.Draw(_spriteBatch);
            _playerOne.Draw(_spriteBatch);

            _spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}