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
    class ExplodeStatic
    {
        public static List<Explode> newlistExplode = new List<Explode>();

        public static void AddExplode(Texture2D newTexture, Vector2 newposition,Vector2 newpositionJet,int newwidhtJet,int newheightJet)
        {
            Explode enfejarJet = new Explode(newTexture, newposition, newpositionJet, newwidhtJet, newheightJet,1);
            newlistExplode.Add(enfejarJet);
        }

        public static void AddExplodeBulletJet(Texture2D newTexture, Vector2 newposition)
        {
            Explode enfejargolole = new Explode(newTexture, newposition, 2);
            newlistExplode.Add(enfejargolole);
        }

        public static void RemoveExplode()//anhayi ke animation enfejareshan be etmam reside ra az list hazf mikonad
        {
            for (int i = 0; i < newlistExplode.Count; i++)
            {
                if (newlistExplode[i].FlagEndAnimation == 0)
                {
                    newlistExplode.RemoveAt(i);
                }
            }
        }
    }
}
