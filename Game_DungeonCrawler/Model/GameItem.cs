using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_DungeonCrawler.Model
{
    public abstract class GameItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public int Xp { get; set; }
        public string UserMsg { get; set; }

        public virtual string InformationString()
        {
            return $"{Name}: {Description}/n Value {Value}";
        }
        public string Information
        {
            get{
                return InformationString();
            }
        }
        public GameItem(int id, string name, string descipt, int value, int xp, string userMsg)
        {
            Id = id;
            Name = name;
            Description = descipt;
            Value = value;
            Xp = xp;
            UserMsg = userMsg;
        }
    }
}
