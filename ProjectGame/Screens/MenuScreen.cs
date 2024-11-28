using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGame.Screens
{
    class MenuScreen : IScreen
    {

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            // draw things in here

            spriteBatch.End();
        }

        public void Update(float delta)
        {
            
        }
    }
}
