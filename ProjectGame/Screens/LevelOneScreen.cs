using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using ProjectGame.Core;

namespace ProjectGame.Screens
{
    // not yet implemented (for testing purposes)
    class LevelOneScreen : IGameState
    {
        private TiledMap _tiledMap;
        private TiledMapRenderer _mapRenderer;
        private GraphicsDevice _graphicsDevice;
        
        public LevelOneScreen(GraphicsDevice graphicsDevice)
        {
            this._graphicsDevice = graphicsDevice;
        }

        public void LoadContent(ContentManager content)
        {
            _tiledMap = content.Load<TiledMap>("Levels/Level 1/Level 1");
            _mapRenderer = new TiledMapRenderer(_graphicsDevice, _tiledMap);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            _mapRenderer.Draw(); // now I have a weird error where the background doesn't draw.
        }
        public void Update(float delta)
        {
        }
    }
}
