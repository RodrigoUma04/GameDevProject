using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace ProjectGame.Entities
{
    enum CStates { IDLE, RUNNING, JUMPING, SHOOTING, SLIDE, RUNSHOOTING, DUCK, HURT}
    class Hero
    {
        private static Hero uniqueInstance = new Hero();
        public ContentManager contentManager { get; set; }
        
        private CStates currentState;
        private Dictionary<CStates, Texture2D> spritesheets;
        private Dictionary<CStates, int> framecounts;
        private double frameTimer;
        private double frameInterval; 
        private int frameWidth;
        private int frameHeight;
        private int currentFrame;

        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
        }


        private Keys previousKey;

        private Hero() {
            currentState = CStates.IDLE;
            spritesheets = new Dictionary<CStates, Texture2D>();
            framecounts = new Dictionary<CStates, int>();

            frameTimer = 0f;
            frameInterval = 0.2f;
            currentFrame = 0;

            position = new Vector2(32, 334);
        }
        public static Hero getHero()
        {
            return uniqueInstance;
        }

        public void LoadAnimations()
        {
            spritesheets[CStates.IDLE] = contentManager.Load<Texture2D>("Animations/player-idle");
            spritesheets[CStates.RUNNING] = contentManager.Load<Texture2D>("Animations/player-run");

            framecounts[CStates.IDLE] = 6;
            framecounts[CStates.RUNNING] = 6;

            frameHeight = spritesheets[CStates.IDLE].Height;
            frameWidth = spritesheets[CStates.IDLE].Width / framecounts[CStates.IDLE];
        }

        public void Update(float delta)
        {
            HandleInput();

            frameTimer += delta;
            if(frameTimer >= frameInterval)
            {
                currentFrame++;
                if(currentFrame >= framecounts[currentState])
                {
                    currentFrame = 0;
                }

                frameTimer -= frameInterval;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRect = new Rectangle(frameWidth * currentFrame, 0, frameWidth, frameHeight);

            if (previousKey == Keys.Left)
            {
                spriteBatch.Draw(spritesheets[currentState], position, sourceRect, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0);
            }
            else
            {
                spriteBatch.Draw(spritesheets[currentState], position, sourceRect, Color.White);
            }
        }

        private void HandleInput()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Q) || Keyboard.GetState().IsKeyDown(Keys.Left)) {
                ChangeState(CStates.RUNNING);
                frameInterval = 0.1f;
                previousKey = Keys.Left;

                if(position.X > 0)
                    position.X -= 5;
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right)){
                ChangeState(CStates.RUNNING);
                frameInterval = 0.1f;
                previousKey = Keys.Right;

                if(position.X < 3072 - 100)
                    position.X += 5;
            }
            else
            {
                ChangeState(CStates.IDLE);
            }

        }

        public void ChangeState(CStates newState)
        {
            if (currentState != newState)
            {
                currentState = newState;
                currentFrame = 0;
                frameTimer = 0f;
                frameInterval = 0.2f;
            }
        }
    }
}
