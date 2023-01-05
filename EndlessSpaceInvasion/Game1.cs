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

        private PlayerSprite _sprite1;
        private PlayerSprite _sprite2;

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

            _sprite1 = new PlayerSprite(Content.Load<Texture2D>("WhiteShip"));                     //loads WhiteShip Sprite
            _sprite1.Position = new Vector2(375, 400);                                            // Position of the WhiteShip Sprite when the game is started

            _sprite2 = new PlayerSprite(Content.Load<Texture2D>("RedShip"));                     //loads RedShip Sprite
            _sprite2.Position = new Vector2(375, 100);                                           // Position of the RedShip Sprite when the game is started
        }

        protected override void Update(GameTime gameTime)
        {

            _sprite1.Update();         // updates WhiteShip sprite

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();


            _sprite2.Draw(_spriteBatch);
            _sprite1.Draw(_spriteBatch);

            _spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}