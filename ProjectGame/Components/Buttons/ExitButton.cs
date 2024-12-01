using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ProjectGame.Core;

namespace ProjectGame.Components.Buttons
{
    public class ExitButton : Button
    {
        public ExitButton(List<Texture2D> textures, int position, Vector2 screenCenter, ContentManager content ) : base(textures, position, screenCenter, content) { }

        public override void OnClick()
        {
            Game1.StateManager.ChangeState(new ExitState(), content);
        }
    }
}
