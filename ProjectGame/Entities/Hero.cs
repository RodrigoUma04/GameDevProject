using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace ProjectGame.Entities
{
    class Hero : Entity, ICollidable
    {
        private static Hero uniqueInstance = new Hero();
        public Rectangle Bounds { get; set; }
        public Hero() {
            Position = new Vector2(32, 334);
            Velocity = 5;
            JumpStrength = -12f;
        }
        public static Hero GetHero()
        {
            return uniqueInstance;
        }
        public override void LoadContent(ContentManager content)
        {
            Spritesheets[CStates.IDLE] = content.Load<Texture2D>("Animations/Player/player-idle");
            Spritesheets[CStates.RUNNING] = content.Load<Texture2D>("Animations/Player/player-run");
            Spritesheets[CStates.JUMPING] = content.Load<Texture2D>("Animations/Player/player-jump");

            Framecounts[CStates.IDLE] = 6;
            Framecounts[CStates.RUNNING] = 6;
            Framecounts[CStates.JUMPING] = 2;

            FrameHeight = Spritesheets[CStates.IDLE].Height;
            FrameWidth = Spritesheets[CStates.IDLE].Width / Framecounts[CStates.IDLE];
        }
        public override void Update(float delta)
        {
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, FrameWidth, FrameHeight);
            HandleMovement();

            base.Update(delta);
        }

        public override void HandleMovement()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Q) || Keyboard.GetState().IsKeyDown(Keys.Left)) {
                if (IsGrounded)
                {
                    ChangeState(CStates.RUNNING);
                    FrameInterval = 0.1f;
                }
                Direction = Direction.LEFT;

                if(position.X > 0)
                    position.X -= Velocity;
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right)){
                if (IsGrounded)
                {
                    ChangeState(CStates.RUNNING);
                    FrameInterval = 0.1f;
                }
                Direction = Direction.RIGHT;

                if(position.X < 3072 - 100)
                    position.X += Velocity;
            }
            else if(IsGrounded && (Keyboard.GetState().IsKeyDown(Keys.Z) || Keyboard.GetState().IsKeyDown(Keys.Up)))
            {
                ChangeState(CStates.JUMPING);
                VerticalVelocity = JumpStrength;
                IsGrounded = false;
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                /// TODO: ducking
            }
            else
            {
                if(IsGrounded)
                    ChangeState(CStates.IDLE);
            }

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
