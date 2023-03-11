using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Viewport = Microsoft.Xna.Framework.Graphics.Viewport;

namespace EndlessSpaceInvasion
{
    internal class EnemyShipSprite : IGameEntity                      //used for creating random number of enemy sprites then randomly spawns them in random positions 
    {
        private readonly ContentManager _contentManager;
        private Texture2D _texture;
        private readonly Viewport _viewport;
        public Vector2 Position;
        private bool _isVisible;
        private const float RateOfSpeed = 0.5f;
        private float _timeSinceLastShot;

        public string Type { get => Constants.GameEntityTypes.EnemyShip; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }
        public bool IsEnemy => true;
        public int Health { get; set; }
        public Rectangle Boundary { get => new((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height); }

        public EnemyShipSprite(ContentManager contentManager, Viewport viewport)
        {
            _contentManager = contentManager;
            _texture = contentManager.Load<Texture2D>("RedEnemyShip");
            _viewport = viewport;
            _isVisible = true;
            _timeSinceLastShot = 2;

            Health = 1;
            Position = new Vector2(GenerateRandomXPosition(viewport), GenerateRandomYPosition());
        }

        public void Update(GameTime gameTime, List<IGameEntity> gameEntities, KeyboardState currentKey, KeyboardState previousKey)
        {
            Position.Y += RateOfSpeed;

            if (IsSpriteOffTheScreen() || HealthChecker.IsDead(Health))
                _isVisible = false;

            if (_timeSinceLastShot > 0)
            {
                _timeSinceLastShot -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                return;
            }

            Fire(gameEntities);

            _timeSinceLastShot = 6; // reset bullet timer
        }

        public void Draw(SpriteBatch spriteBatch)
            => spriteBatch.Draw(_texture, Position, Color.White);

        private static float GenerateRandomXPosition(Viewport viewport)
            => new Random().NextFloat(10, viewport.Width - 10);

        private static float GenerateRandomYPosition()
            => new Random().NextFloat(-40, -400);

        private void Fire(List<IGameEntity> gameEntities)
        {
            var texture = _contentManager.Load<Texture2D>(Constants.GameEntityTypes.EnemyLaser);

            var bulletPosition = Position;
            bulletPosition.X -= 3;
            bulletPosition.Y += 9;

            var newLaser = new EnemyLaser(texture, _viewport, bulletPosition, 2);

            gameEntities.Add(newLaser);
        }

        private bool IsSpriteOffTheScreen()
            => Position.Y > _viewport.Height;
    }
}
