using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGame.Screens
{
    interface IScreen
    {
        void Update(float delta);
        void Draw(SpriteBatch spriteBatch);
    }
}
