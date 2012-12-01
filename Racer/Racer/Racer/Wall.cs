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
            position.Y = 20;
        }

        public void Update()
        {
            position.Y += speed;
            if (position.Y > screenBounds.Height)
            {
                StartPosition();
                if(speed < 16f) 
                    speed += 0.5f;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
        
    }
}
