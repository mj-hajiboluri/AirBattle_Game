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

namespace nabarde_havayi.Share
{
    class BulletJetStatic
    {
        public static List<PlayerBullet> newlistBulletJet = new List<PlayerBullet>();

        public static void AddBulletJet(Texture2D newTexture, Vector2 newPosition, int newDestruction, Color newColor)
        {
            PlayerBullet BulletJet = new PlayerBullet(newTexture, newPosition, newDestruction, newColor);
            newlistBulletJet.Add(BulletJet);
        }

        public static void RemoveBulletJet(/*GameWindow window*/) // baraye hazve golole ha bad az kharej shodan az safhe
        {
            for (int i = 0; i < newlistBulletJet.Count; i++)
            {
                if (newlistBulletJet[i].active == false)
                {
                    newlistBulletJet.RemoveAt(i);
                }
            }
        }
    }
}
