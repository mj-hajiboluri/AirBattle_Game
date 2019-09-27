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

namespace nabarde_havayi.EnemyBullet
{
    class EnemyBullet
    {
        public Texture2D Texture;
        public Vector2 Position;

        public bool EnableEnemyBullet = true;
        public bool IsEnemyBulletHit = false;

        public Rectangle EnemyBulletRec;

        //***baraye flame moshak
        public Rectangle FlameBulletRec;
        public Vector2 FlamePosition;
        public Texture2D FlameTexture;

        Point frameSize = new Point(15, 70);
        Point currentFrame = new Point(0, 0);
        Point sheetSize = new Point(2, 1);

        int timeSinceLastFrame = 0;
        int millisecondsPerFrame = 48;
        //***

        public int Type;

        public float Rotation=-180;

        public bool hit = false;

        Move.Move MoveEnemy = new Move.Move();

        public EnemyBullet(Vector2 position,Texture2D texture)
        {
            this.Texture = texture;
            this.Position = position;
            this.Type = 1;
            this.Rotation = 0;

            EnemyBulletRec = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Texture.Width, this.Texture.Height);
        }

        public EnemyBullet(Vector2 position, Texture2D texture,int type,Texture2D flame)
        {
            this.Texture = texture;
            this.Position = position;
            this.Type = type;
            this.Rotation = 0;
            this.FlameTexture = flame;

            EnemyBulletRec = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Texture.Width, this.Texture.Height);
            FlameBulletRec = new Rectangle(0, 0, 15, 70);
        }

        public void draw(SpriteBatch Sprite)
        {
            if (Type == 1)
            {
                //Sprite.Draw(Texture, EnemyBulletRec, Color.White);
                Sprite.Draw(Texture, new Vector2(Position.X, Position.Y), null, Color.White, 0, Vector2.Zero, new Vector2(Share.StaticVarVector2D.scaleobj_Width, Share.StaticVarVector2D.scaleobj_Height), SpriteEffects.None, 0);
            }
            else if (Type == 2)
            {
                FlamePosition.X = Position.X;// +(Texture.Width / 2) - (FlameBulletRec.Width / 2);
                FlamePosition.Y = Position.Y;//+ (Texture.Height / 2) - (FlameBulletRec.Height/2);
                //Sprite.Draw(FlameTexture, FlamePosition, FlameBulletRec, Color.White, Rotation, new Vector2((Texture.Width / 2) + 2, 0), 1f, SpriteEffects.None, 0);
                Sprite.Draw(FlameTexture, new Vector2(FlamePosition.X , FlamePosition.Y ), FlameBulletRec, Color.White, Rotation, new Vector2(((Texture.Width* Share.StaticVarVector2D.scaleobj_Width) / 2) + 2, 0), new Vector2(Share.StaticVarVector2D.scaleobj_Width, Share.StaticVarVector2D.scaleobj_Height), SpriteEffects.None, 0);
                //Sprite.Draw(Texture, EnemyBulletRec, null, Color.White, Rotation, new Vector2(Texture.Width / 2, Texture.Height), SpriteEffects.None, 0);
                Sprite.Draw(Texture, new Vector2(Position.X, Position.Y), null, Color.White, Rotation, new Vector2((Texture.Width * Share.StaticVarVector2D.scaleobj_Width) / 2, Texture.Height * Share.StaticVarVector2D.scaleobj_Height), new Vector2(Share.StaticVarVector2D.scaleobj_Width, Share.StaticVarVector2D.scaleobj_Height), SpriteEffects.None, 0);
            }
        }

        public void update(GameTime gametime)
        {
            if (Type == 1)
            {
                Position.Y = Position.Y + (12f * Share.StaticVarVector2D.scaleobj_Height);
                //EnemyBulletRec = new Rectangle((int)(this.Position.X ), (int)(this.Position.Y), (int)(this.Texture.Width), (int)(this.Texture.Height));
                EnemyBulletRec = new Rectangle((int)(this.Position.X), (int)(this.Position.Y ), (int)(this.Texture.Width ), (int)(this.Texture.Height ));
            }

            else if (Type == 2)
            {
                //*** donbale kardane moshak***
                if (hit == true)
                {
                    Position = MoveEnemy.SeekGoOverThere(this.Position, 9f,ref Rotation);
                }

                if (hit == false && Position.Y +100 < Share.StaticVarVector2D.PositionStaticJet.Y) /* 100 gozashtim ke moshak az ye hadi balatar az jet bashe va if dovom be kar biofte*/
                {
                    Position = MoveEnemy.SeekBullet(this.Position, 9f, ref Rotation);
                }
                else
                {
                    hit = true;
                }
                //***               ***
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

                FlameBulletRec = new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y);
                //EnemyBulletRec = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Texture.Width, this.Texture.Height);
                EnemyBulletRec = new Rectangle((int)(this.Position.X /** Share.StaticVarVector2D.scaleobj_Width*/), (int)(this.Position.Y /** Share.StaticVarVector2D.scaleobj_Height*/), (int)(this.Texture.Width /** Share.StaticVarVector2D.scaleobj_Width*/), (int)(this.Texture.Height /** Share.StaticVarVector2D.scaleobj_Height*/));
            }
        }
    }
}
