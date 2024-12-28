using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGame.Core
{
    interface ICollidable
    {
        void OnCollision();
    }
}
