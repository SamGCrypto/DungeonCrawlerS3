using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_DungeonCrawler.Model
{
    public class Potion : GameItem
    {
        public int HealthChange { get; set; }
        public int LivesChange { get; set; }

        public Potion(int id, string name, int value, int healthChanged, int liveChanged, string description, int xp, string userMsg="")
            :base(id, name, description, value, xp, userMsg)
        {
            HealthChange = healthChanged;
            LivesChange = liveChanged;
        }
        public override string InformationString()
        {
            if (HealthChange != 0)
            {
                return $"{Name}: {Description}:\n{HealthChange}";
            }else if(LivesChange!=0)
            {
                return $"{Name}: {Description}:\n{LivesChange}";
            }
            else
            {
                return $"{Name}: {Description}";
            }
        }


    }
}
