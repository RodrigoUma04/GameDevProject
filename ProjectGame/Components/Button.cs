using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ProjectGame.Components
{
    public abstract class Button
    {
        // all the properties I think I need for a button.
        private List<Texture2D> _textures; // I need this to be loaded in the specific button class
        private int _position;
        private Vector2 _buttonCenter;
        private Vector2 _screenCenter;

        private MouseState _previousMouseState;
        private bool _isHovered;

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
            // make the detection for hovering and then for a click
            // click then need the onclick method, which is abstract and need to be implemented for every specific button

            // get current mouse state and position
            MouseState currentMouseState = Mouse.GetState();
            Point mousePosition = currentMouseState.Position;

            Rectangle buttonBounds = new Rectangle(
                (int)(_screenCenter.X - _buttonCenter.X),
                (int)(_screenCenter.Y - _buttonCenter.Y),
                _textures[0].Width,
                _textures[0].Height
                );

            _isHovered = buttonBounds.Contains(mousePosition);

            if(_isHovered && currentMouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed) // check if pointer is hovering the button and if a click has happened
            {
                OnClick();
            }
        }

        public abstract void OnClick();
    }
}
