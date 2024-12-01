using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ProjectGame.Screens;
using Microsoft.Xna.Framework.Content;

namespace ProjectGame.Components.Buttons
{
    public class StartButton : Button
    {
        public StartButton(List<Texture2D> textures, int position, Vector2 screenCenter, ContentManager content): base(textures, position, screenCenter, content) { }

        public override void OnClick()
        {
            Game1.StateManager.ChangeState(new LevelOneScreen(), content);
        }
    }
}
