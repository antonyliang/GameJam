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
        float speed = 3f;
        Texture2D texture;
        Rectangle screenBounds;
        double rotation = Math.PI;

        public Wall(Texture2D texture, Rectangle screenBounds, int random)
        {
            this.texture = texture;
            this.screenBounds = screenBounds;
            StartPosition(random);
        }

        void StartPosition(int randomNumber)
        {
            Console.WriteLine(randomNumber);
            rotation = Math.PI;
            if (randomNumber > screenBounds.Width - texture.Width)
                position.X = screenBounds.Width - texture.Width;
            else
                position.X = randomNumber;
            position.Y = 0;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public Texture2D getTexture()
        {
            return texture;
        }

        private int facePlayer(Vector2 playerPosition)
        {
            double angle;
            if(playerPosition.X < position.X)
                angle = Math.Atan((double)((position.Y - playerPosition.Y) / (position.X - playerPosition.X)));
            else
                angle = Math.Atan((double)((position.Y - playerPosition.Y) / (playerPosition.X - position.X)));

            if ( angle < rotation)
                return 1;
            if (angle > rotation)
                return 1;
            return 0;
        }

        public void Update(int random, Vector2 playerPosition)
        {   
            position.Y += speed;

            if (facePlayer(playerPosition) == 1 && (playerPosition.X < position.X))
                rotation += 0.005 * playerPosition.Y / 48;
            else
                rotation -= 0.005 * playerPosition.Y / 48;
            if (playerPosition.X < position.X)
            {
                //rotation -= (0.01f * speed);
                position.X -= speed;
            }
            else
            {
                //rotation += 0.01f * speed;
                position.X += speed;
            }

            if (position.Y > screenBounds.Height - 10)
            {
                StartPosition(random);
                if(speed < 8f) 
                    speed += 1f;
            }
        }

        public bool checkCollision(Rectangle Car)
        {
            int actualWidth = (int)(texture.Width * position.Y / 96);
            Rectangle missleLocation;
            if (rotation > 3.14)
            {
                missleLocation = new Rectangle(
                    (int)(position.X - actualWidth + 100),
                    (int)(position.Y - actualWidth),
                    (int)(actualWidth + 1),
                    (int)(actualWidth + 1));
            }
            else
            {
                missleLocation = new Rectangle(
                    (int)(position.X - actualWidth),
                    (int)(position.Y - actualWidth),
                    (int)(actualWidth + 1),
                    (int)(actualWidth + 1));
            }
            if (missleLocation.Intersects(Car))
                return true;

            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, position, Color.White); 480
            if (position.Y / 96 < 5)
                spriteBatch.Draw(texture, position, null, Color.White, (float)rotation, Vector2.Zero, position.Y / 96, SpriteEffects.None, 0);
            else
                spriteBatch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }
        
    }
}
