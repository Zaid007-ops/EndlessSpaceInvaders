using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace EndlessSpaceInvasion
{
    internal class Laser : IGameEntity
    {
        public Texture2D Texture;
        private Viewport Viewport;
        public Vector2 Position;
        private float _directionOfTravel;
        public Vector2 Velocity;
        public Vector2 Origin;
        private bool _isVisible;

        public Laser(Texture2D _texture1, Viewport viewport, Vector2 initialPosition, float directionOfTravel)
        {
            Texture = _texture1;
            Position = initialPosition;
            _directionOfTravel = directionOfTravel;
            Viewport = viewport;
            Velocity = new Vector2(_texture1.Width, _texture1.Height);
            IsVisible = true;
            
        }

        public string Type { get => "Laser"; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }

        public void Update(GameTime gameTime, List<IGameEntity> gameEntities, KeyboardState currentKey, KeyboardState previousKey)
        {
            Position.Y += _directionOfTravel;

            if (Position.Y < 0)
                IsVisible = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0);
        }
    }
}
