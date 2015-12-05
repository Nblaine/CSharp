/*Getting the sound to work in this project:
 * 1.  Include a reference to the MonoGame Libraries/Binaries/Content Processors using nuGet.
 *   a. Right click the project and select Manage NuGet Packages.
 *   b. Search for MonoGame
 * 2. Include the OpenAL library
 *   a. Right click the project and select Manage NuGet Packages
 *   b. Search for and install OpenAL (including the OpenTK)
 * 3. A content project had to be created in Visual Studio 2010
 *   a. Create an XNA Game Project
 *   b. Include all of the content items (graphics, fonts, sounds, etc)
 *   c. Build the project
 *   d. In the MonoGame project, right click the appropriate content folder, add existing
 *   e. Navigate to the XNA Project created in item a and get the compiled files (i.e. .xnb files)
 *   f. Add them to the MonoGame project
 *   g. Build the MonoGame project
*/
#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Audio;
#endregion

namespace Balloons
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D blueCircle;
        Texture2D greenCircle;
        Texture2D redCircle;

        BalloonManager balloonManager;
        BonusItemManager bonusItemManager;
        private const int PREFERRED_WIDTH = 800;
        private const int PREFERRED_HEIGHT = 600;
        List<Circle> lstCircles = new List<Circle>();

        private int m_iCountPerQuadrant = 3;
        private int m_iTotalCircleCount = 0;


        private SpriteFont arial;

        Color clearColor = Color.White;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            this.graphics.PreferredBackBufferHeight = PREFERRED_HEIGHT;
            this.graphics.PreferredBackBufferWidth = PREFERRED_WIDTH;
            this.graphics.ApplyChanges();
            this.IsMouseVisible = true;
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
            balloonManager = new BalloonManager(this.Content);
            bonusItemManager = new BonusItemManager(this.Content, balloonManager);

            blueCircle = Content.Load<Texture2D>("Misc/blue_circle");
            greenCircle = Content.Load<Texture2D>("Misc/green_circle");
            redCircle = Content.Load<Texture2D>("Misc/red_circle");

            m_iTotalCircleCount = m_iCountPerQuadrant * 4;
            arial = Content.Load<SpriteFont>("Fonts/arial");


            for (int i = 0; i < 4; i++)
            {

                for (int j = 0; j < 3; j++)
                {
                    Circle c = new Circle();

                    Random r = new Random((DateTime.Now.Hour * DateTime.Now.Minute * DateTime.Now.Second * DateTime.Now.Millisecond) * ((j + 1) * 1000));

                    Random randX = new Random((DateTime.Now.Hour * DateTime.Now.Minute * DateTime.Now.Second * DateTime.Now.Millisecond) * ((j + 1) * 2000));
                    Random randY = new Random((DateTime.Now.Hour * DateTime.Now.Minute * DateTime.Now.Second * DateTime.Now.Millisecond) * ((j + 1) * 3000));


                    int iRoll = r.Next(1, 4);

                    switch (iRoll)
                    {
                        case 1:
                            c.circleTex = greenCircle;
                            break;

                        case 2:
                            c.circleTex = redCircle;
                            break;

                        case 3:
                            c.circleTex = blueCircle;
                            break;
                    }

                    switch (i + 1)
                    {
                        case 1:
                            c.Location = new Vector2(randX.Next(0, (401 - c.circleTex.Width)), randY.Next(0, (401 - c.circleTex.Height)));
                            break;

                        case 2:
                            c.Location = new Vector2(randX.Next(400, (801 - c.circleTex.Width)), randY.Next(0, (401 - c.circleTex.Height)));
                            break;

                        case 3:
                            c.Location = new Vector2(randX.Next(0, (401 - c.circleTex.Width)), randY.Next(400, (801 - c.circleTex.Height)));
                            break;

                        case 4:
                            c.Location = new Vector2(randX.Next(400, (801 - c.circleTex.Width)), randY.Next(400, (801 - c.circleTex.Height)));
                            break;
                    }

                    lstCircles.Add(c);
                }
            }
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (!balloonManager.IsGameOver)
            {
                balloonManager.Update(gameTime);

                if (!balloonManager.IsPaused)
                    bonusItemManager.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(clearColor);

            // TODO: Add your drawing code here

            spriteBatch.Begin();


            if (balloonManager.IsPaused && !balloonManager.IsGameOver)
                spriteBatch.DrawString(arial, "GAME PAUSED", new Vector2(375, 400), Color.Red);

            foreach (Circle c in lstCircles)
                spriteBatch.Draw(c.circleTex, c.Location, Color.White);

            spriteBatch.DrawString(arial, "Score: " + balloonManager.TotalScore.ToString(), new Vector2(25, 0), Color.Blue);
            spriteBatch.DrawString(arial, "Time: " + string.Format("{0:0.0}", balloonManager.CurrentTime), new Vector2(225, 0), Color.Blue);
            spriteBatch.DrawString(arial, "Spawned: " + balloonManager.TotalSpawned, new Vector2(395, 0), Color.Blue);
            spriteBatch.DrawString(arial, "Popped: " + balloonManager.TotalPopped, new Vector2(600, 0), Color.Blue);
            spriteBatch.DrawString(arial, "Round: " + balloonManager.CurrentRound, new Vector2(25, 760), Color.Blue);

            if (!balloonManager.IsGameOver)
            {
                bonusItemManager.Draw(spriteBatch);
                balloonManager.Draw(spriteBatch);
            }
            else
                spriteBatch.DrawString(arial, "GAME OVER", new Vector2(250, 250), Color.Red);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }

    internal class Circle
    {
        public Texture2D circleTex;
        public Vector2 Location;
    }
}
