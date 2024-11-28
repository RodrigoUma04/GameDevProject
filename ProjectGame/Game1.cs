using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectGame.Screens;

namespace ProjectGame
{
    public class Game1 : Game
    {
        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private IScreen _menuScreen;

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

            _menuScreen = new MenuScreen();
            _menuScreen.LoadContent(Content); // not SOLID
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            float delta = (float) gameTime.ElapsedGameTime.TotalMilliseconds / 1000f; // use this for consistency in time related tasks between lower and higher performing devices

            _menuScreen.Update(delta); // not SOLID

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // for testing purposes
            _menuScreen.Draw(_spriteBatch); // not SOLID

            base.Draw(gameTime);
        }
    }
}
