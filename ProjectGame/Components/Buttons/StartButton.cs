using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGame.Components.Buttons
{
    public class StartButton : Button
    {
        public StartButton(List<Texture2D> textures, Vector2 position, float scale, Vector2 screenCenter): base(textures, position, scale, screenCenter) { }
    }
}
