using MonoGame.Extended.Tiled;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGame.Core
{
    class CollisionManager
    {
        private List<ICollidable> collidables;
        private TiledMapTileLayer _collisionLayer;
        private const int tileWidth = 32;
        private const int tileHeight = 32;

        public CollisionManager(TiledMapTileLayer collisionLayer)
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
                /// 1. Get the bounds of the object
                /// 2. Get the coordinates of the tile its on
                /// 3. Check if it collides with tile
                /// 4. Check if the tile is collidable

                Rectangle bounds = coll.Bounds;

                if (IsCollidingWithTile(bounds))
                {
                    coll.OnCollision();
                }
            }
        }

        public bool IsCollidingWithTile(Rectangle bounds)
        {
            // Gets the bound corners and coverts it tile grid coordinates
            Point topLeft = new Point(bounds.Left / tileWidth, bounds.Top / tileHeight);
            Point topRight = new Point(bounds.Right / tileWidth, bounds.Top / tileHeight);
            Point bottomLeft = new Point(bounds.Left / tileWidth, bounds.Bottom / tileHeight);
            Point bottomRight = new Point(bounds.Right / tileWidth, bounds.Bottom / tileHeight);

            return IsTileCollidable(topLeft) || IsTileCollidable(topRight) ||
                   IsTileCollidable(bottomLeft) || IsTileCollidable(bottomRight);
        }

        // Checks if tile has the collidable property set to true
        public bool IsTileCollidable(Point tilePosition)
        {
            var tile = _collisionLayer.GetTile((ushort)tilePosition.X, (ushort)tilePosition.Y);

            /// TODO: fix the property check
            return true;
        }
    }
}
