using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Racer
{
    class highScore
    {
        Vector2 position;
        Texture2D texture;
        Boolean hs;
        string[] lines;

        public highScore(Texture2D texture){
            this.texture = texture;
            this.hs = false;
            this.position.Y = 0;
            this.position.X = 0;
            this.lines = System.IO.File.ReadAllLines(@"C:\Users\Antony\Documents\GitHub\GameJam\Racer\Racer\RacerContent\highScores.txt");
        }
        public void seths(Boolean b)
        {
            hs = b;
        }
        public Boolean geths()
        {
            return hs;
        }
        public void sethighScore(int score){
            //some
        }

        public int getHighScore()
        {
            return 1;
        }
        public Boolean isHighScore(int score)
        {
        }
        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Enter))
                hs = false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!hs)
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
