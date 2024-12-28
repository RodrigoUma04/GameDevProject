using MonoGame.Extended.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGame.Core
{
    class CollisionManager
    {
        private List<ICollidable> collidables;
        private TiledMapLayer _collisionLayer;
        private const int tileWidth = 32;
        private const int tileHeight = 32;

        public CollisionManager(TiledMapLayer collisionLayer)
        {
            collidables = new List<ICollidable>();
            _collisionLayer = collisionLayer;
        }

        public void RegisterObject(ICollidable obj)
        {
            collidables.Add(obj);
        }

        public void UnregisterObject(ICollidable obj)
        {
            collidables.Remove(obj);
        }

        public void Update()
        {
            foreach(var coll in collidables)
            {
                /// Check for collision and call the OnCollision method
            }
        }
    }
}
