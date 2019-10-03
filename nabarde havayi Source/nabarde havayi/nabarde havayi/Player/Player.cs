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
    class Player
    {
    
        public Texture2D Texture;
        public Vector2 Position;

        public Vector2 globalPosition = Vector2.Zero;

        public Rectangle PlayerRec;
        public List<Rectangle> PlayerRecIntersect = new List<Rectangle>();

        public double X, Y = 0;
        public bool visible = true;

        public int health = 100;

        MouseState state;

        public Player(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.Position = position;

            PlayerRec = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Texture.Width, this.Texture.Height);
            PlayerRecIntersect.Add( new Rectangle((int)this.Position.X + 38, (int)this.Position.Y + 1, 8, 35));
            PlayerRecIntersect.Add( new Rectangle((int)this.Position.X + 32, (int)this.Position.Y + 36, 20, 81));
            PlayerRecIntersect.Add( new Rectangle((int)this.Position.X + 25, (int)this.Position.Y + 66, 36, 8));
            PlayerRecIntersect.Add( new Rectangle((int)this.Position.X + 17, (int)this.Position.Y + 74, 51, 7));
            PlayerRecIntersect.Add( new Rectangle((int)this.Position.X + 9, (int)this.Position.Y + 81, 67, 9));
            PlayerRecIntersect.Add( new Rectangle((int)this.Position.X, (int)this.Position.Y + 90, 85, 8));
            PlayerRecIntersect.Add( new Rectangle((int)this.Position.X + 17, (int)this.Position.Y + 111, 50, 12));
        }

        public void barkhord()
        {

            if (visible == true)
                Share.ExplodeStatic.AddExplode(Share.StaticVarTexture.StaticTexture_Jet, Position, Position, Texture.Width, Texture.Height);
        }

        public void draw(SpriteBatch Sprite)
        {
                //Sprite.Draw(Texture, PlayerRec, Color.White);
            Sprite.Draw(Texture, new Vector2(globalPosition.X, globalPosition.Y), null, Color.White, 0, Vector2.Zero, new Vector2(Share.StaticVarVector2D.scaleobj_Width, Share.StaticVarVector2D.scaleobj_Height), SpriteEffects.None, 0);
            //Sprite.Draw(Texture, PlayerRec, Color.Yellow);
            //Sprite.Draw(Texture, PlayerRecIntersect[0], Color.Red);
            //Sprite.Draw(Texture, PlayerRecIntersect[1], Color.Red);
            //Sprite.Draw(Texture, PlayerRecIntersect[2], Color.Red);
            //Sprite.Draw(Texture, PlayerRecIntersect[3], Color.Red);
            //Sprite.Draw(Texture, PlayerRecIntersect[4], Color.Red);
            //Sprite.Draw(Texture, PlayerRecIntersect[5], Color.Red);
            //Sprite.Draw(Texture, PlayerRecIntersect[6], Color.Red);
        }

        public void update(GameTime gametime, int gameWidth, int gameHeight)
        {
            //baraye inke hvapeyma az safhe kharej nashavad
            state = Mouse.GetState();
            X = state.X;
            Y = state.Y;
            //X /= 0.5;
            //Y /= 0.5;
            if (X - (PlayerRec.Width / 2) < 0)
            {
                X = (int)(PlayerRec.Width / 2);
            }
            if (X + (PlayerRec.Width / 2) > gameWidth)
            {
                X = (gameWidth - (PlayerRec.Width / 2));
            }
            if (Y + (PlayerRec.Height / 2) > gameHeight)
            {
                Y = gameHeight - (PlayerRec.Height / 2);
            }

            Position.X = (float)X;//baraye ferestadane position havapeyma bad az teste anjam shode be barkhord() baraye explosionjet
            Position.Y = (float)Y;

            Share.StaticVarVector2D.PositionStaticJet = Position;

            globalPosition.X = (float)(X - ((Texture.Width  * Share.StaticVarVector2D.scaleobj_Width)/ 2));
            globalPosition.Y = (float)(Y - ((Texture.Height * Share.StaticVarVector2D.scaleobj_Height) / 2));

            //Share.StaticVarVector2D.PositionStaticJet = globalPosition;

            PlayerRec = new Rectangle((int)(globalPosition.X), (int)(globalPosition.Y), (int)(this.Texture.Width* Share.StaticVarVector2D.scaleobj_Width), (int)(this.Texture.Height* Share.StaticVarVector2D.scaleobj_Height));
            PlayerRecIntersect[0] = new Rectangle((int)(this.globalPosition.X + (38* Share.StaticVarVector2D.scaleobj_Width)), (int)(this.globalPosition.Y + (1* Share.StaticVarVector2D.scaleobj_Height)), (int)(8* Share.StaticVarVector2D.scaleobj_Width), (int)(35* Share.StaticVarVector2D.scaleobj_Height));
            PlayerRecIntersect[1] = new Rectangle((int)(this.globalPosition.X + (32* Share.StaticVarVector2D.scaleobj_Width)), (int)(this.globalPosition.Y + (36* Share.StaticVarVector2D.scaleobj_Height)), (int)(20* Share.StaticVarVector2D.scaleobj_Width), (int)(81* Share.StaticVarVector2D.scaleobj_Height));
            PlayerRecIntersect[2] = new Rectangle((int)(this.globalPosition.X + (25* Share.StaticVarVector2D.scaleobj_Width)), (int)(this.globalPosition.Y + (66* Share.StaticVarVector2D.scaleobj_Height)), (int)(36* Share.StaticVarVector2D.scaleobj_Width), (int)(8* Share.StaticVarVector2D.scaleobj_Height));
            PlayerRecIntersect[3] = new Rectangle((int)(this.globalPosition.X + (17* Share.StaticVarVector2D.scaleobj_Width)), (int)(this.globalPosition.Y + (74* Share.StaticVarVector2D.scaleobj_Height)), (int)(51* Share.StaticVarVector2D.scaleobj_Width), (int)(7* Share.StaticVarVector2D.scaleobj_Height));
            PlayerRecIntersect[4] = new Rectangle((int)(this.globalPosition.X + (9* Share.StaticVarVector2D.scaleobj_Width)), (int)(this.globalPosition.Y + (81* Share.StaticVarVector2D.scaleobj_Height)), (int)(67* Share.StaticVarVector2D.scaleobj_Width), (int)(9* Share.StaticVarVector2D.scaleobj_Height));
            PlayerRecIntersect[5] = new Rectangle(((int)this.globalPosition.X), (int)(this.globalPosition.Y + (90* Share.StaticVarVector2D.scaleobj_Height)), (int)(85* Share.StaticVarVector2D.scaleobj_Width), (int)(8* Share.StaticVarVector2D.scaleobj_Height));
            PlayerRecIntersect[6] = new Rectangle((int)(this.globalPosition.X + (17* Share.StaticVarVector2D.scaleobj_Width)), (int)(this.globalPosition.Y + (111* Share.StaticVarVector2D.scaleobj_Height)), (int)(50* Share.StaticVarVector2D.scaleobj_Width), (int)(12* Share.StaticVarVector2D.scaleobj_Height));
        }
    }
}
