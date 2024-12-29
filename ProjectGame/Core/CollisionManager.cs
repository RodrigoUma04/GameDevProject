using MonoGame.Extended.Tiled;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ProjectGame.Entities;

namespace ProjectGame.Core
{
    class CollisionManager
    {
        /// Trying to use an object layer instead
        private List<ICollidable> collidables;
        private TiledMapObjectLayer _collisionLayer;
        private const int tileWidth = 32;
        private const int tileHeight = 32;

        public CollisionManager(TiledMapObjectLayer collisionLayer)
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
                Rectangle bounds = coll.Bounds;

                string colliderType = GetColliderType(bounds);

                if (IsCollidingWithObject(bounds))
                {
                    coll.OnCollision(colliderType);
                }
            }
        }
        private bool IsCollidingWithObject(Rectangle bounds)
        {
            foreach (var tiledObject in _collisionLayer.Objects)
            {
                Rectangle objectBounds = GetObjectBounds(tiledObject);

                if (bounds.Intersects(objectBounds))
                {
                    if (tiledObject.Properties.TryGetValue("Collidable", out string isCollidable))
                    {
                        if (isCollidable == "true")
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private string GetColliderType(Rectangle bounds)
        {
            foreach(var tiledObject in _collisionLayer.Objects)
            {
                Rectangle objectBounds = GetObjectBounds(tiledObject);

                if (bounds.Intersects(objectBounds))
                {
                    if (tiledObject.Properties.TryGetValue("Type", out string type))
                    {
                        return type;
                    }
                }
            }
            return null;
        }

        private Rectangle GetObjectBounds(TiledMapObject tiledObject)
        {
            return  new Rectangle(
                    (int)tiledObject.Position.X,
                    (int)tiledObject.Position.Y,
                    (int)tiledObject.Size.Width,
                    (int)tiledObject.Size.Height
                );
        }
    }
}
