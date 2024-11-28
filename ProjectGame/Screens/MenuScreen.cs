using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGame.Screens
{
    class MenuScreen : IScreen
    {
        private Texture2D _backgroundImage;
        public void LoadContent(ContentManager content)
        {
            _backgroundImage = content.Load<Texture2D>("Background/background");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var origin = new Vector2(_backgroundImage.Width/2f, _backgroundImage.Height/2f); // sets the origin point of the picture to the middle

            spriteBatch.Begin();
            spriteBatch.Draw(
                _backgroundImage, 
                new Vector2(Game1.ScreenWidth/2f, Game1.ScreenHeight/2f),
                null,
                Color.White,
                0f,
                origin,
                1f,
                SpriteEffects.None,
                0f)
                ;
            spriteBatch.End();
        }

        public void Update(float delta)
        {
            
        }
    }
}
