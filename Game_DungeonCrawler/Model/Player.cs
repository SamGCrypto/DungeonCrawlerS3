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

        private Items _itemInHand;
        private JobPositionTitle _jobPosition;

        private List<Location> _locationsVisited;
        private ObservableCollection<GameItemQuantity> _inventory;
        private ObservableCollection<GameItemQuantity> _potions;
        private ObservableCollection<GameItemQuantity> _tools;
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
        public int Wealth { get; set; }
        public ObservableCollection<GameItemQuantity> Inventory { get; set; }
        public ObservableCollection<GameItemQuantity> Potions { get; set; }
        public ObservableCollection<GameItemQuantity> Tools { get; set; }
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
        public int XP
        {
            get { return _xp; }
            set { _xp = value; }
        }
        public Items ItemInHand
        {
            get { return _itemInHand; }
            set { _itemInHand = value; }
        }
        #endregion
        #region CONSTRUCTORS
        public Player()
        {
            _locationsVisited = new List<Location>();
            _inventory = new ObservableCollection<GameItemQuantity>();
            _tools = new ObservableCollection<GameItemQuantity>();
            _potions = new ObservableCollection<GameItemQuantity>();
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
            foreach (var gameItemQuantity in _inventory)
            {
                if (gameItemQuantity._gameItem is Potion) Potions.Add(gameItemQuantity);
                if (gameItemQuantity._gameItem is Tool) Tools.Add(gameItemQuantity);
            }
        }
        public void CalculateWealth()
        {
            Wealth = _inventory.Sum(i => i._gameItem.Value*i._quantity);
        }

        public void AddGameItemToInventory(GameItemQuantity selectedItemQuantity)
        {
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i._gameItem.Id == selectedItemQuantity._gameItem.Id);
            if (selectedItemQuantity == null)
            {
                GameItemQuantity newGameItemQ = new GameItemQuantity();
                newGameItemQ._gameItem = selectedItemQuantity._gameItem;
                newGameItemQ._quantity = 1;

                _inventory.Add(newGameItemQ);
            }
            else
            {
                gameItemQuantity._quantity++;
            }
            UpdateInventoryCat();
        }

        public void RemoveItemQuantityFromInventory(GameItemQuantity selectedQuantity)
        {
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i._gameItem.Id == selectedQuantity._gameItem.Id);
            if(gameItemQuantity != null)
            {
                if(selectedQuantity._quantity == 1)
                {
                    _inventory.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity._quantity--;
                }
            }
        }
        public bool LocationVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }
        #endregion
    }
}
