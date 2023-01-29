using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX;
using Color = Microsoft.Xna.Framework.Color;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Viewport = Microsoft.Xna.Framework.Graphics.Viewport;

namespace EndlessSpaceInvasion
{
    internal class EnemyShipSprite                          //used for creating random number of enemy sprites then randomly spawns them in random positions 
    {
        private Texture2D _texture;
        private readonly Viewport _viewport;
        public Vector2 Position;

        private const float RateOfSpeed = 0.7f;

        public EnemyShipSprite(Texture2D texture, Viewport viewport)
        {
            _texture = texture;
            _viewport = viewport;

            Position = new Vector2(GenerateRandomXPosition(viewport), GenerateRandomYPosition());
        }

        public void Update()
        {
            if (Position.Y > _viewport.Height)
                Position.Y = 0;

            Position.Y += RateOfSpeed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }

        private static float GenerateRandomXPosition(Viewport viewport)
            => new Random().NextFloat(10, viewport.Width - 10);

        private static float GenerateRandomYPosition()
            => new Random().NextFloat(-40, -400);
    }
}
