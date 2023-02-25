using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessSpaceInvasion
{
    internal class HealthBar : IGameEntity
    {
        private Texture2D healthTexture;              //texture is loaded for the healthbar
        private Vector2 healthPosition;               // position of the healthbar
        private Rectangle healthRectangle;          //Image of the healthbar
        private bool _isVisible;

        public HealthBar(Texture2D texture, Viewport viewport)
        {
            healthTexture = texture;
            healthPosition = new Vector2(viewport.Width - 100, viewport.Height - 40);                       //position of the health bar
            healthRectangle = new Rectangle(10, 10, healthTexture.Width, healthTexture.Height);    // creates healthbar
            _isVisible = true;
        }

        public string Type { get => "HealthBar"; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }

        public void Update(GameTime gameTime, List<IGameEntity> gameEntities, KeyboardState currentKey, KeyboardState previousKey)
        {
            //healthRectangle.Width -= 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(healthTexture, healthPosition, healthRectangle, Color.White);
        }
    }
}
