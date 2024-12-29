using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace ProjectGame.Entities
{
    enum Direction { LEFT, RIGHT}
    enum CStates { IDLE, RUNNING, JUMPING, SHOOTING, SLIDE, RUNSHOOTING, DUCK, HURT }
    abstract class Entity : IEntity
    {
        // Player stats
        public int Velocity { get; set; }

        protected Vector2 position;
        public Vector2 Position { get => position; set => position = value; }
        public CStates CurrentState { get; set; }
        public Direction Direction { get; set; }

        // Needed for animations
        public Dictionary<CStates, Texture2D> Spritesheets { get; set; }
        public Dictionary<CStates, int> Framecounts { get; set; }
        public float FrameTimer { get; set; }
        public float FrameInterval { get; set; }
        public int FrameWidth { get; set; }
        public int FrameHeight { get; set; }
        public int CurrentFrame { get; set; }

        public Entity()
        {
            CurrentState = CStates.IDLE;
            Spritesheets = new Dictionary<CStates, Texture2D>();
            Framecounts = new Dictionary<CStates, int>();

            FrameTimer = 0f;
            FrameInterval = 0.2f;
            CurrentFrame = 0;

            // Add position and velocity for every entity apart
        }

        // making it abstract for the moment to be able to implement the needed animations per entity
        public abstract void LoadContent(ContentManager content);
        public virtual void Update(float delta)
        {
            FrameTimer += delta;

            if(FrameTimer >= FrameInterval)
            {
                CurrentFrame++;
                if(CurrentFrame >= Framecounts[CurrentState])
                {
                    CurrentFrame = 0;
                }

                FrameTimer -= FrameInterval;
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRect = new Rectangle(FrameWidth * CurrentFrame, 0, FrameWidth, FrameHeight);

            if(Direction == Direction.LEFT)
            {
                spriteBatch.Draw(Spritesheets[CurrentState], Position, sourceRect, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0);
            }
            else
            {
                spriteBatch.Draw(Spritesheets[CurrentState], Position, sourceRect, Color.White);
            }
        } 
        public virtual void ChangeState(CStates newState)
        {
            if(CurrentState != newState)
            {
                CurrentState = newState;
                CurrentFrame = 0;
                FrameTimer = 0f;
                FrameInterval = 0.2f;
            }
        }

        public virtual void HandleMovement()
        {
            // add AI movement in here I guess?
        }
    }
}
