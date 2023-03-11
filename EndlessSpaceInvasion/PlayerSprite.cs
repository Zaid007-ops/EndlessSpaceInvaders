using System;
using Microsoft.Xna.Framework;                                  // needed for the Vector2
using Microsoft.Xna.Framework.Graphics;                         // needed for the texture 
using Microsoft.Xna.Framework.Input;                            // needed for Keyboard.GetState() to work
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Content;
using Color = Microsoft.Xna.Framework.Color;

namespace EndlessSpaceInvasion
{
    internal class PlayerSprite : IGameEntity
    {
        private readonly ContentManager _contentManager;
        private Texture2D _texture;
        private Viewport _viewport;
        public Vector2 Position;
        private bool _isVisible;

        public PlayerSprite(ContentManager contentManager, Viewport viewport)
        {
            _contentManager = contentManager;
            _texture = contentManager.Load<Texture2D>("PlayerOneShip");
            _viewport = viewport;
            _isVisible = true;
            Health = 10;
        }

        public string Type { get => Constants.GameEntityTypes.PlayerOne; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }
        public bool IsEnemy => false;
        public int Health { get; set; }
        public Rectangle Boundary { get => new((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height); }

        public void Update(GameTime gameTime, List<IGameEntity> gameEntities, KeyboardState currentKey, KeyboardState previousKey)
        {
            if (currentKey.IsKeyDown(Keys.W)) // moves the sprite up
            {
                if (Position.Y >= -16)
                    Position.Y -= 3;
            }
            if (currentKey.IsKeyDown(Keys.S))// moves the sprite down
            {
                if (Position.Y < _viewport.Height - 55)
                    Position.Y += 3;
            }
            if (currentKey.IsKeyDown(Keys.D))   // moves the sprite right 
            {
                if (Position.X < _viewport.Width - 65)
                    Position.X += 3;
            }
            if (currentKey.IsKeyDown(Keys.A)) // moves the sprite left 
            {
                if (Position.X >= -26)
                    Position.X -= 3;
            }

            if (currentKey.IsKeyDown(Keys.Space) && previousKey.IsKeyUp(Keys.Space))
                Fire(gameEntities);
        }

        private void Fire(List<IGameEntity> gameEntities)
        {
            var newLaser = new PlayerLaser(_contentManager.Load<Texture2D>(Constants.GameEntityTypes.PlayerLaser), _viewport, Position, -5);

            gameEntities.Add(newLaser);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }
    }
}
