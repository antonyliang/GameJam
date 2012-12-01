using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Racer
{
    class powerUp
    {

        Vector2 position;
        float speed = 9f;
        Texture2D texture;
        Rectangle screenBounds;
        public Boolean hitPlayer;
        Boolean active;

        //public powerUp(Texture2D texture, Rectangle screenBounds) : base(Texture2D texture, Rectangle screenBounds)
        public powerUp(Texture2D texture, Rectangle screenBounds, int random)
            {
            this.texture = texture;
            this.screenBounds = screenBounds;
            this.hitPlayer = false;
            this.active = false;
            StartPosition(random);
        }

        void StartPosition(int randomNumber)
        {
            if (randomNumber > screenBounds.Width - texture.Width)
                position.X = screenBounds.Width - texture.Width;
            else
                position.X = randomNumber;
            position.Y = 0 - randomNumber;
        }

        public void Update(int randomNumber)
        {
            position.Y += speed;

            if (position.Y > screenBounds.Height)
            {
                this.active = false;
                StartPosition(randomNumber);
            }
        }

        public bool getStatus()
        {
            return this.active;
        }

        public void setActive()
        {
            this.active = true;
            this.hitPlayer = false;
        }

        public bool checkCollision(Rectangle Car)
        {
            Rectangle missleLocation = new Rectangle(
                (int)position.X,
                (int)position.Y,
                texture.Width,
                texture.Height);

            if (missleLocation.Intersects(Car) && (this.hitPlayer == false))
            {
                this.active = false;
                position.Y = 0;
                hitPlayer = true;
                return true;
            }

            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(active)
                spriteBatch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, position.Y / 192, SpriteEffects.None, 0);
        }
    }
}