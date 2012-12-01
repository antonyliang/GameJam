using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Racer
{
    class startMenu
    {
        Texture2D texture;

        Boolean start;

        public startMenu(Texture2D texture)
        {
            this.texture = texture;
            this.start = false;
        }

        public Boolean Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Enter))
                start = true;
            return start;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!start)
            {
                spriteBatch.Draw(texture, Vector2.Zero, Color.White);
            }
        }
    }
}
