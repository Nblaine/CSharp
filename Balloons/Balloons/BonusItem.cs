using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Balloons
{
    public class BonusItem
    {
        private int m_iBonusPoints = 0;
        private Vector2 itemLocation = Vector2.Zero;
        private Rectangle itemActiveArea;
        private bool m_bIsActive = true;
        Texture2D itemTexture;

        public int BonusPoints
        {
            get { return m_iBonusPoints; }
            set { m_iBonusPoints = value; }
        }

        public Vector2 Location
        {
            get { return itemLocation; }
            set { itemLocation = value; }
        }

        public Rectangle ActiveArea
        {
            get { return itemActiveArea; }
            set { itemActiveArea = value; }
        }

        public bool Active
        {
            get { return m_bIsActive; }
            set { m_bIsActive = value; }
        }

        public Texture2D ItemTexture
        {
            get { return itemTexture; }
            set { itemTexture = value; }
        }

        public BonusItem() { }

        public BonusItem(int iPoints, Vector2 location, Rectangle activeRect, Texture2D itemTexture)
        {
            m_iBonusPoints = iPoints;
            itemLocation = location;
            itemActiveArea = activeRect;
            this.itemTexture = itemTexture;
        }
    }
}
