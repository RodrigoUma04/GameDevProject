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
    public enum ButtonType { StartButton, ExitButton}
    public class ButtonFactory
    {
        private ContentManager _content;
        public ButtonFactory(ContentManager content)
        {
            _content = content;
        }

        public Button CreateButton(ButtonType type, int YPosition, Vector2 screenCenter)
        {
            List<Texture2D> textures = new List<Texture2D>();
            // create button based on type and provide them with needed assets
            switch (type)
            {
                case ButtonType.StartButton:
                    for (int i = 1; i <= 3; i++)
                    {
                        textures.Add(_content.Load<Texture2D>($"Buttons/Start/Text_Start_Button_0{i}"));
                    }
                    Button start = new StartButton(textures, YPosition, screenCenter, _content);
                    return start;

                case ButtonType.ExitButton:
                    for (int i = 1; i <= 3; i++)
                    {
                        textures.Add(_content.Load<Texture2D>($"Buttons/Exit/Text_Exit_Button_0{i}"));
                    }
                    Button exit = new ExitButton(textures, YPosition, screenCenter, _content);
                    return exit;
                    // add more buttons here
                default:
                    return null;
            }
        }
    }
}
