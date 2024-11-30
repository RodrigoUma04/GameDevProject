using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
