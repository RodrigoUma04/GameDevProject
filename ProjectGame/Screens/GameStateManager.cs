using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGame.Screens
{
    public class GameStateManager
    {
        private IGameState _currentState;

        public void ChangeState(IGameState newState, ContentManager content) // does this method need extra content loaders?
        {
            _currentState = newState;
            _currentState.LoadContent(content);
        }

        public void Update(float delta)
        {
            _currentState.Update(delta); // null check needed?
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _currentState.Draw(spriteBatch); // null check needed?
        }
    }
}
