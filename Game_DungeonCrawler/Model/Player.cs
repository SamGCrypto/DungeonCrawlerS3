using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_DungeonCrawler.Model
{
    public class Player:Character
    {
        #region ENUM
        public enum JobPositionTitle {
            Adventurer, 
            Missionary, 
            Knight, 
            Priest,
            Farmer,
            Peasant
        }
        #endregion
        #region FIELDS
        private int _lives;
        private int _health;
        private int _xp;
        private int _regen;
        private int _wealth;
        private int _atk;
        private int _def;
        private JobPositionTitle _jobPosition;
        private List<Location> _locationsVisited;

        private ObservableCollection<GameItem> _inventory;
        private ObservableCollection<GameItem> _potions;
        private ObservableCollection<GameItem> _tools;
        #endregion
        #region PROPERTIES
        public int Lives
        {
            get { return _lives; }
            set { 
                _lives = value;
                OnPropertyChanged(nameof(Lives));
            }
        }
        public int Regen
        {
            get { return _regen; }
            set { _regen = value; }
        }
        public JobPositionTitle JobPosition
        {
            get { return _jobPosition; }
            set { _jobPosition = value; }
        }
        public int Health
        {
            get { return _health; }
            set { 
                _health = value;
                OnPropertyChanged(nameof(Health));
            
            }
        }
        public int ATK
        {
            get { return _atk; }
            set
            {
                _atk = value;
                OnPropertyChanged(nameof(ATK));
            }
        }
        public int DEF
        {
            get { return _def; }
            set { 
                _def = value;
                OnPropertyChanged(nameof(DEF));
            }
        }
        public int Wealth
        {
            get { return _wealth; }
            set
            {
                _wealth = value;
                OnPropertyChanged(nameof(Wealth));
            }
        }
        public int XP
        {
            get { return _xp; }
            set { _xp = value; }
        }


        public ObservableCollection<GameItem> Inventory { 
            get {return _inventory; } 
            set {_inventory = value; } 
        }

        public ObservableCollection<GameItem> Potions
        {
            get { return _potions; }
            set { _potions = value; }
        }

        public ObservableCollection<GameItem> Tools
        {
            get { return _tools; }
            set { _tools = value; }
        }

        #endregion
        #region CONSTRUCTORS
        public Player()
        {
            _locationsVisited = new List<Location>();
            _inventory = new ObservableCollection<GameItem>();
            _tools = new ObservableCollection<GameItem>();
            _potions = new ObservableCollection<GameItem>();
        }
        #endregion
        #region METHODS

        public override string DefaultGreeting()
        {
            string article = "a";

            List<string> vowels = new List<string>() { "A", "E", "I", "O", "U" };

            if (vowels.Contains(_jobPosition.ToString().Substring(0, 1))){
                article = "an";
            }
            return article;
        }
        public void UpdateInventoryCat()
        {
            Potions.Clear();
            Tools.Clear();
            foreach (var itemGame in _inventory)
            {
                if (itemGame is Potion) Potions.Add(itemGame);
                if (itemGame is Tool) Tools.Add(itemGame);
            }
        }
        public void CalculateWealth()
        {
            Wealth = _inventory.Sum(i => i.Value);
        }
        public void AddItemToInventory(GameItem selectedItem)
        {
            if (selectedItem != null)
            {
                _inventory.Add(selectedItem);
                _xp += selectedItem.Xp;
            }
        }
        public void RemoveItemFromInventory(GameItem selectedItem)
        {
            if (selectedItem != null)
            {
                _inventory.Remove(selectedItem);
            }
        }
        #endregion
    }
}
