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

        private Camera camera;
        private CollisionManager collisionManager;
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
            camera = new Camera(new Vector2(3072, 512));

            hero.contentManager = content;
            hero.LoadAnimations();

            collisionManager = new CollisionManager((TiledMapObjectLayer)_tiledMap.GetLayer("collision"));
            collisionManager.RegisterObject(hero);
        } 
        
        public void Update(float delta)
        {
            hero.Update(delta);
            camera.Update(hero.Position);
            collisionManager.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _mapRenderer.Draw(viewMatrix: camera.GetViewMatrix());

            spriteBatch.Begin(transformMatrix: camera.GetViewMatrix());
            hero.Draw(spriteBatch);
            spriteBatch.End();
        }
       

        /// I need to think about the shooting mechanic (different guns, ground loot..., maybe buy mechanic?)
       
        /// TO-DO
        /// 1. Spawn point
        /// 2. Provide the hero with the necessary properties/methods (HP, damage with gun...)
        /// 3. Fix gravity for jumping
        /// 4. Fix collision and walls for map borders
    }
}
