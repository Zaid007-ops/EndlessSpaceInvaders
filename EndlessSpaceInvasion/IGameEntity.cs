using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessSpaceInvasion
{
    public interface IGameEntity
    {
        string Type { get; }
        bool IsVisible { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
