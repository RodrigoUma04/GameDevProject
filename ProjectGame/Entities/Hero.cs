using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using ProjectGame.Core;

namespace ProjectGame.Entities
{
    enum CStates { IDLE, RUNNING, JUMPING, SHOOTING, SLIDE, RUNSHOOTING, DUCK, HURT}
    class Hero : ICollidable
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

        private int velocity = 5;

        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
        }

        public Rectangle Bounds { get; set; }

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
            spritesheets[CStates.IDLE] = contentManager.Load<Texture2D>("Animations/Player/player-idle");
            spritesheets[CStates.RUNNING] = contentManager.Load<Texture2D>("Animations/Player/player-run");
            spritesheets[CStates.JUMPING] = contentManager.Load<Texture2D>("Animations/Player/player-jump");

            framecounts[CStates.IDLE] = 6;
            framecounts[CStates.RUNNING] = 6;
            framecounts[CStates.JUMPING] = 2;

            frameHeight = spritesheets[CStates.IDLE].Height;
            frameWidth = spritesheets[CStates.IDLE].Width / framecounts[CStates.IDLE];
        }

        public void Update(float delta)
        {
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, frameWidth, frameHeight);
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
                    position.X -= velocity;
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right)){
                ChangeState(CStates.RUNNING);
                frameInterval = 0.1f;
                previousKey = Keys.Right;

                if(position.X < 3072 - 100)
                    position.X += velocity;
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.Z) || Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                /// TODO: 
                /// 1. fix jumping + gravity
                /// 2. Fix animation
                /// 3. Fix mid-air movement
                
                ChangeState(CStates.JUMPING);
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                /// TODO: ducking
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

        public void OnCollision(string colliderType)
        {
            switch (colliderType)
            {
                case "Ground":
                    Debug.WriteLine("Standing on the ground");
                    break;
                case "Wall":
                    Debug.WriteLine("Walking against a wall");
                    break;
                default:
                    Debug.WriteLine($"Unkown collider type: {colliderType}");
                    break;
            }
        }
    }
}
