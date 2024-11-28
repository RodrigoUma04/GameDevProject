using Microsoft.Xna.Framework.Content;
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
        void LoadContent(ContentManager content);
        void Update(float delta);
        void Draw(SpriteBatch spriteBatch);
    }
}
