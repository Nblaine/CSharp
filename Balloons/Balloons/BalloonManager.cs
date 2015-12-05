using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
//using Microsoft.Xna.Framework.Media;

namespace Balloons
{
    public class BalloonManager
    {
        public enum BalloonColor { Green, Blue, Red, Black };

        private const int PREFERRED_WIDTH = 800;
        private const int PREFERRED_HEIGHT = 600;

        private ContentManager balloonManagerContent;
        List<Balloon> lstBalloons = new List<Balloon>();
        public bool IsGameOver = false;
        private int m_iTotalScore = 0;

        private float m_fMinSpawnDelay = 1.00f;
        private float m_fSpawnDelay = 1.50f;
        private float m_fCurrSpawnTick = 0.0f;

        private float m_fRoundPerRound = 60.0f;
        private float m_fCurrentRoundTime = 60.0f;

        private int m_iTotalSpawnedBalloons = 0;
        private int m_iTotalPoppedBalloons = 0;

        private int m_iRound = 1;

        private bool m_bIsPaused = false;
        private bool m_bPausedKeyDown = false;

        private Texture2D[] balloonTextures = new Texture2D[4];

        SoundEffect popSound;
        SoundEffectInstance gemSoundInstance;

        public int TotalScore
        {
            get { return m_iTotalScore; }
            set { m_iTotalScore = value; }
        }

        public float CurrentTime
        {
            get { return m_fCurrentRoundTime; }
        }

        public int TotalSpawned
        {
            get { return m_iTotalSpawnedBalloons; }
        }

        public int TotalPopped
        {
            get { return m_iTotalPoppedBalloons; }
        }

        public int CurrentRound
        {
            get { return m_iRound; }
        }

        public bool IsPaused
        {
            get { return m_bIsPaused; }
        }

        public BalloonManager(ContentManager content)
        {
            balloonManagerContent = content;

            balloonTextures[(int)BalloonColor.Green] = balloonManagerContent.Load<Texture2D>("Balloons/green_balloon");
            balloonTextures[(int)BalloonColor.Blue] = balloonManagerContent.Load<Texture2D>("Balloons/blue_balloon");
            balloonTextures[(int)BalloonColor.Red] = balloonManagerContent.Load<Texture2D>("Balloons/red_balloon");
            balloonTextures[(int)BalloonColor.Black] = balloonManagerContent.Load<Texture2D>("Balloons/black_balloon");
            popSound = balloonManagerContent.Load<SoundEffect>("Sounds/pop1");
            gemSoundInstance = popSound.CreateInstance();
        }

        public void HandleMouseInput(MouseState ms)
        {
            Point mousePoint = new Point(ms.X, ms.Y);

            if (ms.LeftButton == ButtonState.Pressed)
            {
                for (int i = 0; i < lstBalloons.Count; i++)
                {
                    if (lstBalloons[i].ActiveArea.Contains(mousePoint))
                    {
                        gemSoundInstance.Volume = 0.5f;
                        gemSoundInstance.Play();
                        m_iTotalScore += lstBalloons[i].PointValue;
                        lstBalloons[i].IsActive = false;
                        m_iTotalPoppedBalloons++;
                    }
                }
            }
        }

        public void HandleKeyboardInput(KeyboardState ks)
        {
            bool pauseKeyDownThisFrame = ks.IsKeyDown(Keys.P);

            if (!m_bPausedKeyDown && pauseKeyDownThisFrame)
                if(!m_bIsPaused)
                    m_bIsPaused = true;
            else
                m_bIsPaused = false;

            m_bPausedKeyDown = pauseKeyDownThisFrame;
        }

        private void SpawnBalloon()
        {
            Random rand = new Random(DateTime.Now.Hour * DateTime.Now.Minute * DateTime.Now.Second * DateTime.Now.Millisecond);
            double dPercent = rand.NextDouble() * 100;

            Balloon balloon = new Balloon();

            if (dPercent <= 10)
                balloon.BalloonColor = BalloonColor.Black;
            else if (dPercent < 20)
                balloon.BalloonColor = BalloonColor.Red;
            else if (dPercent < 35)
                balloon.BalloonColor = BalloonColor.Blue;
            else
                balloon.BalloonColor = BalloonColor.Green;

            Random randX = new Random((DateTime.Now.Hour * DateTime.Now.Minute * DateTime.Now.Second * DateTime.Now.Millisecond) * 100);

            int iRandXLoc = randX.Next(0, (PREFERRED_WIDTH - balloonTextures[0].Width) + 1);

            balloon.BalloonLocation = new Vector2(iRandXLoc, PREFERRED_HEIGHT);
            balloon.BalloonTexture = balloonTextures[(int)balloon.BalloonColor];
            balloon.ActiveArea = new Rectangle(iRandXLoc, 800, 71, 90);
            lstBalloons.Add(balloon);

            m_iTotalSpawnedBalloons++;
        }

        public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            HandleKeyboardInput(Keyboard.GetState());
            if (!m_bIsPaused)
            {
                m_fCurrentRoundTime -= elapsed;

                if (m_fCurrentRoundTime <= 0.00f)
                {
                    if (m_iTotalSpawnedBalloons > 0)
                    {
                        if (m_iTotalSpawnedBalloons == m_iTotalPoppedBalloons)
                        {
                            m_fCurrentRoundTime = 60.0f;
                            m_iRound++;

                            m_fSpawnDelay -= 0.125f;

                            m_iTotalPoppedBalloons = m_iTotalSpawnedBalloons = 0;

                            if (m_fSpawnDelay < m_fMinSpawnDelay)
                                m_fSpawnDelay = m_fMinSpawnDelay;
                        }
                        else
                            IsGameOver = true;
                    }//if(m_iTotalSpawnedBalloons == m_iTotalPoppedBalloons)
                }


                if (m_fCurrentRoundTime > 0.00f)
                {
                    m_fCurrSpawnTick += elapsed;

                    if (m_fCurrSpawnTick >= m_fSpawnDelay)
                    {
                        m_fCurrSpawnTick = 0.0f;
                        SpawnBalloon();
                    }

                    HandleMouseInput(Mouse.GetState());

                    foreach (Balloon balloon in lstBalloons)
                    {
                        balloon.BalloonVelocity.Normalize();
                        //balloon.BalloonVelocity *= balloon.FloatSpeed;

                        balloon.BalloonLocation += (balloon.BalloonVelocity * elapsed);
                        balloon.UpdateActiveArea((int)balloon.BalloonLocation.X, (int)balloon.BalloonLocation.Y, 71, 90);

                        if (balloon.BalloonLocation.Y > 800)
                            balloon.IsActive = false;
                    }

                    for (int i = 0; i < lstBalloons.Count; i++)
                        if (!lstBalloons[i].IsActive)
                            lstBalloons.RemoveAt(i);
                }
                else
                    for (int i = 0; i < lstBalloons.Count; i++)
                        lstBalloons.RemoveAt(i);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int i = 0;
            foreach (Balloon balloon in lstBalloons)
                spriteBatch.Draw(balloon.BalloonTexture, balloon.BalloonLocation, Color.White);
        }
    }
}
