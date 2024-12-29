using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProjectGame.States;
using System.Reflection.Metadata.Ecma335;

namespace ProjectGame.Core
{
    public class GameStateManager
    {
        public IGameState CurrentState { get; private set; }

        public GraphicsDevice GraphicsDevice { get; set; } // set as property, because only needed in certain states

        public GameStateManager(GraphicsDevice graphicsDevice)
        {
            this.GraphicsDevice = graphicsDevice;
        }

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
