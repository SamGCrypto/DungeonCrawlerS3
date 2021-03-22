using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_DungeonCrawler.Model
{
    public class Character:ObservableObject
    {
        #region ENUMERABLE
        public enum TrainKnow
        {
            Swordsmanship,
            Archery,
            Mining,
            Farming,
            None
        }
        public enum Items
        {
            Ax,
            Sword,
            Bow,
            Warpike,
            sickle,
            pickaxe,
            None
        }
        #endregion
        #region FIELDS
        protected int _id;
        protected string _name;
        protected int _age;
        protected int _location;
        protected TrainKnow _training;
        protected Items _items;
        #endregion
        #region PROPERTIES
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public int Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public TrainKnow Training
        {
            get { return _training; }
            set { _training = value; }
        }
        #endregion
        #region CONSTRUCTION
        public Character()
        {

        }
        public Character(string name, int age, int location, TrainKnow training, Items items)
        {
            _name = name;
            _age = age;
            _training = training;
            _items = items;
            _location = location;
        }
        #endregion
        #region METHOD
        public virtual string DefaultGreeting()
        {
            return $"Hello, my name is {_name}. I am a {_training} and I am {_age} years old";
        }
        #endregion
    }
}
