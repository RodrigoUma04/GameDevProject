using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectGame.Screens;
using System.Runtime.CompilerServices;

namespace ProjectGame
{
    public class Game1 : Game
    {
        #region Screens config
        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;

        public static GameStateManager StateManager;
        #endregion

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // actually apply the new dimensions to the GraphicsDeviceManager
            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            StateManager = new GameStateManager();
            StateManager.ChangeState(new MenuScreen(),Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            float delta = (float) gameTime.ElapsedGameTime.TotalMilliseconds / 1000f; // use this for consistency in time related tasks between lower and higher performing devices

            StateManager.Update(delta);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            StateManager.Draw(_spriteBatch);
            base.Draw(gameTime);
        }
    }
}
