using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace ProjectGame.Core
{
    class Camera
    {
        private Vector2 _position;
        private Vector2 _worldBounds;
        private int _deadzone;

        public Camera(Vector2 worldBounds)
        {
            _worldBounds = worldBounds;
            _position = Vector2.Zero;
            _deadzone = 100;
        }

        public void Update(Vector2 playerPosition)
        {
            // to calculate the center of the camera dynamically
            float cameraCenterX = _position.X + (Game1.ScreenWidth / 2);

            // to calculate where the left and right side of the deadzone is
            // -100, because of some weird centering bug --> deazone starting at center of the screen and aligning with center of the deadzone
            float deadzoneLeft = (cameraCenterX - _deadzone / 2) - 100;
            float deadzoneRight = (cameraCenterX + _deadzone / 2) - 100;

            // Debugging information to check if camera is behaving correctly
            Debug.WriteLine($"Deadzone Left: {deadzoneLeft}, Deadzone Right: {deadzoneRight}");
            Debug.WriteLine($"Player Position: {playerPosition.X}, Camera Position: {_position.X}");

            if (playerPosition.X < deadzoneLeft)
            {
                Debug.WriteLine("Left of the deadzone.");
                _position.X -= deadzoneLeft - playerPosition.X;
            }
            else if (playerPosition.X > deadzoneRight)
            {
                Debug.WriteLine("Right of the deadzone.");
                _position.X += playerPosition.X - deadzoneRight;
            }
            else
            {
                Debug.WriteLine("In the deadzone.");
            }

            // sets the limit of where the camera can go to
            _position.X = MathHelper.Clamp(_position.X, 0, _worldBounds.X - Game1.ScreenWidth);
        }

        public Matrix GetViewMatrix()
        {
            return Matrix.CreateTranslation(new Vector3(-_position.X, -_position.Y, 0));
        }
    }
}
