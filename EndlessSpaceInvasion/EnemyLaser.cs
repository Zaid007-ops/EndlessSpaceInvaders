using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace EndlessSpaceInvasion
{
    internal class EnemyLaser : IGameEntity
    {
        public Texture2D Texture;
        private Viewport _viewport;
        public Vector2 _position;
        private float _directionOfTravel;
        public Vector2 Velocity;
        public Vector2 Origin;
        private bool _isVisible;

        public EnemyLaser(Texture2D _texture1, Viewport viewport, Vector2 initialPosition, float directionOfTravel)
        {
            Texture = _texture1;
            _position = initialPosition;
            _directionOfTravel = directionOfTravel;
            _viewport = viewport;
            Velocity = new Vector2(_texture1.Width, _texture1.Height);
            IsVisible = true;
            Health = 1;
        }

        public string Type { get => Constants.GameEntityTypes.EnemyLaser; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }
        public bool IsEnemy => false;
        public int Health { get; set; }
        public Rectangle Boundary { get => new((int)_position.X, (int)_position.Y, Texture.Width, Texture.Height); }
        public Vector2 Position { get => _position; }

        public void Update(GameTime gameTime, List<IGameEntity> gameEntities, KeyboardState currentKey, KeyboardState previousKey)
        {
            _position.Y += _directionOfTravel;

            if (IsSpriteOffTheScreen() || HealthChecker.IsDead(Health))
                _isVisible = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, _position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0);
        }

        private bool IsSpriteOffTheScreen()
            => _position.Y < 0;
    }
}
