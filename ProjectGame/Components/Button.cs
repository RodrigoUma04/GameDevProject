using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ProjectGame.Components
{
    public abstract class Button
    {
        // all the properties I think I need for a button.
        private List<Texture2D> _textures; // I need this to be loaded in the specific button class
        private int _position;
        private Vector2 _buttonCenter;
        private Vector2 _screenCenter;

        public Button(List<Texture2D> textures, int position, Vector2 screenCenter)
        {
            _textures = textures;
            _position = position;
            _screenCenter = screenCenter;
            _buttonCenter = new Vector2(textures[0].Width / 2f, textures[0].Height / 2f);
        }

        public void Draw(SpriteBatch spriteBatch) // use virtual if more in depth drawing per button is needed
        {
            if(_textures != null) // to avoid weird bugs
            {
                spriteBatch.Draw(
                    _textures[0],
                    new Vector2(_screenCenter.X, _screenCenter.Y + _position), // this sets the origin point to the center of the screen and allows to set a button higher or lower with 'position' // temp?
                    null,
                    Color.White,
                    0f,
                    _buttonCenter,
                    1f,
                    SpriteEffects.None,
                    0f
                    );
            }
        }

        public void Update(float delta)
        {

        }

        public abstract void OnClick();
    }
}
