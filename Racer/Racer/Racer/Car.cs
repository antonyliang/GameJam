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
                motion.X = -8f;
            if (keyboardState.IsKeyDown(Keys.Right))
                motion.X = 8f;

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

        public Vector2 getPosition()
        {
            return position;
        }

        public Texture2D getTexture()
        {
            return texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
