using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
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
        private Song _backgroundMusic;
        
        public LevelOneScreen(GraphicsDevice graphicsDevice)
        {
            this._graphicsDevice = graphicsDevice;
        }

        public void LoadContent(ContentManager content)
        {
            _tiledMap = content.Load<TiledMap>("Levels/Level 1/Level 1");
            _mapRenderer = new TiledMapRenderer(_graphicsDevice, _tiledMap);
            _backgroundMusic = content.Load<Song>("Music/Flood Escape 2 - Ignis Peaks 8-Bit Remix");

            MediaPlayer.Play(_backgroundMusic);
            MediaPlayer.IsRepeating = true;
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
