using System.Collections.Generic;
using System.Linq;

namespace EndlessSpaceInvasion
{
    public static class CollisionDetectionService
    {
        public static List<IGameEntity> DetectCollisions(List<IGameEntity> gameEntities)
        {
            var entities = new List<IGameEntity>();

            var enemies = gameEntities.Where(e => e.IsEnemy).ToList();
            var lasers = gameEntities.Where(e => e.Type == "PlayerLaser").ToList();
            var playerOne = gameEntities.Where(e => e.Type == "PlayerOne").Single();
            var enemyLasers = gameEntities.Where(e => e.Type == "EnemyLaser").ToList();

            foreach (var enemy in enemies)
            {
                foreach (var laser in lasers)
                {
                    if (enemy.Boundary.Intersects(laser.Boundary))
                    {
                        entities.Add(enemy);
                        entities.Add(laser);
                    }
                }
            }

            foreach (var enemyLaser in enemyLasers)
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
