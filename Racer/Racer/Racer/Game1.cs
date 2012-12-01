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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Car Player;
        startMenu Menu;
        Wall brick; //brick2, brick3, brick4;
        Rectangle screenRectangle;
        Boolean start;
        GG gameOver;
        Boolean lost;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            screenRectangle = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            start = false;
            lost = false;
            Console.WriteLine("Game1() ran");
            Console.WriteLine(graphics.PreferredBackBufferHeight);
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

            // TODO: use this.Content to load your game content here
            Texture2D menuTexture = Content.Load<Texture2D>("startMenu");
            Texture2D ggTexture = Content.Load<Texture2D>("ggscreen");

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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            Random random = new Random();
            // TODO: Add your update logic here

            if (!start)
            {
                start = Menu.Update();
                //Console.WriteLine(start);
                Texture2D tempTexture = Content.Load<Texture2D>("ball");
                Player = new Car(tempTexture, screenRectangle);
                Texture2D tempWallTexture = Content.Load<Texture2D>("missle2");
                brick = new Wall(tempWallTexture, screenRectangle, random.Next(0, screenRectangle.Width));
           /*     brick2 = new Wall(tempWallTexture, screenRectangle, random.Next(0, screenRectangle.Width));
                brick3 = new Wall(tempWallTexture, screenRectangle, random.Next(0, screenRectangle.Width));
                brick4 = new Wall(tempWallTexture, screenRectangle, random.Next(0, screenRectangle.Width)); */
            }
            if (start)
            {
                Player.Update();
                brick.Update(random.Next(0, screenRectangle.Width), Player.getPosition());
                /*brick2.Update(random.Next(0, screenRectangle.Width));
                brick3.Update(random.Next(0, screenRectangle.Width));
                brick4.Update(random.Next(0, screenRectangle.Width));*/
                //draw gg
            }
       //     Collision(brick, Player);
            if(brick.checkCollision(Player.getRectangle()))
            {
                Console.WriteLine("touche");
                //gameOver.setLost(true);
                //lost = gameOver.getLost();
            }
            base.Update(gameTime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            
            Player.Draw(spriteBatch);
            brick.Draw(spriteBatch);
            /*(brick2.Draw(spriteBatch);
            brick3.Draw(spriteBatch);
            brick4.Draw(spriteBatch);*/
            Menu.Draw(spriteBatch);
            gameOver.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
