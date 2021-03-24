using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_DungeonCrawler.Model;
using static Game_DungeonCrawler.Model.Character;

namespace Game_DungeonCrawler.Model
{
    public class Location:ObservableObject
    {
        #region PROPERTIES
        protected int _Id;
        protected Location _currentLocation;
        protected string _locatName;
        protected string _descript;
        protected bool _accessGranted;
        protected int _xpGranted;
        protected int _xpReq;
        protected Items _reqItem;
        protected Items _itemAcq;
        protected int _hpAffected;
        protected string _msg;
        protected int _gold;
        protected ObservableCollection<GameItem> _gameItem;
        #endregion
        #region FIELDS

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public int RequiredToolById { get; set; }
        public int HPAffected
        {
            get { return _hpAffected; }
            set { _hpAffected = value; }
        }
        public int XPGained
        {
            get { return _xpGranted; }
            set { _xpGranted = value; }
        }
        public string LocatName
        {
            get { return _locatName; }
            set { _locatName = value; }
        }
        public string AreaDescription
        {
            get { return _descript; }
            set { _descript = value; }
        }
        public bool AccessLocation
        {
            get { return _accessGranted; }
            set { _accessGranted = value; }
        }
        public int XPRequired
        {
            get { return _xpReq; }
            set { _xpReq = value; }
        }
        public string Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
        public int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }
        public ObservableCollection<GameItem> GameItem
        {
            get { return _gameItem; }
            set { _gameItem = value; }
        }
        #endregion

        #region METHOD
        public Location()
        {
            _gameItem = new ObservableCollection<GameItem>();
        }
        public bool IsAccessable(int playerXP)    
        {
            return playerXP >= _xpReq ? true : false; 
        }
        public void UpdateLocationItems()
        {
            ObservableCollection<GameItem> updatedLocationItems = new ObservableCollection<GameItem>();
            foreach (GameItem GameItem in _gameItem)
            {
                updatedLocationItems.Add(GameItem);
            }
            GameItem.Clear();
            foreach(GameItem gameItem in updatedLocationItems)
            {
                GameItem.Add(gameItem);
            }
        }
        public void RemoveItemsFromLocation(GameItem selectedItem)
        {
            if(selectedItem != null)
            {
                _gameItem.Remove(selectedItem);
            }
            UpdateLocationItems();
        }
        public void AddGameItemToLocation(GameItem selectedItem)
        {
            if (selectedItem != null)
            {
                _gameItem.Add(selectedItem);
            }
            UpdateLocationItems();
        }

        public void Move(Location location)
        {
            _currentLocation = location;
        }
        #endregion

    }
}
