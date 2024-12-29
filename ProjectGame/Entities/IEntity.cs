using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace ProjectGame.Entities
{
    interface IEntity
    {
        public int Velocity { get; set; }
        public Vector2 Position { get; set; }
        CStates CurrentState { get; set; }
        public Dictionary<CStates, Texture2D> Spritesheets { get; set; }
        public Dictionary<CStates, int> Framecounts { get; set; }
        public float FrameTimer { get; set; }
        public float FrameInterval { get; set; }
        public int FrameWidth { get; set; }
        public int FrameHeight { get; set; }
        public int CurrentFrame { get; set; }
        void LoadContent(ContentManager content);
        void Update(float delta);
        void Draw(SpriteBatch spriteBatch);
        void ChangeState(CStates newState);
        // void HandleMovement(); doesn't work because need to be public, but I don't want that
    }
}
