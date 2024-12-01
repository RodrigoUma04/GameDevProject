using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectGame.Core
{
    public class GameStateManager
    {
        public IGameState CurrentState { get; private set; }

        public void ChangeState(IGameState newState, ContentManager content)
        {
            CurrentState = newState;
            CurrentState.LoadContent(content);
        }

        // null checks to avoid weird bugs
        public void Update(float delta)
        {
            CurrentState?.Update(delta);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentState?.Draw(spriteBatch);
        }
    }
}
