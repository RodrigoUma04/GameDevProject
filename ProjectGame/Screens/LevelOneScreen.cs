using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using ProjectGame.Core;
using System;
using System.Diagnostics;
using System.Linq;
using MonoGame.Extended.Collisions.Layers;
using MonoGame.Extended;
using ProjectGame.Entities;

namespace ProjectGame.Screens
{
    // not yet implemented (for testing purposes)
    class LevelOneScreen : IGameState
    {
        private TiledMap _tiledMap;
        private TiledMapRenderer _mapRenderer;
        private Song _backgroundMusic;

        private Hero hero;
        public LevelOneScreen()
        {
            hero = Hero.getHero();
        }

        public void LoadContent(ContentManager content)
        {
            _tiledMap = content.Load<TiledMap>("Tiled/Levels/Level-1");
            _backgroundMusic = content.Load<Song>("Music/Flood Escape 2 - Ignis Peaks 8-Bit Remix");

            MediaPlayer.Play(_backgroundMusic);
            MediaPlayer.IsRepeating = true;

            _mapRenderer = new TiledMapRenderer(Game1.StateManager.GraphicsDevice, _tiledMap);

            hero.contentManager = content;
            hero.LoadAnimations();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            _mapRenderer.Draw();

            spriteBatch.Begin();
            hero.Draw(spriteBatch);
            spriteBatch.End();
        }
        public void Update(float delta)
        {
            hero.Update(delta);
        }

        ///  1. For movement I need to check the keyboard state AND the previous keyboard state
        ///     This way I can reverse the sprites so the character looks to the way it's going
        ///  2. I need to make spawn points for easier spawning of characters --> maybe irrelevant for only hero testing
        ///  3. I also need to think about the shooting mechanic (different guns, ground loot..., maybe buy mechanic?)
       
        /// TO-DO
        /// 1. Spawn point
        /// 2. Idle animation
        /// 3. Movement, running animations and switching sides
        /// 4. Make the hero a singleton and provide it with the necessary properties/methods
    }
}
