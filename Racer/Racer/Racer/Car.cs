using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Racer
{
    class Car
    {
        Vector2 position;
        Vector2 motion;
        float paddleSpeed = 8f;

        Texture2D texture;
        Rectangle screenBounds;

        KeyboardState keyboardState;

        public Car(Texture2D texture, Rectangle screenBounds)
        {
            this.texture = texture;
            this.screenBounds = screenBounds;

            StartPosition();
        }

        void StartPosition()
        {
            position.X = (screenBounds.Width - texture.Width) / 2;
            position.Y = ((screenBounds.Height - texture.Height) / 2) + 150;
        }

        public void Update() 
        {
            motion = Vector2.Zero;

            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Left))
                motion.X = -1;
            if (keyboardState.IsKeyDown(Keys.Right))
                motion.X = 1;

            motion.X *= paddleSpeed;
            position += motion;
            LockCar();            
        
        }

        private void LockCar()
        {
            if (position.X < 0)
                position.X = 0;
            if (position.X + texture.Width > screenBounds.Width)
                position.X = screenBounds.Width - texture.Width;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
