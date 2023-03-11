﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Viewport = Microsoft.Xna.Framework.Graphics.Viewport;

namespace EndlessSpaceInvasion
{
    internal class BlueShip : IGameEntity
    {
        private readonly ContentManager _contentManager;
        private Texture2D _texture;
        private readonly Viewport _viewport;
        public Vector2 Position;
        private bool _isVisible;
        private float _rateOfSpeed = 0.9f;
        private float _timeSinceLastShot;
        private int _currentLevel;

        public string Type { get => Constants.GameEntityTypes.BlueShip; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }
        public bool IsEnemy { get => true; }
        public int Health { get; set; }
        public Rectangle Boundary { get => new((int) Position.X, (int)Position.Y, _texture.Width, _texture.Height); }

        public BlueShip(ContentManager contentManager, Viewport viewport, float speed, int currentLevel)
        {
            _contentManager = contentManager;
            _texture = contentManager.Load<Texture2D>(Constants.GameEntityTypes.BlueShip);
            _viewport = viewport;
            _currentLevel = currentLevel;
            _isVisible = true;
            _timeSinceLastShot = 2;
            _rateOfSpeed = speed * currentLevel / 2;

            Health = 2;
            Position = new Vector2(GenerateRandomXPosition(), GenerateRandomYPosition());
        }

        public void Update(GameTime gameTime, List<IGameEntity> gameEntities, KeyboardState currentKey, KeyboardState previousKey)
        {
            Position.X += _rateOfSpeed;

            if (IsSpriteOffTheScreen() || HealthChecker.IsDead(Health))
                _isVisible = false;

            if (_timeSinceLastShot > 0)
            {
                _timeSinceLastShot -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                return;
            }

            Fire(gameEntities);
            _timeSinceLastShot = 2; // reset bullet timer
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }

        private static float GenerateRandomXPosition()
            => new Random().NextFloat(-400, -50);

        private static float GenerateRandomYPosition()
            => new Random().NextFloat(0, 100);

        private void Fire(List<IGameEntity> gameEntities)
        {
            var texture = _contentManager.Load<Texture2D>(Constants.GameEntityTypes.EnemyLaser);

            var bulletPosition = Position;
            bulletPosition.X += (float)_texture.Width / 2;
            bulletPosition.Y += _texture.Height;

            var newLaser = new EnemyLaser(texture, _viewport, bulletPosition, 2 * _currentLevel / 2);

            gameEntities.Add(newLaser);
        }

        private bool IsSpriteOffTheScreen()
            => Position.X > _viewport.Width;
    }
}
