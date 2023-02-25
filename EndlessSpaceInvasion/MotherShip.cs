using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace EndlessSpaceInvasion
{
    internal class MotherShip : IGameEntity
    {
        // USE A* ALGORITHM FOR AI PATHFINDING
        private bool _isVisible;

        public string Type { get => "MotherShip"; }
        public bool IsVisible { get => _isVisible; set => _isVisible = value; }

        public MotherShip()
        {
            _isVisible = true;
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
