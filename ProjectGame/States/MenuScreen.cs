﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using ProjectGame.Components;
using ProjectGame.Factories;
using ProjectGame.States;
using System.Collections.Generic;

namespace ProjectGame.Screens
{
    class MenuScreen : IGameState
    {
        private Texture2D _backgroundImage;
        private ButtonFactory _buttonFactory;
        private List<Button> _buttons;
        private Vector2 _screenCenter;
        private Song _backgroundMusic;

        public MenuScreen()
        {
            _buttons = new List<Button>();
            _screenCenter = new Vector2(Game1.ScreenWidth / 2f, Game1.ScreenHeight / 2f); // sets center of the screen
        }

        public void LoadContent(ContentManager content)
        {
            _backgroundImage = content.Load<Texture2D>("Background/background");
            _backgroundMusic = content.Load<Song>("Music/Cave of Rønen (8-bit Video Game Music)");

            MediaPlayer.Play(_backgroundMusic);
            MediaPlayer.IsRepeating = true;

            _buttonFactory = new ButtonFactory(content);

            _buttons.Add(_buttonFactory.CreateButton(ButtonType.StartButton, 20, _screenCenter));
            _buttons.Add(_buttonFactory.CreateButton(ButtonType.ExitButton, 100, _screenCenter));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 imageOrigin = new Vector2(_backgroundImage.Width/2f, _backgroundImage.Height/2f); // sets the origin point of the picture to the middle
            spriteBatch.Begin();

            spriteBatch.Draw(
                _backgroundImage, 
                _screenCenter,
                null,
                Color.White,
                0f,
                imageOrigin,
                1f,
                SpriteEffects.None,
                0f);

            foreach(var button in _buttons)
            {
                button?.Draw(spriteBatch);
            }
           

            spriteBatch.End();
        }

        public void Update(float delta)
        {
            foreach (var button in _buttons)
            {
                button?.Update(delta);
            }
        }
    }
}
