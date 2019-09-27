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

namespace nabarde_havayi.Share
{
    class EnemyStatic
    {
        public static List<Enemy> ListEnemy = new List<Enemy>();
        public static List<EnemyBomb> ListEnemyBomb = new List<EnemyBomb>();
        public static Random rand = new Random();

        public static void addEnemyRed(Vector2 Position)
        {
            ListEnemy.Add(new Enemy(StaticVarTexture.StaticTexture_Enemy_red, Position, StaticVarTexture.StaticTexture_Game_Explode, Vector2.Zero, StaticVarTexture.StaticTexture_bomb, rand.Next(700, 1700)));
            EnemyStaticVariable.ListEnemyCount += 1;
        }

        public static void addEnemyBomb(Vector2 Position)
        {
            ListEnemyBomb.Add(new EnemyBomb(StaticVarTexture.StaticTexture_Enemy_Bomb, Position, StaticVarTexture.StaticTexture_Game_Explode, Vector2.Zero, StaticVarTexture.StaticTexture_EnemyMissile, StaticVarTexture.StaticTexture_FlameMissile,rand.Next(2200,3600)));//EnemyMissile
            EnemyStaticVariable.ListEnemyBombCount += 1;
        }

        public static void add()
        {
            EnemyStaticVariable.ListEnemyCount = 2;
            EnemyStaticVariable.ListEnemyBombCount = 2;

            for (int i = 0; i < EnemyStaticVariable.ListEnemyCount; i++)
            {
                ListEnemy.Add(new Enemy(StaticVarTexture.StaticTexture_Enemy_red, new Vector2(i * 160, i * 100), StaticVarTexture.StaticTexture_Game_Explode, Vector2.Zero, StaticVarTexture.StaticTexture_bomb, rand.Next(700, 1700)));
            }

            for (int i = 0; i < EnemyStaticVariable.ListEnemyBombCount; i++)
            {
                ListEnemyBomb.Add(new EnemyBomb(StaticVarTexture.StaticTexture_Enemy_Bomb, new Vector2(i * 160, i * 100), StaticVarTexture.StaticTexture_Game_Explode, Vector2.Zero, StaticVarTexture.StaticTexture_EnemyMissile, StaticVarTexture.StaticTexture_FlameMissile,rand.Next(1800,2600)));//EnemyMissile
            }
        }

    }
}
