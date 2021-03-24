using System.Collections.Generic;
using System.Collections.ObjectModel;
using static Game_DungeonCrawler.Model.Character;

namespace Game_DungeonCrawler.Model
{
    public class Map:ObservableObject
    {
        #region FIELDS
        private Location[,,] _mapLocation;
        private int _maxRow, _maxColumn, _lvl;
        private GameMapCoordinates _currentLocationCoordinates;
        private int _reqToolid;
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
        public List<GameItem> StandardItems
        {
            get{ return _standardItems; }
            set { _standardItems = value; }
        }

        public int MaxRow
        {
            get{ return _maxRow; }
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
        public int Tool_ID 
        {
            get { return _reqToolid; }
            set
            {
                _reqToolid = value;
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
        public Location northLoc()
        {
            Location northLoc = null;
            if (_currentLocationCoordinates.Row <= MaxRow-1)
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

        public string ToolOpenLocation(int toolId)
        {
            string msg = "The tool didn't work.";
            Location mapLocation = new Location();
            for(int row=0; row<_maxRow; row++)
            {
                for (int column = 0; column < _maxColumn; column++)
                {
                    for (int lvl = 0; lvl < _lvl; lvl++)
                    {
                        mapLocation.AccessLocation = true;
                        msg = $"{mapLocation.LocatName} is now accessable.";
                    }
                }
            }
            return msg;
        }
        #endregion
    }
}