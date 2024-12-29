using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectGame.States
{
    public interface IGameState
    {
        void LoadContent(ContentManager content);
        void Update(float delta);
        void Draw(SpriteBatch spriteBatch);
    }
}
