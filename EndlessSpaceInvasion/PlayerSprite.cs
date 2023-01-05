using Microsoft.Xna.Framework;                                  // needed for the Vector2
using Microsoft.Xna.Framework.Graphics;                         // needed for the texture 
using Microsoft.Xna.Framework.Input;                            // needed for Keyboard.GetState() to work
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessSpaceInvasion
{
    internal class PlayerSprite
    {
        private Texture2D _texture;
        public Vector2 Position;

        public PlayerSprite(Texture2D texture)
        {
            _texture = texture;
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Position.Y -= 3;                          // moves the sprite up
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Position.Y += 3;                        // moves the sprite down
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))                                                 // the speed of the sprites is set to 3
            {
                Position.X += 3;                         // moves the sprite right
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Position.X -= 3;                         // moves the sprite left 
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }
    }
}
