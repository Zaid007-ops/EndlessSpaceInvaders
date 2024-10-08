﻿using System;
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
        private readonly int _currentLevel;
        public Vector2 _position;
        private bool _isVisible;
        private float _rateOfSpeed;
        private float _timeSinceLastShot;

        public string Type { get => Constants.GameEntityTypes.EnemyShip; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }
        public bool IsEnemy => true;
        public int Health { get; set; }
        public Rectangle Boundary { get => new((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height); }
        public Vector2 Position { get => _position; }

        public EnemyShipSprite(ContentManager contentManager, Viewport viewport, float speed, int currentLevel)
        {
            _contentManager = contentManager;
            _texture = contentManager.Load<Texture2D>("RedEnemyShip");
            _viewport = viewport;
            _currentLevel = currentLevel;
            _isVisible = true;
            _timeSinceLastShot = 2;
            _rateOfSpeed = speed * currentLevel / 2;

            Health = 1;
            _position = new Vector2(GenerateRandomXPosition(viewport), GenerateRandomYPosition());
        }

        public void Update(GameTime gameTime, List<IGameEntity> gameEntities, KeyboardState currentKey, KeyboardState previousKey)
        {
            _position.Y += _rateOfSpeed;

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
            => spriteBatch.Draw(_texture, _position, Color.White);

        private static float GenerateRandomXPosition(Viewport viewport)
            => new Random().NextFloat(10, viewport.Width - 10);

        private static float GenerateRandomYPosition()
            => new Random().NextFloat(-40, -400);

        private void Fire(List<IGameEntity> gameEntities)
        {
            var texture = _contentManager.Load<Texture2D>(Constants.GameEntityTypes.EnemyLaser);

            var bulletPosition = _position;
            bulletPosition.X += (float)_texture.Width / 2;
            bulletPosition.Y += _texture.Height;

            var newLaser = new EnemyLaser(texture, _viewport, bulletPosition, 2 * _currentLevel / 2);

            gameEntities.Add(newLaser);
        }

        private bool IsSpriteOffTheScreen()
            => _position.Y > _viewport.Height;
    }
}
