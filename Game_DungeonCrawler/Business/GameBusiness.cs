using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Game_DungeonCrawler.Presentation;
using Game_DungeonCrawler.Data;
using Game_DungeonCrawler.Model;

namespace Game_DungeonCrawler.Business
{
    public class GameBusiness
    {
        GameSessionViewModel _gameSessionViewModel;
        Player _player = new Player();
        Map _gameMap;
        GameMapCoordinates _initialLocCoords;

        public GameBusiness()
        {
            InitializeDataSet();
            ShowView();
        }
       
        public void InitializeDataSet()
        {
            _gameMap = GameData.GameMap();
            _initialLocCoords = GameData.InitialGameLocation();
            _player = GameData.PlayerInfo();
        }
        public void ShowView()
        {
            _gameSessionViewModel = new GameSessionViewModel(_player,
                GameData.GameMap(),
                GameData.InitialGameLocation()
                );
            GameWindow gameSesViewMod = new GameWindow(_gameSessionViewModel);

            gameSesViewMod.DataContext = _gameSessionViewModel;

            gameSesViewMod.Show();

        }
    }
}
