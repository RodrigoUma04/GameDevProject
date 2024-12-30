using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ProjectGame.Entities
{
    enum Direction { LEFT, RIGHT }
    enum CStates { IDLE, RUNNING, JUMPING, SHOOTING, SLIDE, RUNSHOOTING, DUCK, HURT }
    abstract class Entity : IEntity, ICollidable
    {
        // Player stats
        public int Velocity { get; set; }

        protected Vector2 position;
        public Vector2 Position { get => position; set => position = value; }
        public CStates CurrentState { get; set; }
        public Direction Direction { get; set; }
        public float VerticalVelocity { get; set; }
        public float Gravity { get; set; }
        public float JumpStrength { get; set; }
        public bool IsGrounded { get; set; }
        public Rectangle Bounds { get; set; }

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
            Direction = Direction.RIGHT;

            VerticalVelocity = 0;
            Gravity = 0.5f;
            IsGrounded = false;

            // Add position, velocity and jumpStrength for every entity apart
        }

        // making it abstract for the moment to be able to implement the needed animations per entity
        public abstract void LoadContent(ContentManager content);
        public virtual void Update(float delta)
        {
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, FrameWidth, FrameHeight);

            FrameTimer += delta;
            
            if(FrameTimer >= FrameInterval && IsGrounded)
            {
                CurrentFrame++;
                if(CurrentFrame >= Framecounts[CurrentState])
                {
                    CurrentFrame = 0;
                }

                FrameTimer -= FrameInterval;
            }

            if (!IsGrounded)
            {
                VerticalVelocity += Gravity;
                Position = new Vector2(Position.X, Position.Y + VerticalVelocity);

                if (VerticalVelocity < 0) // When going up
                {
                    CurrentFrame = 0;
                }
                else if (VerticalVelocity > 0) // When going down
                {
                    CurrentFrame = 1;
                }
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

        public void OnCollision(string colliderType)
        {
            switch (colliderType)
            {
                case "Ground":
                    if (VerticalVelocity > 0) // Only stop falling if moving downward
                    {
                        VerticalVelocity = 0;
                        IsGrounded = true;
                        Position = new Vector2(Position.X, 334);
                    }
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
