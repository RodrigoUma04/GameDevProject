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
        private Vector2 _position;
        private Vector2 _buttonCenter;
        private Vector2 _screenCenter;

        private float _scale;

        public Button(List<Texture2D> textures, Vector2 position, float scale, Vector2 screenCenter)
        {
            _textures = textures;
            _position = position;
            _scale = scale;
            _screenCenter = screenCenter;
            _buttonCenter = new Vector2(textures[0].Width / 2f, textures[0].Height / 2f);
        }

        public virtual void Draw(SpriteBatch spriteBatch) // why should this be virtual?
        {
            if(_textures != null) // to avoid weird bugs
            {
                spriteBatch.Draw(
                    _textures[0],
                    _screenCenter,
                    null,
                    Color.White,
                    0f,
                    _buttonCenter,
                    _scale,
                    SpriteEffects.None,
                    0f
                    );
            }
        }
    }
}
