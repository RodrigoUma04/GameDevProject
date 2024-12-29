using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGame.Entities
{
    interface ICollidable
    {
        Rectangle Bounds { get; set; }
        void OnCollision(string colliderType);
    }
}
