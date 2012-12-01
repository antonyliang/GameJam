using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Racer
{
    class Missile
    {
        Vector2 position;
        float speed = 3f;
        Texture2D texture;
        Rectangle screenBounds;
        public Boolean hitPlayer;
        double rotation = 0;

        public Missile(Texture2D texture, Rectangle screenBounds, int random)
        {
            this.texture = texture;
            this.screenBounds = screenBounds;
            this.hitPlayer = false;
            StartPosition(random);
        }

        void StartPosition(int randomNumber)
        {
            rotation = 0;
            if (randomNumber > screenBounds.Width - texture.Width)
                position.X = screenBounds.Width - texture.Width;
            else
                position.X = randomNumber;
            position.Y = 0 - randomNumber;
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

            if (angle < rotation - 0.005 * playerPosition.Y / 192)
                return 1;
            if (angle > rotation + 0.005 * playerPosition.Y / 192)
                return 1;
            return 0;
        }

        public void Update(int random, Vector2 playerPosition)
        {   
            position.Y += speed;
            if (facePlayer(playerPosition) == 0 && position.Y < screenBounds.Height - 100 )
            { }
            else if (position.Y < (screenBounds.Height / 2) - 100)
            {
                if (facePlayer(playerPosition) == 1 && (playerPosition.X < position.X))
                    rotation += 0.005 * playerPosition.Y / 192;
                else
                    rotation -= 0.005 * playerPosition.Y / 192;
            }
            if (position.Y < (screenBounds.Height / 2) - 100)
            {
                if (playerPosition.X < position.X)
                {
                    position.X -= speed;
                }
                else
                {
                    position.X += speed;
                }
            }
            if (position.Y > screenBounds.Height)
            {
                StartPosition(random);
                if (speed < 6f)
                    speed += 1f;
            }
        }

        public bool checkCollision(Rectangle Car)
        {
            if (position.Y > (screenBounds.Height / 2) + 170)
                return false;
            int actualWidth = (int)(texture.Width * position.Y / 384);
            Rectangle missleLocation;
            if (rotation > 0)
            {
                missleLocation = new Rectangle(
                    (int)(position.X - actualWidth / ((double)position.Y / 192) + 40),
                    (int)(position.Y - actualWidth / ((double)position.Y / 192)),
                    (int)(actualWidth),
                    (int)(actualWidth));
            }
            else
            {
                missleLocation = new Rectangle(
                    (int)(position.X + actualWidth / ((double)position.Y / 192) - 40),
                    (int)(position.Y - actualWidth / ((double)position.Y / 192)),
                    (int)(actualWidth),
                    (int)(actualWidth));
            }

            
            if (missleLocation.Intersects(Car) && (this.hitPlayer == false) )
                return true;

            if (this.position.Y == 0)
                this.hitPlayer = false;

            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (position.Y < (screenBounds.Height / 2) - 100)
            {
                spriteBatch.Draw(texture, position, null, Color.White, (float)rotation, Vector2.Zero, position.Y / 192, SpriteEffects.None, 0);
            }
            else
                spriteBatch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, position.Y / 192, SpriteEffects.None, 0);
            
        }
        
    }
}
