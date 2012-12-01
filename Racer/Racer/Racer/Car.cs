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
        float multiplier;

        Texture2D texture;
        Rectangle screenBounds;

        KeyboardState keyboardState;

        int shields;

        public Car(Texture2D texture, Rectangle screenBounds)
        {
            this.texture = texture;
            this.screenBounds = screenBounds;
            this.shields = 1;
            this.multiplier = 1;

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

            motion *= this.multiplier;

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

        public void takeDamage()
        {
            this.shields--;
        }

        public int getShields()
        {
            return this.shields;
        }

        public void addShields()
        {
            this.shields++;
        }

        public float getMultiplier()
        {
            return this.multiplier;
        }

        public void buffMultiplier(float m)
        {
            this.multiplier *= m;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public Texture2D getTexture()
        {
            return texture;
        }

        public Rectangle getRectangle()
        {
            Rectangle ballLocation = new Rectangle(
                (int)position.X,
                (int)position.Y,
                texture.Width,
                texture.Height);
            return ballLocation;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
