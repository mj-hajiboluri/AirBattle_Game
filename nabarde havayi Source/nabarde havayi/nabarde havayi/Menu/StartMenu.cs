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

namespace nabarde_havayi.Menu
{
    class StartMenu
    {
        public int enter;
        SpriteFont myfont;

        KeyboardState state, previous_state;

        public List<string> item = new List<string>();
        public List<Vector2> positem = new List<Vector2>();

        Random rand = new Random();

        public int selected = 0;
        public int exit = 0; //*** dar zamani ke enter=0 hast va agar in gozine ro entekhab konim (dar game1.cs dar ghesmate enter==0) baese khoroj az bazi mishe
        public int isStartGame = 0; //*** az in moteghayer baraye inke beyne start va continue switch konim estefade mikonim
        public int isEndGame = 0; //*** in zamani ke jet mitereke barabare 1 mishe ta be in tartib if marbot behesh ejra beshe

        public StartMenu(ContentManager content)
        {
            enter = 0;
            myfont = content.Load<SpriteFont>("Font//menuFont");
            item.Add("START");
            positem.Add(new Vector2(40, 40));
            item.Add("EXIT");
            positem.Add(new Vector2(40, 110));

            item.Add("|*|*|*| HAPPY BIRTHDAY HONEY |*|*|*|");
            positem.Add(new Vector2((40), Share.StaticVarVector2D.windowY/2));
        }

        public void draw(SpriteBatch sprite)
        {
            int j = 0;
            foreach (string i in item)
            {
                if (selected == j)
                {
                    sprite.DrawString(myfont, item[j], new Vector2(positem[j].X + rand.Next(3, 9), positem[j].Y + rand.Next(3, 9)), Color.Orange);
                    sprite.DrawString(myfont, item[j], new Vector2(positem[j].X - rand.Next(3, 9), positem[j].Y - rand.Next(3, 9)), Color.Orange);
                    //sprite.DrawString(myfont, item[j], new Vector2(positem[j].X + rand.Next(3, 9), positem[j].Y - rand.Next(3, 9)), Color.Orange);
                }
                if (j == 2)
                {
                    sprite.DrawString(myfont, i, positem[j], Color.CornflowerBlue);
                }
                else
                {
                    sprite.DrawString(myfont, i, positem[j], Color.Cornsilk);
                }
                //j += 20;
                j++;
            }

        }

        public void update(GameTime time)
        {
            //CurrentTime += time.ElapsedGameTime; //* har lahze az update 1 meghdar be current time ke az noe TimeSpan hastesh ezafe mikonim
            state = Keyboard.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.Down) && previous_state.IsKeyUp(Keys.Down))
            {
                selected += 1;
                //control += 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.Up) && previous_state.IsKeyUp(Keys.Up))
            {
                selected -= 1;
                //control += 1;
            }

            previous_state = Keyboard.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && selected == 0)
            {
                enter = 1;
                isStartGame = 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && selected == 1)
            {
                exit = 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Escape) )
            {
                enter = 0;
                if (isStartGame==1)
                {
                    item[0] = "Continue";
                }
            }

            if (isEndGame == 1)
            {
                Share.EnemyStatic.ListEnemy.Clear();
                Share.EnemyStatic.ListEnemyBomb.Clear();
                Share.BulletJetStatic.newlistBulletJet.Clear();
                Share.BulletStatic.newlistBullet.Clear();
                Share.EnemyStaticVariable.ListEnemyBombCount = 0;
                Share.EnemyStaticVariable.ListEnemyCount = 0;
                isEndGame = 0;
            }

        }
    }
}
