using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace EndlessSpaceInvasion
{
    internal class PlayerLaser : IGameEntity
    {
        public Texture2D Texture;
        private Viewport _viewport;
        public Vector2 Position;
        private float _directionOfTravel;
        public Vector2 Velocity;
        public Vector2 Origin;
        private bool _isVisible;

        public PlayerLaser(Texture2D _texture1, Viewport viewport, Vector2 initialPosition, float directionOfTravel)
        {
            Texture = _texture1;
            Position = initialPosition;
            _directionOfTravel = directionOfTravel;
            _viewport = viewport;
            Velocity = new Vector2(_texture1.Width, _texture1.Height);
            IsVisible = true;
            Health = 1;
        }

        public string Type { get => Constants.GameEntityTypes.PlayerLaser; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }
        public bool IsEnemy => false;
        public int Health { get; set; }
        public Rectangle Boundary { get => new((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height); }

        public void Update(GameTime gameTime, List<IGameEntity> gameEntities, KeyboardState currentKey, KeyboardState previousKey)
        {
            Position.Y += _directionOfTravel;

            if (IsSpriteOffTheScreen() || HealthChecker.IsDead(Health))
                _isVisible = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0);
        }

        private bool IsSpriteOffTheScreen()
            => Position.Y < 0;
    }
}
