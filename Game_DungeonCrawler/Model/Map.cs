using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_DungeonCrawler.Data;

namespace Game_DungeonCrawler.Model
{
    public class Map
    {
        #region FIELDS
        private Location[,,] _mapLocation;
        private int _maxRow, _maxColumn, _lvl;
        private GameMapCoordinates _currentLocationCoordinates;
        private List<GameItem> _standardItems;

        #endregion
        #region PROPERTIES
        public Location[,,] MapLocation
        {
            get { return _mapLocation; }
            set { _mapLocation = value; }
        }
        public GameMapCoordinates CurrentLocalCoordinates
        {
            get { return _currentLocationCoordinates; }
            set { _currentLocationCoordinates = value; }
        }
        public Location CurrentLocation
        {
            get { return _mapLocation[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column, _currentLocationCoordinates.Level]; }
        }
        public List<GameItem> StandardItems { get {return _standardItems; } set {_standardItems = value; } }

        public int MaxRow
        {
            get { return _maxRow; }
            set { _maxRow = value; }
        }
        public int MaxColumn
        {
            get { return _maxColumn; }
            set { _maxColumn = value; }
        }
        public int Lvl
        {
            get { return _lvl; }
            set { _lvl = value; }
        }
        public ObservableCollection<Location> AccessableLocation {
            get {
                ObservableCollection<Location> accessibleLocation= new ObservableCollection<Location>();
                foreach(var location in _mapLocation)
                {
                    accessibleLocation.Add(location);
                }
                return accessibleLocation;
            }
        }

        #endregion

        #region CONSTRUCTOR
        public Map(int Row, int Column, int Level)
        {
            _maxRow = Row;
            _maxColumn = Column;
            _lvl = Level;
            _mapLocation = new Location[Row, Column, Level];
        }

        #endregion

        #region METHODS
        #region ROW MOFICATION METHODS
        public void North()
        {
            if (_currentLocationCoordinates.Row >=0)
            {
                _currentLocationCoordinates.Row += 1;
            }
        }
        public void South()
        {
            if (_currentLocationCoordinates.Row < _maxRow-1)
            {
                _currentLocationCoordinates.Row -= 1;
            }
        }
        public void West()
        {
            if (_currentLocationCoordinates.Column >=0)
            {
                _currentLocationCoordinates.Column += 1;
            }
        }
        public void East()
        {
            if (_currentLocationCoordinates.Column < _maxColumn - 1)
            {
                _currentLocationCoordinates.Column -= 1;
            }
        }
        public void Up()
        {
            if (_currentLocationCoordinates.Level < _lvl - 1)
            {
                _currentLocationCoordinates.Level += 1;
            }
        }
        public void Down()
        {
            if (_currentLocationCoordinates.Level >= 0)
            {
                _currentLocationCoordinates.Level -= 1;
            }
        }
        #endregion
        #region CHECK REGIONS
        public Location northLoc()
        {
            Location northLoc = null;
            if (_currentLocationCoordinates.Row <= MaxRow - 1)
            {
                Location nextNorthLoc = _mapLocation[_currentLocationCoordinates.Row+1, _currentLocationCoordinates.Column, _currentLocationCoordinates.Level];
                if(nextNorthLoc != null)
                {
                    northLoc = nextNorthLoc;
                }
            }
            return northLoc;
        }
        public Location southLoc()
        {
            Location southLoc = null;
            if (_currentLocationCoordinates.Row >0)
            {
                Location nextSouthLoc = _mapLocation[_currentLocationCoordinates.Row - 1, _currentLocationCoordinates.Column, _currentLocationCoordinates.Level];
                if (nextSouthLoc != null)
                {
                    southLoc = nextSouthLoc;
                }
            }
            return southLoc;
        }
        public Location westLoc()
        {
            Location westLoc = null;
            if (_currentLocationCoordinates.Column <= MaxColumn-1)
            {
                Location nextWestLoc = _mapLocation[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column+1, _currentLocationCoordinates.Level];
                if (nextWestLoc != null)
                {
                    westLoc = nextWestLoc;
                }
            }
            return westLoc;
        }
        public Location eastLoc()
        {
            Location eastLoc = null;
            if (_currentLocationCoordinates.Column >0)
            {
                Location nextEastLoc = _mapLocation[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column-1, _currentLocationCoordinates.Level];
                if (nextEastLoc != null)
                {
                    eastLoc = nextEastLoc;
                }
            }
            return eastLoc;
        }
        public Location lowerLvlLoc()
        {
            Location lowerLvlLoc = null;
            if (_currentLocationCoordinates.Level > 0)
            {
                Location nextLvlLoc = _mapLocation[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column, _currentLocationCoordinates.Level-1];
                if (nextLvlLoc != null)
                {
                    lowerLvlLoc = nextLvlLoc;
                }
            }
            return lowerLvlLoc;
        }
        public Location upperLvlLoc()
        {
            Location lvlLoc = null;
            if (_currentLocationCoordinates.Level < _lvl - 1)
            {
                Location nextLvlLoc = _mapLocation[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column, _currentLocationCoordinates.Level+1];
                if (nextLvlLoc != null)
                {
                    lvlLoc = nextLvlLoc;
                }
            }
            return lvlLoc;
        }

        #endregion
        public GameItem GameItemId(int itemId)
        {
            return StandardItems.FirstOrDefault(i => i.Id == itemId);
        }
        public string OpenRoomById(int toolId)
        {
            string msg = "Tool didn't work";
            Location mapLoc = new Location();
            for(int row = 0; row<_maxRow; row++)
            {
                for(int column = 0; column < _maxColumn; column++)
                {
                    for(int lvl = 0; lvl <_lvl; lvl++)
                    {
                        mapLoc = _mapLocation[row, column, lvl];
                        if(mapLoc!=null && mapLoc.RequiredItemId == toolId)
                        {
                            mapLoc.AccessLocation = true;
                            msg = $"{mapLoc.LocatName} is now accessable";
                        }
                    }
                }
            }
            return msg;
        }
        #endregion
    }
}