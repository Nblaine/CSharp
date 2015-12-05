using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Balloons
{
    public class BonusItemManager
    {
        ContentManager content;
        List<BonusItem> lstBonusItems;
        private float m_fItemCoolDown = 15.0f;
        private float m_fCurrentItemTick = 0.0f;
        private Texture2D itemSpriteSheet;
        private BalloonManager balloonManager;

        private SoundEffect gemEffect;
        private SoundEffectInstance gemEffectInstance;

        private SoundEffect gemAppearEffect;
        private SoundEffectInstance gemAppearEffectInstance;

        public BonusItemManager(ContentManager content, BalloonManager balloonManager)
        {
            lstBonusItems = new List<BonusItem>();
            this.content = content;

            itemSpriteSheet = this.content.Load<Texture2D>("Misc/gems");
            gemEffect = this.content.Load<SoundEffect>("Sounds/getruby");
            gemAppearEffect = this.content.Load<SoundEffect>("Sounds/enchant");

            gemEffectInstance = gemEffect.CreateInstance();
            gemAppearEffectInstance = gemAppearEffect.CreateInstance();

            this.balloonManager = balloonManager;
        }

        private void CheckMouseInput(MouseState ms)
        {
            Point mousePoint = new Point(ms.X, ms.Y);

            for(int i = 0; i < lstBonusItems.Count; i++)
            {
                if(ms.LeftButton == ButtonState.Pressed && lstBonusItems[i].ActiveArea.Contains(mousePoint))
                {
                    lstBonusItems[i].Active = false;
                    balloonManager.TotalScore += lstBonusItems[i].BonusPoints;
                    gemEffectInstance.Volume = 0.1f;
                    gemEffectInstance.Play();
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            m_fCurrentItemTick += elapsed;

            if(m_fCurrentItemTick >= m_fItemCoolDown)
            {
                Random r = new Random(DateTime.Now.Minute * DateTime.Now.Second * DateTime.Now.Millisecond);

                double d = r.NextDouble() * 100.00;

                if(d < 25.00)
                {
                    BonusItem item = new BonusItem();
                    Random rBonusPointsGenerator = new Random(DateTime.Now.Minute * DateTime.Now.Second * DateTime.Now.Millisecond * 3500);

                    Random rRandomLocationGen = new Random(DateTime.Now.Minute * DateTime.Now.Second * DateTime.Now.Millisecond * 6500);
                    Vector2 itemLocation = new Vector2(rRandomLocationGen.Next(0, 750), rRandomLocationGen.Next(0, 750));

                    item.BonusPoints = rBonusPointsGenerator.Next(20, 51);
                    item.Location = itemLocation;
                    item.ItemTexture = itemSpriteSheet;
                    item.ActiveArea = new Rectangle((int)itemLocation.X, (int)itemLocation.Y, 32, 32);

                    lstBonusItems.Add(item);

                    gemAppearEffectInstance.Volume = 0.3f;
                    gemAppearEffectInstance.Play();
                }

                m_fCurrentItemTick = 0.0f;
            }

            CheckMouseInput(Mouse.GetState());

            for (int i = 0; i < lstBonusItems.Count; i++)
                if (!lstBonusItems[i].Active)
                    lstBonusItems.RemoveAt(i);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (BonusItem item in lstBonusItems)
                if (item.Active)
                    spriteBatch.Draw(item.ItemTexture, item.Location, new Rectangle(32, 96, 32, 32), Color.White);
        }
    }
}
