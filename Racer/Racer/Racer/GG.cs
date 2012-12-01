using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Racer
{
    class GG
    {
        Texture2D texture;
        Vector2 position;

        Boolean lost;

        public GG(Texture2D texture, Boolean lost)
        {
            this.texture = texture;
            this.lost = false;
            this.position.X = 0;
            this.position.Y = 40;
        }

        public void setLost(Boolean lost)
        {
            this.lost = lost;
        }
        public Boolean getLost()
        {
            return this.lost;
        }

        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Enter))
                lost = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!lost)
            {
                spriteBatch.Draw(texture, position, Color.Transparent);
            }
            else
            {
                spriteBatch.Draw(texture, position, Color.White);
            }
        }


    }
}
