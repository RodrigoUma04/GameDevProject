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
        public StartButton(List<Texture2D> textures, int position, Vector2 screenCenter): base(textures, position, screenCenter) { }

        // here I can implement a OnClick event that redirect to the first (or current level --> another state)
        public override void OnClick()
        {
            throw new NotImplementedException();
        }
    }
}
