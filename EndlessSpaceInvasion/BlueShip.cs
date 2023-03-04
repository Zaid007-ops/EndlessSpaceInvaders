using Microsoft.Xna.Framework;
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
        private const float RateOfSpeed = 0.9f;
        private float _timeSinceLastShot;

        public string Type { get => "BlueShip"; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }
        public bool IsEnemy { get => true; }

        public BlueShip(ContentManager contentManager, Viewport viewport)
        {
            _contentManager = contentManager;
            _texture = contentManager.Load<Texture2D>("BlueShip");
            _viewport = viewport;
            _isVisible = true;
            _timeSinceLastShot = 2;

            Position = new Vector2(GenerateRandomXPosition(), GenerateRandomYPosition());
        }

        public void Update(GameTime gameTime, List<IGameEntity> gameEntities, KeyboardState currentKey, KeyboardState previousKey)
        {
            Position.X += RateOfSpeed;

            if (Position.X > _viewport.Width)
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
            var texture = _contentManager.Load<Texture2D>("LazerBeam");

            var bulletPosition = Position;
            bulletPosition.X -= 3;
            bulletPosition.Y += 9;

            var newLaser = new Laser(texture, _viewport, bulletPosition, 2);

            gameEntities.Add(newLaser);
        }

    }
}
