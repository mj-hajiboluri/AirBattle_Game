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
    class Explode
    {
        Texture2D Texture;
        public Vector2 Position, PositionJet;
        int WidthJet, HeightJet;

        public Rectangle rectBase;

        Point frameSize = new Point(100, 100);
        Point currentFrame = new Point(0, 0);
        Point sheetSize = new Point(3, 3);

        public int FlagEndAnimation = 1;

        public int Type;

        public Explode(Texture2D texture, Vector2 position,Vector2 positionJet,int widthJet,int heightJet,int type)
        {
            this.Texture = texture;
            this.Position = position;
            this.PositionJet = positionJet;
            this.WidthJet = widthJet;
            this.HeightJet = heightJet;
            this.Type = type;

            rectBase = new Rectangle(0, 0, 100, 100);
        }

        public Explode(Texture2D texture, Vector2 position, int type)
        {
            this.Texture = texture;
            this.Position = position;
            this.Type = type;

            rectBase = new Rectangle(0, 0, 100, 100);
        }

        public void draw(SpriteBatch sprite)
        {
            if (Type == 1)
            {
                Position.X = PositionJet.X - (WidthJet / 2) - (rectBase.Width / 2);
                Position.Y = PositionJet.Y - (HeightJet / 2) - (rectBase.Height / 2);
                sprite.Draw(Texture, Position, rectBase, Color.White, 0, Vector2.Zero, 2f, SpriteEffects.None, 0);  
            }

            else if (Type == 2)
            {
                //Position.X = Position.X - (frameSize.X / 2);
                //Position.Y = Position.Y - (frameSize.Y / 2);
                sprite.Draw(Texture, new Vector2(Position.X - ((frameSize.X / 2) * Share.StaticVarVector2D.scaleobj_Width), Position.Y - ((frameSize.Y / 2) * Share.StaticVarVector2D.scaleobj_Height)), rectBase, Color.White, 0, Vector2.Zero, new Vector2(Share.StaticVarVector2D.scaleobj_Width, Share.StaticVarVector2D.scaleobj_Height), SpriteEffects.None, 0);
            }
            
        }

        public void update(GameTime gametime1)
        {
            if (currentFrame.X == sheetSize.X - 1 && currentFrame.Y == sheetSize.Y - 1)
                FlagEndAnimation = 0;

            ++currentFrame.X;
            if (currentFrame.X >= sheetSize.X)
            {
                currentFrame.X = 0;
                ++currentFrame.Y;
                if (currentFrame.Y >= sheetSize.Y)
                    currentFrame.Y = 0;
            }

            rectBase = new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y);
        }
    }
}
