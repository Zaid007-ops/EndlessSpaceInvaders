using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace EndlessSpaceInvasion
{
    public static class CollisionDetectionService
    {
        public static List<IGameEntity> DetectCollisions(List<IGameEntity> gameEntities)
        {
            var entities = new List<IGameEntity>();

            var playerOne = gameEntities.Where(e => e.Type == Constants.GameEntityTypes.PlayerOne).Single();

            foreach (var enemy in gameEntities.Where(e => e.IsEnemy).ToList())
            {
                foreach (var laser in gameEntities.Where(e => e.Type == Constants.GameEntityTypes.PlayerLaser).ToList())
                {
                    if (enemy.Boundary.Intersects(laser.Boundary))
                    {
                        entities.Add(enemy);
                        entities.Add(laser);
                    }
                }
            }

            foreach (var enemyLaser in gameEntities.Where(e => e.Type == Constants.GameEntityTypes.EnemyLaser).ToList())
            {
                if (enemyLaser.Boundary.Intersects(playerOne.Boundary))
                {
                    entities.Add(enemyLaser);
                    entities.Add(playerOne);
                }
            }

            return entities;
        }
    }
}
