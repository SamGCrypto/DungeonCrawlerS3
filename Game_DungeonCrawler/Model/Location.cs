﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_DungeonCrawler.Model;
using static Game_DungeonCrawler.Model.Character;

namespace Game_DungeonCrawler.Model
{
    public class Location
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
        #endregion
        #region FIELDS

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
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
        public Items itemAcq{
            get { return _itemAcq; }
            set { _itemAcq = value; }
            }
        #endregion

        #region METHOD
        public bool IsAccessable(int playerXP, Items items)    
        {
            return playerXP >= _xpReq ? true : false|| items == _reqItem; 
        }

        public void Move(Location location)
        {
            _currentLocation = location;
        }
        #endregion

    }
}