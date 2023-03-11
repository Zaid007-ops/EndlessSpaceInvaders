using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace EndlessSpaceInvasion
{
    internal class HealthBar : IGameEntity
    {
        private Texture2D Texture;              //texture is loaded for the healthbar
        private Vector2 Position;               // position of the healthbar
        private Rectangle healthRectangle;          //Image of the healthbar
        private bool _isVisible;
        private float _initialWidth;
        private int _initialHealth;

        public HealthBar(Texture2D texture, Viewport viewport)
        {
            Texture = texture;
            Position = new Vector2(viewport.Width - 100, viewport.Height - 40);                       //position of the health bar
            healthRectangle = new Rectangle(10, 10, Texture.Width, Texture.Height);    // creates healthbar
            Health = _initialHealth = 10;
            _isVisible = true;
            _initialWidth = Texture.Width;
        }

        public string Type { get => Constants.GameEntityTypes.HealthBar; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }
        public bool IsEnemy => false;
        public int Health { get; set; }
        public Rectangle Boundary { get => new((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height); }

        public void Update(GameTime gameTime, List<IGameEntity> gameEntities, KeyboardState currentKey, KeyboardState previousKey)
        {
            if (Health == 0)
                healthRectangle.Width = 0;

            healthRectangle.Width = (int)_initialWidth / _initialHealth * Health;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, healthRectangle, Color.White);
        }
    }
}
