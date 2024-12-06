using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace ProjectGame.Components
{
    public abstract class Button
    {
        private List<Texture2D> _textures;
        private int _position;
        private Vector2 _buttonCenter;
        private Vector2 _screenCenter;

        private MouseState _previousMouseState;
        private bool _isHovered;

        protected ContentManager _content;

        public Button(List<Texture2D> textures, int position, Vector2 screenCenter, ContentManager content)
        {
            _textures = textures;
            _position = position;
            _screenCenter = screenCenter;
            _buttonCenter = new Vector2(textures[0].Width / 2f, textures[0].Height / 2f);
            _content = content;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(_textures != null)
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
            // get current mouse state and position
            MouseState currentMouseState = Mouse.GetState();
            Point mousePosition = currentMouseState.Position;

            Rectangle buttonBounds = new Rectangle(
                (int)(_screenCenter.X - _buttonCenter.X),
                (int)(_screenCenter.Y + _position - _buttonCenter.Y), // forgot to add the Y position which also serves as space between the buttons, this caused a bug, because rectangles would be drawn over each other
                _textures[0].Width,
                _textures[0].Height
                );


            _isHovered = buttonBounds.Contains(mousePosition);

            // check if pointer is hovering the button and if a click has happened
            if (_isHovered && currentMouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed)
            {
                OnClick();
            }

            _previousMouseState = currentMouseState;

            // add animation yet
        }

        public abstract void OnClick();
    }
}
