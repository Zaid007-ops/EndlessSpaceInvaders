﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Viewport = Microsoft.Xna.Framework.Graphics.Viewport;

namespace EndlessSpaceInvasion
{
    public class MotherShip : IGameEntity
    {
        private readonly ContentManager _contentManager;
        private bool _isVisible;
        private Texture2D _texture;
        private readonly Viewport _viewport;
        private readonly int _currentLevel;
        public Vector2 _position;
        private float _rateOfSpeed;
        private float _timeSinceLastShot;

        public string Type { get => Constants.GameEntityTypes.MotherShip; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }
        public bool IsEnemy => true;
        public int Health { get; set; }
        public Rectangle Boundary { get => new((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height); }
        public Vector2 Position { get => _position; }

        public MotherShip(ContentManager contentManager, Viewport viewport, float speed, int currentLevel)
        {
            _isVisible = true;
            _contentManager = contentManager;
            _texture = contentManager.Load<Texture2D>("MotherShip");
            _viewport = viewport;
            _currentLevel = currentLevel;
            _rateOfSpeed = speed;
            _timeSinceLastShot = 2;
            Health = 8;

            _position = new Vector2(GenerateRandomXPosition(viewport, _texture), GenerateRandomYPosition());
        }

        public void Update(GameTime gameTime, List<IGameEntity> gameEntities, KeyboardState currentKey, KeyboardState previousKey)
        {
            _position.X = CalculateX(gameEntities);
            _position.Y += _rateOfSpeed;

            if (HealthChecker.IsDead(Health))
                _isVisible = false;

            if (IsSpriteOffTheScreen())
            {
                _position.X = new Random().Next(30, _viewport.Width);
                _position.Y = -10;
            }

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

        private void Fire(List<IGameEntity> gameEntities)
        {
            var texture = _contentManager.Load<Texture2D>(Constants.GameEntityTypes.EnemyLaser);

            var bulletPosition = Position;
            bulletPosition.X += (float)_texture.Width / 2;
            bulletPosition.Y += _texture.Height;

            var newLaser = new EnemyLaser(texture, _viewport, bulletPosition, 2 * _currentLevel / 2);

            gameEntities.Add(newLaser);
        }

        private static float GenerateRandomXPosition(Viewport viewport, Texture2D texture)
            => new Random().NextFloat(10, viewport.Width - texture.Width);

        private static float GenerateRandomYPosition()
            => new Random().NextFloat(-40, -400);

        private IGameEntity FindPlayerOne(List<IGameEntity> gameEntities)
            => gameEntities.Single(e => e.Type == Constants.GameEntityTypes.PlayerOne);
        
        private float CalculateX(List<IGameEntity> gameEntities)
        {
            var playerOne = FindPlayerOne(gameEntities);

            var currentPosition = Position.X;
            var playerOnePosition = playerOne.Position.X;
            var difference = currentPosition - playerOnePosition;

            return difference >= 0.0
                ? _position.X -= _rateOfSpeed
                : _position.X += _rateOfSpeed;
        }
        
        private bool IsSpriteOffTheScreen()
            => Position.Y > _viewport.Height;
    }
}
