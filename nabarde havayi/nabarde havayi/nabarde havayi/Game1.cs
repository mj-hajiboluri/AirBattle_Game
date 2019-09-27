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

namespace nabarde_havayi
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont myFont;
        string myText;

        Player jet;
        PlayerBullet[] bullet = new PlayerBullet[20];
        int isJetDestroy = 0; //*** omadim in moteghayer sarasari ro tarif kardim ke vaghti to bazi jet terekid barabare 1 mishe, bad to ye ye shart barasi mikonim ke age 1 bod va hich enfejari vojod nadasht ye bare dige content ro load kone va hame doshman haro riset mikone

        Menu.StartMenu menu;

        Level.Level1 level1 ;
        //List<Enemy> EnemyStatic.ListEnemy = new List<Enemy>();
        //int ListEnemyCount = 2;

        //List<EnemyBomb> EnemyStatic.ListEnemyBomb = new List<EnemyBomb>();
        //int ListEnemyBombCount = 2;
        Random rand = new Random();

        MouseState state, previous_state;

        TimeSpan CurrentTime;

        
        Texture2D BackGround;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            //Resolution.Init(ref graphics); //********
            
            Content.RootDirectory = "Content";

            //Resolution.SetVirtualResolution(800, 600);
            //Resolution.SetResolution(1600, 900, true);
            //* neshan dadane mouse 
            IsMouseVisible = false;
            //Window.AllowUserResizing = true;
            //* moshakhas kardane size safhe

            this.graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;

            this.graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //GraphicsDevice.PresentationParameters.BackBufferWidth = 800;
            //GraphicsDevice.PresentationParameters.BackBufferHeight = 600;
            //this.graphics.GraphicsDevice.PresentationParameters.BackBufferWidth = 800;
            //graphics.GraphicsDevice.PresentationParameters.BackBufferHeight = 600;
            Share.StaticVarVector2D.scaleobj_Width = (float)this.graphics.PreferredBackBufferWidth / 1600;   //****** sabte meghdare scale arzi
            Share.StaticVarVector2D.scaleobj_Height = (float)this.graphics.PreferredBackBufferHeight / 900;   //******** sabte meghdare scale toli  har do dar do moteghayere static
            this.graphics.IsFullScreen = true;
            
        }

        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            myFont = Content.Load<SpriteFont>("Font\\myFont");
            myText = "Health:";

            Share.StaticVarVector2D.windowX = Window.ClientBounds.Width;
            Share.StaticVarVector2D.windowY = Window.ClientBounds.Height;
            Share.StaticVarVector2D.windowLeft = Window.ClientBounds.Left;
            Share.StaticVarVector2D.windowRight = Window.ClientBounds.Right;

            menu = new Menu.StartMenu(Content);

            BackGround = Content.Load<Texture2D>("Image\\BackGround");

            Share.StaticVarTexture.StaticTexture_Jet = Content.Load<Texture2D>("Image\\Game_Explode");
            Share.StaticVarTexture.StaticTexture_BulletJet = Content.Load<Texture2D>("Image\\bomb");
            Share.StaticVarTexture.StaticTexture_Enemy_red = Content.Load<Texture2D>("Image\\Enemy_red");
            Share.StaticVarTexture.StaticTexture_Enemy_Bomb = Content.Load<Texture2D>("Image\\Enemy_Bomb");
            Share.StaticVarTexture.StaticTexture_Game_Explode = Content.Load<Texture2D>("Image\\Game_Explode");
            Share.StaticVarTexture.StaticTexture_bomb = Content.Load<Texture2D>("Image\\bomb1");
            Share.StaticVarTexture.StaticTexture_EnemyMissile = Content.Load<Texture2D>("Image\\EnemyMissile");
            Share.StaticVarTexture.StaticTexture_FlameMissile = Content.Load<Texture2D>("Image\\FlameMissile");

            // TODO: use this.Content to load your game content here
            jet = new Player(Content.Load<Texture2D>("Image\\jet"), Vector2.Zero); //Enemy_red

            level1 = new Level.Level1(Content.Load<Texture2D>("Image\\cloud"), Content.Load<Texture2D>("Image\\cloud1"), Content.Load<Texture2D>("Image\\cloud2"), new Vector2(rand.Next(Share.StaticVarVector2D.windowLeft, Share.StaticVarVector2D.windowRight), -140), new Vector2(rand.Next(Share.StaticVarVector2D.windowLeft, Share.StaticVarVector2D.windowRight), -230), new Vector2(rand.Next(Share.StaticVarVector2D.windowLeft, Share.StaticVarVector2D.windowRight), -300));

            //for (int i = 0; i < ListEnemyCount; i++)
            //{
            //    EnemyStatic.ListEnemy.Add(new Enemy(Content.Load<Texture2D>("Image\\Enemy_red"), new Vector2(i*160,i*100), Content.Load<Texture2D>("Image\\Game_Explode"), Vector2.Zero, Content.Load<Texture2D>("Image\\bomb")));
            //}
            

            //for (int i = 0; i < ListEnemyBombCount; i++)
            //{
            //    EnemyStatic.ListEnemyBomb.Add(new EnemyBomb(Content.Load<Texture2D>("Image\\Enemy_Bomb"), new Vector2(i * 160, i * 100), Content.Load<Texture2D>("Image\\Game_Explode"), Vector2.Zero, Content.Load<Texture2D>("Image\\EnemyMissile"), Content.Load<Texture2D>("Image\\FlameMissile")));//EnemyMissile
            //}

         
            
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

      
        protected override void Update(GameTime gameTime)
        {

            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //    this.Exit();
            //if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    this.Exit();

if (menu.enter == 0)
{
    menu.update(gameTime);
    if (menu.exit == 1)
    {
        this.Exit();
    }
}
if (menu.enter == 1)
{

    #region UPDATE PLAYER
    //---------------------------------------------------
    //* chon window.clientbounds.width and height tarif nemishod an ra besorate parametr ferestadim
    jet.update(gameTime, this.graphics.PreferredBackBufferWidth, this.graphics.PreferredBackBufferHeight);

    //---------------------------------------------------
    #endregion

    #region SHELIKE GOLOLE PLAYER
    //---------------------------------------------------

    CurrentTime += gameTime.ElapsedGameTime; //* har lahze az update 1 meghdar be current time ke az noe TimeSpan hastesh ezafe mikonim
    state = Mouse.GetState();

    //* dar shart meghdare currenttime ra ba 200 migli second barasi mikonim, agar current time be in zaman reside bashad az an bozorgtar shode va shrt true mishavad
    if (CurrentTime > TimeSpan.FromMilliseconds(250) && state.LeftButton == ButtonState.Pressed && ButtonState.Released == previous_state.LeftButton && jet.visible == true/*&& counterBulletPlayer < 20*/)
    {
        //***add kardane golole be list ra anjam midahim
        Share.BulletJetStatic.AddBulletJet(Share.StaticVarTexture.StaticTexture_BulletJet, jet.Position, 25, Color.White);
        //Share.BulletJetStatic.AddBulletJet(Share.StaticVarTexture.StaticTexture_BulletJet, new Vector2(jet.Position.X - 20, jet.Position.Y + 20), 25, Color.Black);
        //Share.BulletJetStatic.AddBulletJet(Share.StaticVarTexture.StaticTexture_BulletJet, new Vector2(jet.Position.X + 20, jet.Position.Y + 20), 25, Color.Black);
        CurrentTime = TimeSpan.Zero;//* meghdare current time ra bad az har shelik reset mikonim
    }
    //previous_state = state;





    //---------------------------------------------------
    #endregion

    #region Explode Enemy
    //---------------------------------------------------
    //if (Keyboard.GetState().IsKeyDown(Keys.N) )//&& flagExplodeTest == 1)
    //{
    //    Explode_01.FlagEndAnimation = 0;

    //}

    //for (int i = 0; i < EnemyStatic.ListEnemyCount; i++)
    //{
    //    if (EnemyStatic.ListEnemy.Count > 0)
    //    {
    //        if (EnemyStatic.ListEnemy[i].EnableExplode == 0)
    //        {
    //            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
    //            if (timeSinceLastFrame > millisecondsPerFrame)
    //            {
    //                timeSinceLastFrame = 0;//millisecondsPerFrame;
    //                EnemyStatic.ListEnemy[i].update(gameTime);
    //            }
    //        }
    //    }
    //}
    //foreach (Enemy item in EnemyStatic.ListEnemy)
    //{
    //    if (item.EnableExplode == 0)
    //    {
    //        item.update(gameTime);
    //    }
    //}
    //---------------------------------------------------
    #endregion

    #region Barkhorde Golole Ba Doshman
    //---------------------------------------------------
    for (int i = 0; i < Share.BulletJetStatic.newlistBulletJet.Count; i++)
    {
        for (int j = 0; j < EnemyStaticVariable.ListEnemyCount && EnemyStatic.ListEnemy.Count > 0; j++) //baraye enemy ghermez
        {
            if (Share.BulletJetStatic.newlistBulletJet[i].PlayerBulletRec.Intersects(EnemyStatic.ListEnemy[j].EnemyRec))
            {
                if (Share.BulletJetStatic.newlistBulletJet[i].PlayerBulletRec.Intersects(EnemyStatic.ListEnemy[j].EnemyRecIntersect_1) || Share.BulletJetStatic.newlistBulletJet[i].PlayerBulletRec.Intersects(EnemyStatic.ListEnemy[j].EnemyRecIntersect_2))
                {
                    if (EnemyStatic.ListEnemy[j].health > 0)
                    {
                        Share.BulletJetStatic.newlistBulletJet[i].active = false;
                        Share.ExplodeStatic.AddExplodeBulletJet(Share.StaticVarTexture.StaticTexture_Jet, Share.BulletJetStatic.newlistBulletJet[i].Position);
                    }
                    EnemyStatic.ListEnemy[j].health -= 25;
                    if (EnemyStatic.ListEnemy[j].health == 0)
                    {
                        EnemyStatic.ListEnemy[j].visible = false;
                        EnemyStatic.ListEnemy[j].EnableExplode = 0;
                    }
                }
            }
        }

        for (int j = 0; j < EnemyStaticVariable.ListEnemyBombCount && EnemyStatic.ListEnemyBomb.Count > 0; j++) //baraye enemy bomb sabz
        {
            if (Share.BulletJetStatic.newlistBulletJet[i].PlayerBulletRec.Intersects(EnemyStatic.ListEnemyBomb[j].EnemyRec) && EnemyStatic.ListEnemyBomb[j].visible == true)
            {
                if (Share.BulletJetStatic.newlistBulletJet[i].PlayerBulletRec.Intersects(EnemyStatic.ListEnemyBomb[j].EnemyRecIntersect_1)
                    || Share.BulletJetStatic.newlistBulletJet[i].PlayerBulletRec.Intersects(EnemyStatic.ListEnemyBomb[j].EnemyRecIntersect_2)
                    || Share.BulletJetStatic.newlistBulletJet[i].PlayerBulletRec.Intersects(EnemyStatic.ListEnemyBomb[j].EnemyRecIntersect_3)
                    || Share.BulletJetStatic.newlistBulletJet[i].PlayerBulletRec.Intersects(EnemyStatic.ListEnemyBomb[j].EnemyRecIntersect_4)
                    || Share.BulletJetStatic.newlistBulletJet[i].PlayerBulletRec.Intersects(EnemyStatic.ListEnemyBomb[j].EnemyRecIntersect_5))
                {
                    if (EnemyStatic.ListEnemyBomb[j].health > 0)
                    {
                        Share.BulletJetStatic.newlistBulletJet[i].active = false;
                        Share.ExplodeStatic.AddExplodeBulletJet(Share.StaticVarTexture.StaticTexture_Jet, Share.BulletJetStatic.newlistBulletJet[i].Position);
                    }
                    EnemyStatic.ListEnemyBomb[j].health -= Share.BulletJetStatic.newlistBulletJet[i].Destruction;
                    if (EnemyStatic.ListEnemyBomb[j].health == 0)
                    {
                        EnemyStatic.ListEnemyBomb[j].visible = false;
                        EnemyStatic.ListEnemyBomb[j].EnableExplode = 0;
                    }
                }
            }
        }


    }

    for (int i = 0; i < EnemyStatic.ListEnemy.Count; i++)
    {
        if (EnemyStatic.ListEnemy[i].EndObject == 1)
        {
            EnemyStatic.ListEnemy.RemoveAt(i);
            EnemyStaticVariable.ListEnemyCount--;
        }
    }

    for (int i = 0; i < EnemyStatic.ListEnemyBomb.Count; i++)
    {
        if (EnemyStatic.ListEnemyBomb[i].EndObject == 1)
        {
            EnemyStatic.ListEnemyBomb.RemoveAt(i);
            EnemyStaticVariable.ListEnemyBombCount--;
        }
    }
    //---------------------------------------------------
    #endregion

    #region Barkhorde Golole Doshman Ba Jet
    //---------------------------------------------------
    foreach (EnemyBullet.EnemyBullet item in Share.BulletStatic.newlistBullet)
    {
        if (jet.PlayerRec.Intersects(item.EnemyBulletRec))
        {
            foreach (Rectangle itemjet in jet.PlayerRecIntersect)// list rectagele haye mojod baraye jet mibashad
            {
                if (itemjet.Intersects(item.EnemyBulletRec))
                {
                    if (jet.health > 0)
                    {
                        if (item.IsEnemyBulletHit == false) /* baraye inke faghat yek bar golole yi ke be jet bar khord mikonad 1 bar jon kam konad */
                        {
                            jet.health -= 25;
                            item.IsEnemyBulletHit = true;
                        }
                        item.EnableEnemyBullet = false;
                        Share.ExplodeStatic.AddExplodeBulletJet(Share.StaticVarTexture.StaticTexture_Jet, item.Position);

                    }
                    //jet.health -= 25;
                    //myText = "Health:" + " " + jet.health.ToString();
                    if (jet.health <= 0)
                    {
                        jet.barkhord();
                        jet.visible = false;
                        item.EnableEnemyBullet = false;

                        //*** khat codi ke baraye bad az bakhtane hava peymaha miayad mibashad
                        isJetDestroy = 1;

                        //LoadContent();
                        //menu.isEndGame = 1;
                    }
                }
            }
        }
    }
    //---------------------------------------------------
    #endregion

    #region Barkhorde Jet Ba Enemy
    //---------------------------------------------------
    foreach (Enemy item in EnemyStatic.ListEnemy)
    {
        if (jet.PlayerRec.Intersects(item.EnemyRec))
        {
            foreach (Rectangle itemjet in jet.PlayerRecIntersect)// list rectagele haye mojod baraye jet mibashad
            {
                if (itemjet.Intersects(item.EnemyRecIntersect_1) || itemjet.Intersects(item.EnemyRecIntersect_2))
                {
                    jet.barkhord();
                    jet.visible = false;
                    item.visible = false;
                    item.EnableExplode = 0;

                    //*** khat codi ke baraye bad az bakhtane hava peymaha miayad mibashad
                    isJetDestroy = 1;
                    

                }
            }
        }
    }

    foreach (EnemyBomb item in EnemyStatic.ListEnemyBomb)
    {
        if (jet.PlayerRec.Intersects(item.EnemyRec))
        {
            foreach (Rectangle itemjet in jet.PlayerRecIntersect)// list rectagele haye mojod baraye jet mibashad
            {
                if (itemjet.Intersects(item.EnemyRecIntersect_1) || itemjet.Intersects(item.EnemyRecIntersect_2)
                    || itemjet.Intersects(item.EnemyRecIntersect_3) || itemjet.Intersects(item.EnemyRecIntersect_4)
                    || itemjet.Intersects(item.EnemyRecIntersect_5))
                {
                    jet.barkhord();
                    jet.visible = false;
                    item.visible = false;
                    item.EnableExplode = 0;

                    //*** khat codi ke baraye bad az bakhtane hava peymaha miayad mibashad
                    isJetDestroy = 1;
                }
            }
        }
    }
    //---------------------------------------------------
    #endregion

    #region UPDATE ENEMY
    //---------------------------------------------------
    foreach (Enemy item in EnemyStatic.ListEnemy)
    {
        item.update(gameTime);
        if (item.Position.Y > Window.ClientBounds.Bottom + 20)
        {
            item.Position.Y = -50;
        }
    }

    foreach (EnemyBomb item in EnemyStatic.ListEnemyBomb)
    {
        item.update(gameTime);
        if (item.Position.Y > Window.ClientBounds.Bottom + 20)
        {
            item.Position.Y = -50;
        }
    }
    //---------------------------------------------------
    #endregion

    #region update va remove BulletStatic & ExplodeStatic
    //-----------------------------------------
    //for enemybullet
    if (Share.BulletStatic.newlistBullet.Count > 0)
    {
        foreach (EnemyBullet.EnemyBullet item in Share.BulletStatic.newlistBullet) //update tarsimate golole haye mojod dar list estatic
        {
            item.update(gameTime);
        }
        Share.BulletStatic.CheckRange(Window);
    }

    //for explosion jet
    if (Share.ExplodeStatic.newlistExplode.Count > 0)
    {
        foreach (Explode item in Share.ExplodeStatic.newlistExplode) //update tarsimate explosion haye mojod dar safhe
        {
            item.update(gameTime);
        }
        Share.ExplodeStatic.RemoveExplode();
    }

    //for bullet jet
    if (Share.BulletJetStatic.newlistBulletJet.Count > 0)
    {
        foreach (PlayerBullet item in Share.BulletJetStatic.newlistBulletJet) //update tarsimate explosion haye mojod dar safhe
        {
            item.update(gameTime);
        }
        Share.BulletJetStatic.RemoveBulletJet();
    }

    //-----------------------------------------
    #endregion

    #region Level
    //---------------------------------------------------

    level1.update(gameTime);
    if (level1.endLevel1 == 1)
    {
        isJetDestroy = 1;
    }

    //---------------------------------------------------
    #endregion

    #region Menu
    //---------------------------------------------------

    menu.update(gameTime);

    //---------------------------------------------------
    #endregion

    #region EndGame
    //---------------------------------------------------

    if (isJetDestroy == 1 && Share.ExplodeStatic.newlistExplode.Count() == 0)
    {
        isJetDestroy = 0;
        LoadContent();
        menu.isEndGame = 1;
    }

    //---------------------------------------------------
    #endregion

}

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);
            ////*****************************
            ////this.graphics.PreferredBackBufferWidth = 1600;
            ////this.graphics.PreferredBackBufferHeight = 900;
            //Vector3 screenScalingFactor;

            //Share.StaticVarVector2D.scaleobj = (float)this.graphics.PreferredBackBufferWidth / 1600;
            //float verScaling = (float)this.graphics.PreferredBackBufferHeight / 900;
            //screenScalingFactor = new Vector3(horScaling, verScaling, 1);
            //////screenScalingFactor = new Vector3(1, 1, 1);
            //Matrix globalTransformation = Matrix.CreateScale(screenScalingFactor);
            //****************************
            // TODO: Add your drawing code here
            if (menu.enter == 0)
            {
                spriteBatch.Begin();
                menu.draw(spriteBatch);
                spriteBatch.End();
            }

            if (menu.enter == 1)
            {
                spriteBatch.Begin();
                //Resolution.BeginDraw();
                //spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.AnisotropicClamp, DepthStencilState.Default, null, null, globalTransformation);
                //level1.draw(spriteBatch);

                level1.draw(spriteBatch);


                foreach (EnemyBullet.EnemyBullet item in Share.BulletStatic.newlistBullet) //update tarsimate golole haye mojod dar list estatic
                {
                    item.draw(spriteBatch);
                }

                foreach (PlayerBullet item in Share.BulletJetStatic.newlistBulletJet)
                {
                    item.draw(spriteBatch);
                }

                if (jet.visible == true)
                {
                    jet.draw(spriteBatch);
                }

                foreach (Enemy item in EnemyStatic.ListEnemy)
                {
                    item.draw(spriteBatch);
                }

                foreach (EnemyBomb item in EnemyStatic.ListEnemyBomb)
                {
                    item.draw(spriteBatch);
                }

                foreach (Explode item in Share.ExplodeStatic.newlistExplode)
                {
                    item.draw(spriteBatch);
                }

                


                //*** baraye neshan dadane jone havapeyma
                myText = "Health:" + " " + jet.health.ToString();
                spriteBatch.DrawString(myFont, myText, new Vector2(10, 10), Color.Aqua);


                spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}
