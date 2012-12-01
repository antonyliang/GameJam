using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Racer
{
    class Ship
    {
        Vector2 position;
        Vector2 motion;
        float multiplier;
        TimeSpan buffEnd;

        Texture2D texture;
        Rectangle screenBounds;

        KeyboardState keyboardState;

        int shields;

        public Ship(Texture2D texture, Rectangle screenBounds)
        {
            this.texture = texture;
            this.screenBounds = screenBounds;
            this.shields = 10;
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
                motion.X = -10f;
            if (keyboardState.IsKeyDown(Keys.Right))
                motion.X = 10f;

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

        public void redBuff()
        {
            this.shields += 3;
        }

        public void disableGreen()
        {
            this.multiplier = 1;
        }

        public void greenBuff()
        {
            this.multiplier *= 2;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public Texture2D getTexture()
        {
            return texture;
        }

        public void setBuffEnd(TimeSpan ts)
        {
            this.buffEnd = ts;
        }
        public TimeSpan getBuffEnd()
        {
            return this.buffEnd;
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
