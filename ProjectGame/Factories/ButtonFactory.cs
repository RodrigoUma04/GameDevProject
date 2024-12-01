using System.Collections.Generic;
using Microsoft.Xna.Framework;
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
                    generatePaths("Buttons/Start/Text_Start_Button_0", textures);
                    return new StartButton(textures, YPosition, screenCenter, _content);

                case ButtonType.ExitButton:
                    generatePaths("Buttons/Exit/Text_Exit_Button_0", textures);
                    return new ExitButton(textures, YPosition, screenCenter, _content);
                    // add more buttons here
                default:
                    return null;
            }
        }

        public void generatePaths(string path, List<Texture2D> textures)
        {
            for (int i = 1; i <= 3; i++)
            {
                textures.Add(_content.Load<Texture2D>(path + i));
            }
        }
    }
}
