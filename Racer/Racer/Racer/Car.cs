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
        Texture2D texture;
        Rectangle screenBounds;

        public Car(Texture2D texture, Rectangle screenBounds)
        {
            this.texture = texture;
            this.screenBounds = screenBounds;

            StartPosition();
        }

        void StartPosition()
        {
            position.X = (screenBounds.Width - texture.Width) / 2;
            position.Y = (screenBounds.Height - texture.Height) / 2;
        }

        public void Update() 
        { 

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
