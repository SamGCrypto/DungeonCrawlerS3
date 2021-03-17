using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game_DungeonCrawler.Presentation
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        GameSessionViewModel _gameSessionViewModel;
        public GameWindow(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;

            InitializeComponent();
        }
        private void Btn_moveN_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveNorth();
        }
        private void Btn_moveS_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveSouth();
        }
        private void Btn_moveW_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveWest();
        }
        private void Btn_moveE_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveEast();
        }
        private void Btn_moveU_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveUp();
        }
        private void Btn_moveL_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveDown();
        }
    }
}
