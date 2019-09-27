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
using nabarde_havayi.Share;

namespace nabarde_havayi.Level
{
    class Level1
    {
        //public bool flagStep1 = false;
        //public bool flagStep2 = false;
        public int step = 1;
        public int endLevel1 = 0;

        Texture2D txt1; 
        Texture2D txt2;
        Texture2D txt3;

        Vector2 txt1pos;
        Vector2 txt2pos;
        Vector2 txt3pos;

        Vector2 txt4pos;
        Vector2 txt5pos;

        int speed1 = 3, speed2 = 5, speed3 = 3, speed4 = 6, speed5 = 5;

        Random rand = new Random();

        

        public void step1()
        {
            Share.EnemyStatic.addEnemyRed(new Vector2(500, -350));
            step = 2;
        }

        public void step2()
        {
            Share.EnemyStatic.addEnemyRed(new Vector2(200, -50));
            Share.EnemyStatic.addEnemyRed(new Vector2(300, -160));
            Share.EnemyStatic.addEnemyRed(new Vector2(500, -180));
            //flagStep2 = true;
            step = 3;
        }

        public void step3()
        {
            Share.EnemyStatic.addEnemyRed(new Vector2(200, -50));
            Share.EnemyStatic.addEnemyRed(new Vector2(300, -160));
            Share.EnemyStatic.addEnemyRed(new Vector2(400, -50));
            Share.EnemyStatic.addEnemyRed(new Vector2(500, -180));
            //flagStep3 = true;
            step = 4;
        }

        public void step4()
        {
            Share.EnemyStatic.addEnemyBomb(new Vector2(500, -280));
            Share.EnemyStatic.addEnemyRed(new Vector2(300, -360));
            Share.EnemyStatic.addEnemyRed(new Vector2(400, -260));
            Share.EnemyStatic.addEnemyRed(new Vector2(500, -360));
            //flagStep3 = true;
            step = 5;
        }

        public void step5()
        {
            //Share.EnemyStatic.addEnemyBomb(new Vector2(200, -250));
            Share.EnemyStatic.addEnemyBomb(new Vector2(500, -280));
            Share.EnemyStatic.addEnemyBomb(new Vector2(800, -250));
            Share.EnemyStatic.addEnemyRed(new Vector2(200, -50));
            Share.EnemyStatic.addEnemyRed(new Vector2(300, -160));
            Share.EnemyStatic.addEnemyRed(new Vector2(400, -260));
            Share.EnemyStatic.addEnemyRed(new Vector2(500, -360));
            //flagStep3 = true;
            step = 6;
        }

        public void step6()
        {
            Share.EnemyStatic.addEnemyBomb(new Vector2(110, -250));
            Share.EnemyStatic.addEnemyBomb(new Vector2(310, -280));
            Share.EnemyStatic.addEnemyBomb(new Vector2(510, -250));
            Share.EnemyStatic.addEnemyBomb(new Vector2(710, -280));
            Share.EnemyStatic.addEnemyBomb(new Vector2(160, -450));
            //Share.EnemyStatic.addEnemyBomb(new Vector2(360, -480));
            //Share.EnemyStatic.addEnemyBomb(new Vector2(560, -450));
            //Share.EnemyStatic.addEnemyBomb(new Vector2(760, -480));
            //flagStep3 = true;
            step = 7;
        }

        public void step7()
        {
            Share.EnemyStatic.addEnemyRed(new Vector2(200, -50));
            Share.EnemyStatic.addEnemyRed(new Vector2(300, -100));
            Share.EnemyStatic.addEnemyRed(new Vector2(400, -150));
            Share.EnemyStatic.addEnemyRed(new Vector2(500, -200));
            Share.EnemyStatic.addEnemyRed(new Vector2(250, -150));
            Share.EnemyStatic.addEnemyRed(new Vector2(350, -200));
            Share.EnemyStatic.addEnemyRed(new Vector2(450, -250));
            Share.EnemyStatic.addEnemyRed(new Vector2(550, -300));
            Share.EnemyStatic.addEnemyRed(new Vector2(300, -250));
            Share.EnemyStatic.addEnemyRed(new Vector2(400, -300));
            Share.EnemyStatic.addEnemyRed(new Vector2(500, -350));
            Share.EnemyStatic.addEnemyRed(new Vector2(600, -400));
            //flagStep3 = true;
            step = 8;
        }

        public Level1(Texture2D textureCloud1, Texture2D textureCloud2, Texture2D textureCloud3,Vector2 pos1,Vector2 pos2, Vector2 pos3)
        {
            txt1 = textureCloud1;
            txt2 = textureCloud2;
            txt3 = textureCloud3;
            txt1pos = pos1;
            txt2pos = pos2;
            txt3pos = pos3;
            txt4pos = new Vector2(pos2.X - 100, pos2.Y - 50);
            txt5pos=new Vector2(pos3.X-100,pos3.Y-50);

        }

        public void draw(SpriteBatch sprite)
        {
            //sprite.Draw(txt1, txt1pos, Color.White);
            sprite.Draw(txt1, new Vector2(txt1pos.X, txt1pos.Y), null, Color.White, 0, Vector2.Zero, new Vector2(Share.StaticVarVector2D.scaleobj_Width, Share.StaticVarVector2D.scaleobj_Height), SpriteEffects.None, 0);
            sprite.Draw(txt2, new Vector2(txt2pos.X, txt2pos.Y), null, Color.White, 0, Vector2.Zero, new Vector2(Share.StaticVarVector2D.scaleobj_Width, Share.StaticVarVector2D.scaleobj_Height), SpriteEffects.None, 0);
            sprite.Draw(txt3, new Vector2(txt3pos.X, txt3pos.Y), null, Color.White, 0, Vector2.Zero, new Vector2(Share.StaticVarVector2D.scaleobj_Width, Share.StaticVarVector2D.scaleobj_Height), SpriteEffects.None, 0);
            sprite.Draw(txt2, new Vector2(txt4pos.X, txt4pos.Y), null, Color.White, 0, Vector2.Zero, new Vector2(Share.StaticVarVector2D.scaleobj_Width, Share.StaticVarVector2D.scaleobj_Height), SpriteEffects.None, 0);
            sprite.Draw(txt3, new Vector2(txt5pos.X, txt5pos.Y), null, Color.White, 0, Vector2.Zero, new Vector2(Share.StaticVarVector2D.scaleobj_Width, Share.StaticVarVector2D.scaleobj_Height), SpriteEffects.None, 0);
        }

        public void update(GameTime gametime)
        {
            txt1pos.Y += speed1;
            txt2pos.Y += speed2;
            txt3pos.Y += speed3;
            txt4pos.Y += speed4;
            txt5pos.Y += speed5;

            if (txt1pos.Y > Share.StaticVarVector2D.windowY+200)
            {
                txt1pos.Y = -(rand.Next(200, 400));
                txt1pos.X = rand.Next(Share.StaticVarVector2D.windowLeft, Share.StaticVarVector2D.windowRight);
                speed1 = rand.Next(3, 7);
            }

            if (txt2pos.Y > Share.StaticVarVector2D.windowY + 200)
            {
                txt2pos.Y = -(rand.Next(200, 400));
                txt2pos.X = rand.Next(Share.StaticVarVector2D.windowLeft, Share.StaticVarVector2D.windowRight);
                speed2 = rand.Next(3, 7);
            }

            if (txt3pos.Y > Share.StaticVarVector2D.windowY + 200)
            {
                txt3pos.Y = -(rand.Next(200, 400));
                txt3pos.X = rand.Next(Share.StaticVarVector2D.windowLeft, Share.StaticVarVector2D.windowRight);
                speed3 = rand.Next(3, 7);
            }

            if (txt4pos.Y > Share.StaticVarVector2D.windowY + 200)
            {
                txt4pos.Y = -(rand.Next(200, 400));
                txt4pos.X = rand.Next(Share.StaticVarVector2D.windowLeft, Share.StaticVarVector2D.windowRight);
                speed4 = rand.Next(3, 7);
            }

            if (txt5pos.Y > Share.StaticVarVector2D.windowY + 200)
            {
                txt5pos.Y = -(rand.Next(200, 400));
                txt5pos.X = rand.Next(Share.StaticVarVector2D.windowLeft, Share.StaticVarVector2D.windowRight);
                speed5 = rand.Next(3, 7);
            }
            
            //*** ghesmate update marbot be stepe badi levele bazi
            if (EnemyStaticVariable.ListEnemyCount == 0 && EnemyStaticVariable.ListEnemyBombCount == 0 && step == 8)
            {
                endLevel1 = 1;
            }

            if (EnemyStaticVariable.ListEnemyCount == 0 && EnemyStaticVariable.ListEnemyBombCount == 0) /* agar hich enemy nabod hala check kon kodom step hastesh */
            {
                if (step == 1)
                {
                    step1();
                }

                else if (/*flagStep1 == true &&*/ step == 2)
                {
                    step2();
                }

                else if(step==3)
                {
                    step3();
                }

                else if (step == 4)
                {
                    step4();
                }

                else if (step == 5)
                {
                    step5();
                }

                else if (step == 6)
                {
                    step6();
                }

                else if (step == 7)
                {
                    step7();
                }

            }
        }
    }
}
