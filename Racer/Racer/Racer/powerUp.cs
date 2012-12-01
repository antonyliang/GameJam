using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Racer
{
    class powerUp : Wall //subclassing Wall
    {
        
        Texture2D texture;
        Rectangle screenBounds;
        float speed = 1f;

        //public powerUp(Texture2D texture, Rectangle screenBounds) : base(Texture2D texture, Rectangle screenBounds)
        public powerUp(Texture2D texture, Rectangle screenBounds, int random)
            : base(texture, screenBounds, random)
        {
            
            this.texture = texture;
            this.screenBounds = screenBounds;
        }

        /*public void Update()
        {
            position.Y += speed;
            if (position.Y > screenBounds.Height - 10)
            {
                StartPosition(random);
                if (speed < 16f)
                    speed += 0.5f;
            }
        }*/
    }
}