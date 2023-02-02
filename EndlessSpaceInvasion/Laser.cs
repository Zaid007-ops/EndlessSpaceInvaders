using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessSpaceInvasion
{
    internal class Laser : IGameEntity
    {
        public Texture2D Texture;
        private Viewport Viewport;
        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Origin;
        private bool _isVisible;

        public Laser(Texture2D _texture1, Viewport viewport, Vector2 initialPosition)
        {
            Texture = _texture1;
            Position = initialPosition;
            Viewport = viewport;
            Velocity = new Vector2(_texture1.Width, _texture1.Height);
            IsVisible = true;
            
        }

        public string Type { get => "Laser"; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }

        public void Update()
        {
            Position.Y -= 5;

            if (Position.Y < 0)
                IsVisible = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0);
        }
    }
}
