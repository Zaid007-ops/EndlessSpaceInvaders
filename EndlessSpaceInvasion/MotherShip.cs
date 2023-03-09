using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace EndlessSpaceInvasion
{
    internal class MotherShip : IGameEntity
    {
        // USE A* ALGORITHM FOR AI PATHFINDING
        private readonly ContentManager _contentManager;
        private bool _isVisible;
        private Texture2D _texture;
        private readonly Viewport _viewport;
        public Vector2 Position;

        public string Type { get => "MotherShip"; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }
        public bool IsEnemy => true;
        public int Health { get; set; }
        public Rectangle Boundary { get => new((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height); }

        public MotherShip(ContentManager contentManager, Viewport viewport)
        {
            _isVisible = true;
            _contentManager = contentManager;
            _texture = contentManager.Load<Texture2D>("RedEnemyShip");
            _viewport = viewport;
            Health = 8;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime, List<IGameEntity> gameEntities, KeyboardState currentKey, KeyboardState previousKey)
        {
            throw new NotImplementedException();
        }
    }
}
