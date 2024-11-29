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
    class MenuScreen : IGameState
    {
        private Texture2D _backgroundImage;

        public void LoadContent(ContentManager content)
        {
            _backgroundImage = content.Load<Texture2D>("Background/background");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 screenCenter = new Vector2(Game1.ScreenWidth / 2f, Game1.ScreenHeight / 2f); // sets center of the screen
            Vector2 imageOrigin = new Vector2(_backgroundImage.Width/2f, _backgroundImage.Height/2f); // sets the origin point of the picture to the middle

            spriteBatch.Begin();
            spriteBatch.Draw(
                _backgroundImage, 
                screenCenter,
                null,
                Color.White,
                0f,
                imageOrigin,
                1f,
                SpriteEffects.None,
                0f)
                ;

            spriteBatch.End();
        }

        // yet to implement
        public void Update(float delta)
        {
            
        }
    }
}
