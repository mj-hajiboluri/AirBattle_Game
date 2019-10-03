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
    class EnemyBomb
    {
        public int EndObject = 0;
        Move.Move MoveEnemy = new Move.Move();
        

        //Begin Explode
        public Texture2D TextureExplode;
        public Vector2 PositionExplode;

        public Rectangle ExplodeRec;

        Point frameSize = new Point(100, 100);
        Point currentFrame = new Point(0, 0);
        Point sheetSize = new Point(3, 3);

        public int EnableExplode = 0;
        //End Explode

        //Begin Enemy
        public Texture2D Texture;
        public Vector2 Position;

        public Rectangle EnemyRec;
        public Rectangle EnemyRecIntersect_1;
        public Rectangle EnemyRecIntersect_2;
        public Rectangle EnemyRecIntersect_3;
        public Rectangle EnemyRecIntersect_4;
        public Rectangle EnemyRecIntersect_5;
        

        public bool visible = true;
        //End Enemy

        //Begin Bullet
        public Vector2 PositionBullet;
        public Texture2D TextureBullet;
        public Texture2D TextureFlame;
        //End Bullet

        //Begin Time
        int timeSinceLastFrame = 0;
        int millisecondsPerFrame = 48;
        int millisecondsPerFire = 2600;
        //End Time
        
        public int health = 150;

        public EnemyBomb(Texture2D texture, Vector2 position, Texture2D textureExplode, Vector2 positionExplode, Texture2D textureBullet,Texture2D textureFlame,int randomFire)
        {
            this.Texture = texture;
            this.Position = position;
            this.TextureExplode = textureExplode;
            this.TextureFlame = textureFlame;

            millisecondsPerFire = randomFire;

            this.PositionExplode = positionExplode;

            //add kardane yek  textrure  khod
            this.TextureBullet = textureBullet;
            //payane add kardane be list static



            EnemyRec = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Texture.Width, this.Texture.Height);
            EnemyRecIntersect_1 = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Texture.Width, 23);
            EnemyRecIntersect_2 = new Rectangle((int)this.Position.X+25, (int)this.Position.Y + 23, 169, 23);
            EnemyRecIntersect_3 = new Rectangle((int)this.Position.X + 56, (int)this.Position.Y + 48, 106, 21);
            EnemyRecIntersect_4 = new Rectangle((int)this.Position.X + 89, (int)this.Position.Y + 71, 41, 20);
            EnemyRecIntersect_5 = new Rectangle((int)this.Position.X + 103, (int)this.Position.Y + 97, 14, 39);

            ExplodeRec = new Rectangle(0, 0, 100, 100);

        }


        public void draw(SpriteBatch Sprite)
        {
            if (visible == true)
            {
                //******* taghir dar draw enemy bomb besorate inke scale ra dar moteghayere static zarb karde va position havapeyma ra niz dar in moteghayer ha zarb nemodim
                Sprite.Draw(Texture, new Vector2(Position.X * Share.StaticVarVector2D.scaleobj_Width, Position.Y * Share.StaticVarVector2D.scaleobj_Height), null, Color.White, 0, Vector2.Zero, new Vector2(Share.StaticVarVector2D.scaleobj_Width, Share.StaticVarVector2D.scaleobj_Height), SpriteEffects.None, 0);
                //Sprite.Draw(Texture, EnemyRec, Color.Red);
                //Sprite.Draw(Texture, EnemyRecIntersect_1, Color.Yellow);
                //Sprite.Draw(Texture, EnemyRecIntersect_2, Color.Yellow);
                //Sprite.Draw(Texture, EnemyRecIntersect_3, Color.Yellow);
                //Sprite.Draw(Texture, EnemyRecIntersect_4, Color.Yellow);
                //Sprite.Draw(Texture, EnemyRecIntersect_5, Color.Yellow);

            }
            if (visible == false)
            {
                PositionExplode.X = Position.X + (Texture.Width / 2) - (ExplodeRec.Width * 2 / 2);
                PositionExplode.Y = Position.Y + (Texture.Height / 2) - (ExplodeRec.Height * 2 / 2);
                Sprite.Draw(TextureExplode, new Vector2(PositionExplode.X * Share.StaticVarVector2D.scaleobj_Width, PositionExplode.Y * Share.StaticVarVector2D.scaleobj_Height), ExplodeRec, Color.White, 0, Vector2.Zero, new Vector2(Share.StaticVarVector2D.scaleobj_Width, Share.StaticVarVector2D.scaleobj_Height)*2, SpriteEffects.None, 0);
            }
        }

        public void update(GameTime gametime)
        {


            if (visible == true)
            {
                this.Position = MoveEnemy.GoAhead(this.Position, 1f);
                //this.Position = MoveEnemy.Seek(this.Position, 2f,0.1f);
                //this.Position = MoveEnemy.Arrive(this.Position, 0.01f);
                //****** hamchenin rectangele asli ke baraye barkhord va keshidane havapeyma estefade mishavad ham position va ham andaze texture ra dar moteghayer haye static zarb nemodim
                EnemyRec = new Rectangle((int)(this.Position.X * Share.StaticVarVector2D.scaleobj_Width), (int)(this.Position.Y * Share.StaticVarVector2D.scaleobj_Height), (int)(this.Texture.Width * Share.StaticVarVector2D.scaleobj_Width), (int)(this.Texture.Height * Share.StaticVarVector2D.scaleobj_Height));
                EnemyRecIntersect_1 = new Rectangle((int)(this.Position.X * Share.StaticVarVector2D.scaleobj_Width), (int)(this.Position.Y * Share.StaticVarVector2D.scaleobj_Height), (int)(this.Texture.Width * Share.StaticVarVector2D.scaleobj_Width), (int)(23 * Share.StaticVarVector2D.scaleobj_Height));
                EnemyRecIntersect_2 = new Rectangle((int)((this.Position.X + 25) * Share.StaticVarVector2D.scaleobj_Width), (int)((this.Position.Y + 23) * Share.StaticVarVector2D.scaleobj_Height), (int)(169 * Share.StaticVarVector2D.scaleobj_Width), (int)(23 * Share.StaticVarVector2D.scaleobj_Height));
                EnemyRecIntersect_3 = new Rectangle((int)((this.Position.X + 56) * Share.StaticVarVector2D.scaleobj_Width), (int)((this.Position.Y + 48) * Share.StaticVarVector2D.scaleobj_Height), (int)(106 * Share.StaticVarVector2D.scaleobj_Width), (int)(21 * Share.StaticVarVector2D.scaleobj_Height));
                EnemyRecIntersect_4 = new Rectangle((int)((this.Position.X + 89) * Share.StaticVarVector2D.scaleobj_Width), (int)((this.Position.Y + 71) * Share.StaticVarVector2D.scaleobj_Height), (int)(41 * Share.StaticVarVector2D.scaleobj_Width), (int)(20 * Share.StaticVarVector2D.scaleobj_Height));
                EnemyRecIntersect_5 = new Rectangle((int)((this.Position.X + 103) * Share.StaticVarVector2D.scaleobj_Width), (int)((this.Position.Y + 97) * Share.StaticVarVector2D.scaleobj_Height), (int)(14 * Share.StaticVarVector2D.scaleobj_Width), (int)(38 * Share.StaticVarVector2D.scaleobj_Height));

                //add kardane yek golole ba textrure va position khase khod
                timeSinceLastFrame += gametime.ElapsedGameTime.Milliseconds;  //dar in chand khat kode dar yek baze zamani yek golole tavasote list baraye enemy dorost mishavad
                if (timeSinceLastFrame > millisecondsPerFire)
                {
                    timeSinceLastFrame = 0;
                    PositionBullet = new Vector2((int)(this.Position.X * Share.StaticVarVector2D.scaleobj_Width) + ((int)(this.Texture.Width * Share.StaticVarVector2D.scaleobj_Width) / 2), (int)(this.Position.Y * Share.StaticVarVector2D.scaleobj_Height) + ((int)(this.Texture.Height * Share.StaticVarVector2D.scaleobj_Height) / 2));
                    //this.TextureBullet = textureBullet;
                    if (this.Position.Y + 160 < Share.StaticVarVector2D.PositionStaticJet.Y) /*in adad va in if ra be dalile in gozashtim ke az ye hadi dige moshak nazane*/
                    {
                        BulletStatic.AddBomb(TextureBullet, PositionBullet, 2, TextureFlame);
                    }
                    
                }
                //payane add kardane be list static
            }

            if (visible == false)
            {

                // ejraye enfejar baraye doshman
                if (currentFrame.X == sheetSize.X - 1 && currentFrame.Y == sheetSize.Y - 1)
                {
                    EnableExplode = 1;
                    if (EnableExplode == 1)
                        EndObject = 1;
                }

                timeSinceLastFrame += gametime.ElapsedGameTime.Milliseconds;    //for delay
                if (timeSinceLastFrame > millisecondsPerFrame)                  //for delay 
                {                                                               //for delay
                    timeSinceLastFrame = 0;//millisecondsPerFrame;              //for delay
                    ++currentFrame.X;
                    if (currentFrame.X >= sheetSize.X)
                    {
                        currentFrame.X = 0;
                        ++currentFrame.Y;
                        if (currentFrame.Y >= sheetSize.Y)
                            currentFrame.Y = 0;
                    }
                }                                                               //for delay

                ExplodeRec = new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y);



            }
        }


    }
}
