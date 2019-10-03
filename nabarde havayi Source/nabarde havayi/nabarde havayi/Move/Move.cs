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

namespace nabarde_havayi.Move
{
    class Move
    {
        //public Vector2 Position;

        public Vector2 GoAhead(Vector2 position,float speed)
        {
            position.Y = position.Y + (speed * Share.StaticVarVector2D.scaleobj_Height);
            return position;
        }

        public Vector2 Seek(Vector2 position, float speed, float speeddown,int width,int height)
        {
            Vector2 tempPosition = new Vector2(position.X , position.Y);
            tempPosition.X = (Share.StaticVarVector2D.PositionStaticJet.X-((Share.StaticVarTexture.StaticTexture_Jet.Width*Share.StaticVarVector2D.scaleobj_Width) / 2)) - (position.X - ((Share.StaticVarTexture.StaticTexture_Enemy_red.Width * Share.StaticVarVector2D.scaleobj_Width) / 2));
            tempPosition.Y = position.Y;// +0.1f;//Share.StaticVarVector2D.PositionStaticJet.Y-position.Y;
            tempPosition.Normalize();
            //float tLength = tempPosition.Length();
            //tempPosition.X = tempPosition.X / tLength;
            //tempPosition.Y = tempPosition.Y / tLength;
            tempPosition.X *= (speed * Share.StaticVarVector2D.scaleobj_Height);
            //tempPosition.Y *= speed;
            
            position.X += (float)(Math.Round(tempPosition.X));  // baraye inke digar dar kharej az method niyaz nabashad ta ba khode position jam shavad.
            position.Y += tempPosition.Y + speeddown;

            

            //position.X=
            return position;
        }

        public Vector2 SeekBullet(Vector2 position, float speed,ref float rotation)
        {
            Vector2 tempPosition = new Vector2(position.X, position.Y);
            tempPosition.X = Share.StaticVarVector2D.PositionStaticJet.X - position.X;
            tempPosition.Y = Share.StaticVarVector2D.PositionStaticJet.Y-position.Y;
            tempPosition.Normalize();
            //float tLength = tempPosition.Length();
            //tempPosition.X = tempPosition.X / tLength;
            //tempPosition.Y = tempPosition.Y / tLength;
            tempPosition.X *= (speed* Share.StaticVarVector2D.scaleobj_Width);
            tempPosition.Y *= (speed* Share.StaticVarVector2D.scaleobj_Height);

            rotation = (float)Math.Atan2(Share.StaticVarVector2D.PositionStaticJet.X - (position.X), -Share.StaticVarVector2D.PositionStaticJet.Y + (position.Y));

            position.X += tempPosition.X;
            position.Y += tempPosition.Y;

            

            
            return position;
        }

        public Vector2 SeekGoOverThere(Vector2 position, float speed, ref float rotation)
        {
            //double rot = Convert.ToDouble(rotation);
            
            position.X = position.X + (speed * (float)(Math.Sin(rotation)));
            position.Y = position.Y - (speed * (float)(Math.Cos(rotation)));
            //Vector2 tempPosition = new Vector2(position.X, position.Y);
            //tempPosition.X = 1000;
            //tempPosition.Y = 2000;
            //tempPosition.Normalize();
            ////float tLength = tempPosition.Length();
            ////tempPosition.X = tempPosition.X / tLength;
            ////tempPosition.Y = tempPosition.Y / tLength;
            //tempPosition.X *= (speed * Share.StaticVarVector2D.scaleobj_Width);
            //tempPosition.Y *= (speed * Share.StaticVarVector2D.scaleobj_Height);

            //rotation = (float)Math.Atan2(1000 - (position.X), -2000 + (position.Y));
            //position.Normalize();
            //position.X += tempPosition.X;
            //position.Y += tempPosition.Y;

            //position.X=
            return position;
        }

        public Vector2 Arrive(Vector2 position, float speed)
        {
            Vector2 tempPosition = new Vector2(position.X, position.Y);
            tempPosition.X = Share.StaticVarVector2D.PositionStaticJet.X - position.X;
            tempPosition.Y = Share.StaticVarVector2D.PositionStaticJet.Y - position.Y;

            tempPosition.X *= (speed * Share.StaticVarVector2D.scaleobj_Width);
            tempPosition.Y *= (speed * Share.StaticVarVector2D.scaleobj_Height);

            position.X += tempPosition.X;
            position.Y += tempPosition.Y;

            return position;
        }
    }
}
