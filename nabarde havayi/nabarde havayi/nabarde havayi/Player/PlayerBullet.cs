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

namespace nabarde_havayi
{
    class PlayerBullet
    {
        
        public Texture2D Texture;
        public Vector2 Position;

        public int Y = 0; //,X,
            
        public Rectangle PlayerBulletRec;

        public bool active = true;

        public int Destruction;

        public Color ColorBulletJet;

        public PlayerBullet(Texture2D texture, Vector2 position,int destruction,Color color)
        {
            this.Texture = texture;
            this.Position = position;
            this.Destruction = destruction;
            this.ColorBulletJet = color;

            PlayerBulletRec = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Texture.Width, this.Texture.Height);
        }

        public void draw(SpriteBatch Sprite)
        {
            if (active == true)
            {
                //Sprite.Draw(Texture, PlayerBulletRec, ColorBulletJet);
                Sprite.Draw(Texture, new Vector2(Position.X, Position.Y), PlayerBulletRec, Color.White, 0, Vector2.Zero, new Vector2(Share.StaticVarVector2D.scaleobj_Width, Share.StaticVarVector2D.scaleobj_Height), SpriteEffects.None, 0);
            }
           
        
        }

        public void update(GameTime gametime)//, int gameWidth, int gameHeight, int jetWidth, int jetHeight)
        {
            
            if (active == true)
            {
                Position.Y = Position.Y - (int)(20 * Share.StaticVarVector2D.scaleobj_Height);
                PlayerBulletRec.Y = PlayerBulletRec.Y - (int)(20 * Share.StaticVarVector2D.scaleobj_Height);
            }

            //reset kardane golole vaghte ke az yek hadi gozasht az beyn bere
            if (Position.Y < -10)
            {
                
                active = false;
            }

            
        }
    }
}
