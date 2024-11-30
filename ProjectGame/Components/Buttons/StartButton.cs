using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using ProjectGame.Core;
using ProjectGame.Screens;
using Microsoft.Xna.Framework.Content;
using ProjectGame;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics;

namespace ProjectGame.Components.Buttons
{
    public class StartButton : Button
    {
        public StartButton(List<Texture2D> textures, int position, Vector2 screenCenter, ContentManager content): base(textures, position, screenCenter, content) { }

        public override void OnClick()
        {
            Debug.WriteLine("Start button was pressed");
            Game1.StateManager.ChangeState(new LevelOneScreen(), content);
        }
    }
}
