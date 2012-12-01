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
        Texture2D texture;
        Rectangle location;
        Color tint;

        public Wall(Texture2D texture, Rectangle location, Color tint)
        {
            this.texture = texture;
            this.location = location;
            this.tint = tint;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, location, tint);
        }
        
    }
}
