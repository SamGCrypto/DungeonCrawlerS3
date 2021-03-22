using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_DungeonCrawler.Model
{
    public class GameItemQuantity
    {
        public GameItem _gameItem { get; set; }
        public int _quantity { get; set; }

        public GameItemQuantity()
        {

        }
        public GameItemQuantity(GameItem gameItem, int quantity)
        {
            _gameItem = gameItem;
            _quantity = quantity;
        }
    }
}
