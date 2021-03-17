using System;
using System.Collections.Generic;
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

        private Items _itemInHand;
        private JobPositionTitle _jobPosition;
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
        #endregion
    }
}
