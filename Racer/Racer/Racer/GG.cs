using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Racer
{
    class GG
    {
        Vector2 position;
        Texture2D texture;

        Boolean lost;

        public GG(Texture2D texture, Boolean lost)
        {
            this.texture = texture;
            this.lost = false;
        }

        public void setLost(Boolean lost)
        {
            this.lost = lost;
        }
        public Boolean getLost()
        {
            return this.lost;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!lost)
            {
                spriteBatch.Draw(texture, position, Color.Transparent);
            }
            else
            {
                spriteBatch.Draw(texture, Vector2.Zero, Color.White);
            }
        }


    }
}
