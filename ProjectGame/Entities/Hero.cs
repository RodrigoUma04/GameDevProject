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

        private Hero() {
            currentState = CStates.IDLE;
            spritesheets = new Dictionary<CStates, Texture2D>();
            framecounts = new Dictionary<CStates, int>();

            frameTimer = 0f;
            frameInterval = 0.2f;
            currentFrame = 0;

            position = new Vector2(32, 333);
        }
        public static Hero getHero()
        {
            return uniqueInstance;
        }

        public void LoadAnimations()
        {
            spritesheets[CStates.IDLE] = contentManager.Load<Texture2D>("Animations/player-idle");

            framecounts[CStates.IDLE] = 6;

            frameHeight = spritesheets[CStates.IDLE].Height;
            frameWidth = spritesheets[CStates.IDLE].Width / framecounts[CStates.IDLE];
        }

        public void Update(float delta)
        {
            // here comes the if structure that supports movement and animations
            // for testing purposes only going to test the 'else' case AKA player idle

            frameTimer += delta;
            if(frameTimer >= frameInterval)
            {
                currentFrame++;
                if(currentFrame >= framecounts[currentState])
                {
                    currentFrame = 0;
                }

                frameTimer -= frameInterval; // need to reset else the if will keep being false
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRect = new Rectangle(frameWidth * currentFrame, 0, frameWidth, frameHeight);

            
            spriteBatch.Draw(spritesheets[currentState], position, sourceRect, Color.White);
        }

        private void HandleInput()
        {

        }

        public void ChangeState(CStates newState)
        {
            if (currentState != newState)
            {
                currentState = newState;
                currentFrame = 0;
                frameTimer = 0f;
            }
        }
    }
}
