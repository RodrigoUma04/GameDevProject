using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectGame.Core;
using ProjectGame.Screens;

namespace ProjectGame
{
    public class Game1 : Game
    {
        #region Screens config
        public static int ScreenWidth = 1000;
        public static int ScreenHeight = 500;

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

            StateManager = new GameStateManager();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            StateManager.ChangeState(new MenuScreen(),Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) || StateManager.CurrentState is ExitState)
                Exit();

            float delta = (float) gameTime.ElapsedGameTime.TotalMilliseconds / 1000f; // use this for consistency in time related tasks between lower and higher performing devices

            StateManager.Update(delta);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black); // clears the screen when changing states
            StateManager.Draw(_spriteBatch);
            base.Draw(gameTime);
        }
    }
}
