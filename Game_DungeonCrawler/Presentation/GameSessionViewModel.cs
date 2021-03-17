using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Game_DungeonCrawler.Model;
using Game_DungeonCrawler;

namespace Game_DungeonCrawler.Presentation
{
    public class GameSessionViewModel: ObservableObject
    {
        #region FIELDS
        private Player _player;
        private Location _nLocation, _sLocation, _eLocation, _wLocation, _lLocation, _uLocation;
        private Map _cavernMap;
        private Location _currentLocation;
        #endregion
        #region PROPERTIES
        #region GETTER_SETTER_DISPLAY_VALUE
        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public string MsgDis
        {
            get { return _currentLocation.Msg; }
        }
        public Map GameMap
        {
            get { return _cavernMap; }
            set { _cavernMap = value; }
        }
        #endregion
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
            }
        }
        public Location NLocation
        {
            get { return _nLocation; }
            set { 
                _nLocation= value;
                OnPropertyChanged(nameof(NLocation));
                OnPropertyChanged(nameof(northLocationTest));
            }
        }
        public Location WLocation
        {
            get { return _wLocation; }
            set { 
                _wLocation= value;
                OnPropertyChanged(nameof(WLocation));
                OnPropertyChanged(nameof(westLocationTest));
            }
        }
        public Location ELocation
        {
            get { return _eLocation; }
            set {
                _eLocation = value;
                OnPropertyChanged(nameof(ELocation));
                OnPropertyChanged(nameof(eastLocationTest));
            }
        }
        public Location SLocation
        {
            get { return _sLocation; }
            set { 
                _sLocation= value;
                OnPropertyChanged(nameof(SLocation));
                OnPropertyChanged(nameof(southLocationTest));
            }
        }
        public Location ULocation
        {
            get { return _uLocation; }
            set {
                _uLocation = value;
                OnPropertyChanged(nameof(ULocation));
                OnPropertyChanged(nameof(upLocationTest));
            }
        }
        public Location LLocation
        {
            get { return _lLocation; }
            set { 
                _lLocation = value;
                OnPropertyChanged(nameof(LLocation));
                OnPropertyChanged(nameof(lowerLocationTest));
            }
        }
        #region NORTH_LOCATION
        public bool northLocationTest
        {
            get
            {
                if (NLocation != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void MoveNorth()
        {
            if (northLocationTest)
            {
                _cavernMap.North();
                CurrentLocation = _cavernMap.CurrentLocation;
                updateCavern();
                playerHealthAffected(CurrentLocation);
                XPAffected(CurrentLocation);
            }
        }
        #endregion
        #region SOUTH_LOCATION
        public bool southLocationTest
        {
            get
            {
                if (SLocation != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void MoveSouth()
        {
            if (southLocationTest)
            {
                _cavernMap.South();
                CurrentLocation = _cavernMap.CurrentLocation;
                updateCavern();
                playerHealthAffected(CurrentLocation);
                XPAffected(CurrentLocation);
            }
        }
        #endregion
        #region EAST_LOCATION
        public bool eastLocationTest
        {
            get
            {
                if (ELocation != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void MoveEast()
        {
            if (eastLocationTest)
            {
                _cavernMap.East();
                CurrentLocation = _cavernMap.CurrentLocation;
                updateCavern();
                playerHealthAffected(CurrentLocation);
                XPAffected(CurrentLocation);
            }
        }
        #endregion
        #region WEST_LOCATION
        public bool westLocationTest
        {
            get
            {
                if (WLocation != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void MoveWest()
        {
            if (westLocationTest)
            {
                _cavernMap.West();
                CurrentLocation = _cavernMap.CurrentLocation;
                updateCavern();
                playerHealthAffected(CurrentLocation);
                XPAffected(CurrentLocation);
            }
        }
        #endregion
        #region UPPER_LOCATION
        public bool upLocationTest
        {
            get
            {
                if (ULocation != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void MoveUp()
        {
            if (upLocationTest)
            {
                _cavernMap.Up();
                CurrentLocation = _cavernMap.CurrentLocation;
                updateCavern();
                playerHealthAffected(CurrentLocation);
                XPAffected(CurrentLocation);
            }
        }

        #endregion
        #region LOWER_LOCATION
        public bool lowerLocationTest
        {
            get
            {
                if (LLocation != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void MoveDown()
        {
            if (lowerLocationTest)
            {
                _cavernMap.Down();
                CurrentLocation = _cavernMap.CurrentLocation;
                updateCavern();
                playerHealthAffected(CurrentLocation);
                XPAffected(CurrentLocation);
            }
        }
        #endregion
        #endregion
        #region CONSTRUCTORS
        public GameSessionViewModel()
        {

        }
        public GameSessionViewModel(Player player,
             Map cavernMap,
             GameMapCoordinates currentLocalCoordinates)
        {
            _player = player;

            _cavernMap = cavernMap;
            _cavernMap.CurrentLocalCoordinates = currentLocalCoordinates;
            _currentLocation = _cavernMap.CurrentLocation;
            initializeView();
        }

        #endregion
        #region METHODS
        public void updateCavern()
        {
            NLocation = null;
            SLocation = null;
            WLocation = null;
            ELocation = null;
            LLocation = null;
            ULocation = null;
            if(_cavernMap.northLoc()!= null)
            {
                Location nextNLoc = _cavernMap.northLoc();

                if(nextNLoc.AccessLocation == true|| playerXPReached(nextNLoc))
                {
                    NLocation = nextNLoc;
                }
            }
            if (_cavernMap.southLoc() != null)
            {
                Location nextSLoc = _cavernMap.southLoc();

                if (nextSLoc.AccessLocation == true || playerXPReached(nextSLoc))
                {
                    SLocation = nextSLoc;
                }
            }
            if (_cavernMap.westLoc() != null)
            {
                Location nextWLoc = _cavernMap.westLoc();

                if (nextWLoc.AccessLocation == true || playerXPReached(nextWLoc))
                {
                    WLocation = nextWLoc;
                }
            }
            if (_cavernMap.eastLoc() != null)
            {
                Location nextELoc = _cavernMap.eastLoc();

                if (nextELoc.AccessLocation == true || playerXPReached(nextELoc))
                {
                    ELocation = nextELoc;
                }
            }
            if (_cavernMap.upperLvlLoc() != null)
            {
                Location nextULLoc = _cavernMap.upperLvlLoc();

                if (nextULLoc.AccessLocation == true || playerXPReached(nextULLoc))
                {
                    ULocation = nextULLoc;
                }
            }
            if (_cavernMap.lowerLvlLoc() != null)
            {
                Location nextLLLoc = _cavernMap.lowerLvlLoc();

                if (nextLLLoc.AccessLocation == true || playerXPReached(nextLLLoc))
                {
                    LLocation = nextLLLoc;
                }
            }
        }
        private bool playerXPReached(Location selectedLocation)
        {
            if (selectedLocation.IsAccessable(_player.XP, _player.ItemInHand))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void playerHealthAffected(Location selectedLocation)
        {
            if (Player.Health > 0)
            {
                Player.Health -= selectedLocation.HPAffected;
            }else
            {
                if (Player.Lives >= 0)
                {
                    Player.Lives -= 1;
                }
                else
                {
                    MessageBox.Show("Game Over");
                }
            }
        }
        private void XPAffected(Location selectedLocation)
        {
            Player.XP += selectedLocation.XPGained;
        }
        private void initializeView()
        {
            updateCavern();
        }
        #endregion
        #region EVENTS

        #endregion
    }
}