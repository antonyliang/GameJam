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
        //string directory = @"C:\Users\Marist User\Documents\GitHub\GameJam\Racer\Racer\RacerContent\highScores.txt";
        string directory = @"C:\Users\Antony\Documents\GitHub\GameJam\Racer\Racer\RacerContent\highScores.txt";
        
        public highScore(Texture2D texture){
            this.texture = texture;
            this.hs = false;
            this.position.Y = 0;
            this.position.X = 0;
            this.lines = System.IO.File.ReadAllLines(directory);
        }
        public void seths(Boolean b)
        {
            hs = b;
        }
        public Boolean geths()
        {
            return hs;
        }
        public string[] getHighScore()
        {
            return this.lines;
        }
        public void isHighScore(int score)
        {
            int[] hsArray = new int[this.lines.Length];
            int temp = score;
            //copy lines into hsArray (string[] to int[])
            for (int i = 0; i < this.lines.Length; i++)
            {
                int.TryParse(this.lines[i], out hsArray[i]);
            }
            //see if current score is a high score and if it is add it to hsArray
            for (int i = 0; i < this.lines.Length; i++)
            {
                if (temp > hsArray[i])
                {
                    int placeholder = hsArray[i];
                    hsArray[i] = temp;
                    temp = placeholder;
                }
            }
            //convert hsArray from int[] to string[] for writing
            string[] stringHSArray = new string[this.lines.Length];
            for (int i = 0; i < stringHSArray.Length; i++)
            {
                stringHSArray[i] = hsArray[i].ToString();
            }

            System.IO.File.WriteAllLines(directory, stringHSArray);
        }
        public void clearHS()
        {
            for (int i = 0; i < this.lines.Length; i++)
            {
                this.lines[i] = "0";
            }
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
