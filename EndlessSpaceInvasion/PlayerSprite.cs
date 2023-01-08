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
        private Viewport _viewport;
        public Vector2 Position;

        public PlayerSprite(Texture2D texture, Viewport viewport)
        {
            _texture = texture;
            _viewport = viewport;
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W)) // moves the sprite up
            {
                if (Position.Y >= 10)
                    Position.Y -= 3;                          
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))// moves the sprite down
            {
                if (Position.Y < _viewport.Height - 30)
                    Position.Y += 3;                       
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))   // moves the sprite right 
            {
                if (Position.X < _viewport.Width - 30)
                    Position.X += 3;                         
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A)) // moves the sprite left 
            {
                if (Position.X >= 10)
                    Position.X -= 3;                         
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }
    }
}
