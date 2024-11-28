using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectGame.Screens;

namespace ProjectGame
{
    public class Game1 : Game
    {
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
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _menuScreen = new MenuScreen();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            float delta = (float) gameTime.ElapsedGameTime.TotalMilliseconds / 1000f; // use this for consistency in time related tasks between lower and higher performing devices

            _menuScreen.Update(delta);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            // _menuScreen.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
