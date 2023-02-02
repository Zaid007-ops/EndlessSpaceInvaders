using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessSpaceInvasion
{
    internal class HealthBar
    {
        private Texture2D healthTexture;              //texture is loaded for the healthbar
        private Vector2 healthPosition;               // position of the healthbar
        private Rectangle healthRectangle;          //Image of the healthbar

        public HealthBar(Texture2D texture)
        {
            healthTexture = texture;
            healthPosition = new Vector2(50, 30);                       //position of the health bar
            healthRectangle = new Rectangle(10, 10, healthTexture.Width, healthTexture.Height);    // creates healthbar
        }

        public void Update()
        {
            healthRectangle.Width -= 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(healthTexture, healthPosition, healthRectangle, Color.White);
        }
    }
}
