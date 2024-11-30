using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using ProjectGame.Core;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics;

namespace ProjectGame.Components.Buttons
{
    public class ExitButton : Button
    {
        public ExitButton(List<Texture2D> textures, int position, Vector2 screenCenter, ContentManager content ) : base(textures, position, screenCenter, content) { }

        public override void OnClick()
        {
            Debug.WriteLine("Exit button was clicked!");
            Game1.StateManager.ChangeState(new ExitState(), content);
        }
    }
}
