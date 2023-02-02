using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
