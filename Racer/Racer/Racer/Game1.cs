using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Racer
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        Random random = new Random();
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Ship Player;
        startMenu Menu;
        Missile[] missiles;
        Rectangle screenRectangle;
        Boolean start;
        GG gameOver;
        Boolean lost;
        int score;

        powerUp[] powers;
        const int redPow = 0;
        const int greenPow = 1;
        const int bluePow = 2;
        
        SpriteFont font;
        string PlayerTime = "Time: ";
        TimeSpan startScreen;
        TimeSpan ts;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            screenRectangle = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            start = false;
            lost = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D menuTexture = Content.Load<Texture2D>("startMenu");
            Texture2D ggTexture = Content.Load<Texture2D>("ggscreen");
            font = Content.Load<SpriteFont>("myFont");

            Texture2D tempTexture = Content.Load<Texture2D>("ship");
            Player = new Ship(tempTexture, screenRectangle);
            Texture2D tempWallTexture = Content.Load<Texture2D>("missile");
            missiles = new Missile[10];
            for (int i = 0; i < missiles.Length; i++)
            {
                missiles[i] = new Missile(tempWallTexture, screenRectangle, random.Next(0, screenRectangle.Width));
            }
            
            Texture2D redTexture = Content.Load<Texture2D>("red");
            Texture2D greenTexture = Content.Load<Texture2D>("green");
            Texture2D blueTexture = Content.Load<Texture2D>("blue");
            powers = new powerUp[3];
            powers[redPow] = new powerUp(redTexture, screenRectangle, random.Next(0, screenRectangle.Width));
            powers[greenPow] = new powerUp(greenTexture, screenRectangle, random.Next(0, screenRectangle.Width));
            powers[bluePow] = new powerUp(blueTexture, screenRectangle, random.Next(0, screenRectangle.Width));

            score = 0;

            Menu = new startMenu(menuTexture);
            gameOver = new GG(ggTexture, lost);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (lost)
                return;
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (!start)
            {
                start = Menu.Update();
                startScreen = gameTime.TotalGameTime;
            }
            else
            {
                TimeSpan timePlaying = gameTime.TotalGameTime.Subtract(startScreen);
                Player.Update();
                if (ts.CompareTo(timePlaying) < 1)
                {
                    Player.disableGreen();
                }
                foreach (Missile rocket in missiles)
                {
                    rocket.Update(random.Next(0, screenRectangle.Width), Player.getPosition());
                }
                if (random.Next(0, 101) == 4)
                {
                    int i = random.Next(0, 3);
                    if (!powers[i].getStatus())
                        powers[i].setActive();
                }

                foreach (Missile rocket in missiles)
                {
                    if (rocket.checkCollision(Player.getRectangle()))
                    {
                        Player.takeDamage();
                        rocket.hitPlayer = true;
                    }
                }

                foreach (powerUp power in powers)
                {
                    if (power.getStatus())
                        power.Update();
                }

                if (Player.getShields() <= 0)
                {
                    gameOver.setLost(true);
                    lost = gameOver.getLost();
                    score += (int)timePlaying.TotalSeconds;
                }
                if (powers[redPow].checkCollision(Player.getRectangle()))
                {
                    Player.redBuff();
                    powers[redPow].hitPlayer = true;
                }
                if (powers[greenPow].checkCollision(Player.getRectangle()))
                {
                    Player.greenBuff();//what to set multiplier to
                    ts = TimeSpan.FromSeconds(2.0);
                    ts = ts.Add(timePlaying);
                    powers[greenPow].hitPlayer = true;
                }
                if (powers[bluePow].checkCollision(Player.getRectangle()))
                {
                    score += 100;
                    powers[bluePow].hitPlayer = true;
                }

                if (!lost && start)
                    PlayerTime = "Time: " + timePlaying.ToString();
                base.Update(gameTime);
            }
        }
        private void DrawText()
        {
            spriteBatch.DrawString(font, PlayerTime, new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(font, "Shield Left : " + Player.getShields() , new Vector2(700, 10), Color.White);
            spriteBatch.DrawString(font, "Score : " + score, new Vector2(300, 10), Color.White);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (!lost) 
                GraphicsDevice.Clear(Color.SkyBlue);
            else
                GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            
            Player.Draw(spriteBatch);
            foreach (Missile rocket in missiles)
            {
                rocket.Draw(spriteBatch);
            }
            foreach (powerUp power in powers)
            {
                power.Draw(spriteBatch);
            }
            Menu.Draw(spriteBatch);
            gameOver.Draw(spriteBatch);
            DrawText();
            spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
