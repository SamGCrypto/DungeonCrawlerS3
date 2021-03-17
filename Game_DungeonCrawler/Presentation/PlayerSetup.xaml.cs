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
using System.Windows.Shapes;
using Game_DungeonCrawler.Model;

namespace Game_DungeonCrawler.Presentation
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PlayerSetup : Window
    {
        private Player _player;
        public PlayerSetup(Player _player)
        {
            InitializeComponent();


        }

        private void SetupWindow()
        {
            List<string> jobTitle = Enum.GetNames(typeof(Player.JobPositionTitle)).ToList();
            List<string> training = Enum.GetNames(typeof(Player.TrainKnow)).ToList();
            List<string> item = Enum.GetNames(typeof(Player.Items)).ToList();

            
        }
    }
}
