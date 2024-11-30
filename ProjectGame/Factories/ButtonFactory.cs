using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProjectGame.Components;
using ProjectGame.Components.Buttons;

namespace ProjectGame.Factories
{
    public enum ButtonType { StartButton}
    public class ButtonFactory
    {
        private ContentManager _content;
        public ButtonFactory(ContentManager content)
        {
            _content = content;
        }

        public Button CreateButton(ButtonType type, Vector2 position, float scale, Vector2 screenCenter)
        {
            switch (type)
            {
                case ButtonType.StartButton:
                    List<Texture2D> textures = new List<Texture2D>();

                    for (int i = 1; i <= 3; i++)
                    {
                        textures.Add(_content.Load<Texture2D>($"Buttons/Start/Text_Start_Button_0{i}"));
                    }
                    return new StartButton(textures, position, scale, screenCenter);
                default:
                    return null;
            }
        }
    }
}
