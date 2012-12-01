using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Racer
{
    class Wall
    {
        Vector2 position;
        float speed = 1f;
        Texture2D texture;
        Rectangle screenBounds;

        public Wall(Texture2D texture, Rectangle screenBounds)
        {
            this.texture = texture;
            this.screenBounds = screenBounds;
            StartPosition();
        }

        void StartPosition()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, screenBounds.Width);
            if (randomNumber > screenBounds.Width - texture.Width)
                position.X = screenBounds.Width - texture.Width;
            else
                position.X = randomNumber;
            position.Y = 50;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public Texture2D getTexture()
        {
            return texture;
        }

        public void Update()
        {
            position.Y += speed;
            if (position.Y > screenBounds.Height - 10)
            {
                StartPosition();
                if(speed < 16f) 
                    speed += 0.5f;
            }
        }

        public bool checkCollision(Rectangle Car)
        {
            Rectangle missleLocation = new Rectangle(
                (int)position.X,
                (int)position.Y,
                texture.Width,
                texture.Height);

            if (missleLocation.Intersects(Car))
                return true;

            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, position, Color.White); 480
            //spriteBatch.Draw(texture, position, Color.White);
           /* if (position.Y / 48 > 1)
                spriteBatch.Draw(texture, position, null, Color.White, 1, Vector2.Zero, position.Y / 48, SpriteEffects.None, 0);
            else */
                spriteBatch.Draw(texture, position, Color.White);
        }
        
    }
}
