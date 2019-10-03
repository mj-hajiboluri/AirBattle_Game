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
    class BulletStatic
    {
      
        public static List<EnemyBullet.EnemyBullet> newlistBullet = new List<EnemyBullet.EnemyBullet>(); //sakhte yek static baraye inke betavan golole hara pas enfejare doshman negah dasht

        public static void AddBullet(Texture2D newTexture,Vector2 newPosition) // ezafe kardane yek golole be list
        {
            EnemyBullet.EnemyBullet bullet = new EnemyBullet.EnemyBullet(newPosition, newTexture);
            newlistBullet.Add(bullet);
        }

        public static void AddBomb(Texture2D newTexture, Vector2 newPosition, int newType,Texture2D newFlame) // ezafe kardane yek golole be list
        {
            EnemyBullet.EnemyBullet bomb = new EnemyBullet.EnemyBullet(newPosition, newTexture, newType, newFlame);
            newlistBullet.Add(bomb);
        }

        public static void CheckRange(GameWindow window) // baraye hazve golole ha bad az kharej shodan az safhe
        {
            foreach (EnemyBullet.EnemyBullet item in newlistBullet)
            {
                if (item.Position.Y > window.ClientBounds.Height)
                {
                    item.EnableEnemyBullet = false;
                }
            }
            for (int i = 0; i < newlistBullet.Count; i++)
            {
                if (newlistBullet[i].EnableEnemyBullet == false)
                {
                    newlistBullet.RemoveAt(i);
                }
            }
        }

        

        

    }
}
