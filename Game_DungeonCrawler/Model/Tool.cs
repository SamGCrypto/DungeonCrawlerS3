using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_DungeonCrawler.Model
{
    public class Tool : GameItem
    {
        public enum UseAffect
        {
            OPEN_LOCATION,
            KILL_ENEMY,
            HEAL_PLAYER
        }
        public UseAffect ItemAffect{ get; set; }

        public Tool(int id, string name, int value, UseAffect itemAffect, string description, int xp, string userMsg)
            : base(id, name, description, value, xp, userMsg){
                ItemAffect = itemAffect; 
            }

        public override string InformationString()
        {
            return $"{Name}:{Description}\n Value: {Value}";
        }
    }
}
