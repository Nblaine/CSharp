using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Balloons
{
    public class Balloon
    {
        private int m_iPointValue = 0;
        private BalloonManager.BalloonColor balloonColor = BalloonManager.BalloonColor.Green;
        private Vector2 balloonLocation = Vector2.Zero;
        private Vector2 balloonVelocity = new Vector2(0, -30);
        //private float m_fBalloonFloatSpeed = 2.0f;
        private Rectangle balloonActiveArea;
        private Texture2D balloonTexture;
        private bool m_bIsActive = true;

        public int PointValue
        {
            get { return m_iPointValue; }
        }

        public Vector2 BalloonLocation
        {
            get { return balloonLocation; }
            set { balloonLocation = value; }
        }

        public Vector2 BalloonVelocity
        {
            get { return balloonVelocity; }
            set { balloonVelocity = value; }
        }

        //public float FloatSpeed
        //{
        //    get { return m_fBalloonFloatSpeed; }
        //    set { m_fBalloonFloatSpeed = value; }
        //}

        public Rectangle ActiveArea
        {
            get { return balloonActiveArea; }
            set { balloonActiveArea = value; }
        }

        public Texture2D BalloonTexture
        {
            get { return balloonTexture; }
            set { balloonTexture = value; }
        }

        public BalloonManager.BalloonColor BalloonColor
        {
            get { return balloonColor; }
            set { balloonColor = value; SetPointValue(); }
        }

        public void UpdateActiveArea(int x, int y, int width, int height)
        {
            balloonActiveArea.X = x;
            balloonActiveArea.Y = y;
            balloonActiveArea.Width = width;
            balloonActiveArea.Height = height;
        }

        public bool IsActive
        {
            get { return m_bIsActive; }
            set { m_bIsActive = value; }
        }

        private void SetPointValue()
        {
            switch (this.balloonColor)
            {
                case BalloonManager.BalloonColor.Green:
                    m_iPointValue = 1;
                    break;

                case BalloonManager.BalloonColor.Blue:
                    m_iPointValue = 3;
                    break;

                case BalloonManager.BalloonColor.Red:
                    m_iPointValue = 5;
                    break;

                case BalloonManager.BalloonColor.Black:
                    m_iPointValue = 10;
                    break;

                default:
                    m_iPointValue = 1;
                    break;
            }//switch(color)
        }

        public Balloon() { SetPointValue(); }

        public Balloon(BalloonManager.BalloonColor color, Texture2D balloonTex)
        {
            balloonColor = color;
            balloonTexture = balloonTex;
            SetPointValue();
        }//public Balloon(BalloonManager.BalloonColor color)

    }
}
