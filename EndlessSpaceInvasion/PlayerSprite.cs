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
        public Vector2 _position;
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
        public Rectangle Boundary { get => new((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height); }
        public Vector2 Position { get => _position; }

        public void Update(GameTime gameTime, List<IGameEntity> gameEntities, KeyboardState currentKey, KeyboardState previousKey)
        {
            if (currentKey.IsKeyDown(Keys.W)) // moves the sprite up
            {
                if (_position.Y >= -16)
                    _position.Y -= 3;
            }
            if (currentKey.IsKeyDown(Keys.S))// moves the sprite down
            {
                if (_position.Y < _viewport.Height - 40)
                    _position.Y += 3;
            }
            if (currentKey.IsKeyDown(Keys.D))   // moves the sprite right 
            {
                if (_position.X < _viewport.Width - 23)
                    _position.X += 3;
            }
            if (currentKey.IsKeyDown(Keys.A)) // moves the sprite left 
            {
                if (_position.X >= -18)
                    _position.X -= 3;
            }

            if (currentKey.IsKeyDown(Keys.Space) && previousKey.IsKeyUp(Keys.Space))
                Fire(gameEntities);
        }

        private void Fire(List<IGameEntity> gameEntities)
        {
            var texture = _contentManager.Load<Texture2D>(Constants.GameEntityTypes.PlayerLaser);

            var bulletPosition = _position;
            bulletPosition.X += (float)_texture.Width / 2;

            var newLaser = new PlayerLaser(texture, _viewport, bulletPosition, -5);

            gameEntities.Add(newLaser);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
