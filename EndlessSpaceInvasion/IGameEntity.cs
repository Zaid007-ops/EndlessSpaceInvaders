using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace EndlessSpaceInvasion
{
    public interface IGameEntity
    {
        string Type { get; }
        bool IsVisible { get; set; }
        bool IsEnemy { get; }
        void Update(GameTime gameTime, List<IGameEntity> gameEntities, KeyboardState currentKey, KeyboardState previousKey);
        void Draw(SpriteBatch spriteBatch);
    }
}
