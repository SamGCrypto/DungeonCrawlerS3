using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using Game_DungeonCrawler.Model;
using System.Collections.ObjectModel;

namespace Game_DungeonCrawler.Data
{
    public static class GameData
    {
        public static Player PlayerInfo()
        {
            return new Player()
            {
                Id = 1,
                Name = "Andrew",
                Age = 20,
                JobPosition = Player.JobPositionTitle.Adventurer,
                Training = Player.TrainKnow.Swordsmanship,
                ItemInHand = Player.Items.Sword,
                Health = 200,
                XP = 0,
                Lives = 3,
                Inventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemId(1002), 3),
                    new GameItemQuantity(GameItemId(2001), 1)

                }
            };
        }
        private static GameItem GameItemId(int id)
        {
            return StandardItems().FirstOrDefault(i => i.Id == id);
        }
        public static List<string> StartingMessage()
        {
            return new List<string>()
            {
                "\tTo save your family and friends you must venture into a dark cavern",
                "\t choose your path wisely."
            };
        }
        public static GameMapCoordinates InitialGameLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 0, Level = 0 };
        }

        public static Map GameMap()
        {
            int Row = 5;
            int Column = 4;
            int Levels = 2;

            Map cavernMap = new Map(Row, Column, Levels);

            cavernMap.MapLocation[0, 0, 0] = new Location()
            {
                Id = 1,
                LocatName = "Cavern Entrance",
                AreaDescription = "A long onminous cavern looms before you young traveler" +
                "to rescue the town from which you came.",
                AccessLocation = true,
                XPGained = 10,
                Msg = "To rescue the village you must defeat the goblin king.",
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemId(1001),2)
                }
            };
            cavernMap.MapLocation[1, 0, 0] = new Location()
            {
                Id = 2,
                LocatName = "Central Cavern 1",
                AreaDescription = "A long onminous cavern looms around" +
                   "Water dripping beneath you." +
                  "You see some gold littered about",
                AccessLocation = true,
                XPGained = 13,
                Msg = "Where the young warriors fall, you soon must surpass or perish. Continue Forward.",
                Gold = 10
            };
            cavernMap.MapLocation[2, 0, 0] = new Location()
            {
                Id = 3,
                LocatName = "Central Cavern 2",
                AreaDescription = "A long onminous cavern looms around" +
                "Water dripping beneath you." +
                "You see some gold littered about",
                AccessLocation = true,
                XPGained = 13,
                Msg = "You may go left right forward or back from this location.",
                Gold = 12
            };
            cavernMap.MapLocation[2, 1, 0] = new Location()
            {
                Id = 4,
                LocatName = "The Abandoned Cavern",
                AreaDescription = "A room filled with coal and stones, mining equipment laying about the room" +
                "A single pool of water remains in the center of the room." +
                "A foul smell fills the room causing you to feel sick",
                AccessLocation = true,
                HPAffected = 13,
                Msg = "It would be wise to return back from this place before you perish.",
                itemAcq = Character.Items.pickaxe,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemId(1002),1)
                }
            };
            cavernMap.MapLocation[3, 0, 0] = new Location()
            {
                Id = 5,
                LocatName = "Miners room",
                AreaDescription = "You find a large room before you, latern" +
                "Water dripping beneath you." +
                "You see some gold littered about",
                AccessLocation = true,
                Msg = "You may go left right forward or back from this location.",
                Gold = 1,
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemId(2002),1)
                }
            };
            cavernMap.MapLocation[3, 0, 1] = new Location()
            {
                Id = 6,
                LocatName = "Miners room level 2",
                AreaDescription = "" +
                "There are some food laying about that gives you some health." +
                "You see some gold littered about",
                AccessLocation = false,
                Msg = "You may go left right forward or back from this location.",
                XPRequired = 50
            };
            return cavernMap;

        }
        public static List<GameItem> StandardItems()
        {
            return new List<GameItem>()
            {
                new Potion(1001,"Minor health potion",10,0,0,"A minor healing potion that can regen 10 pts of health",0),
                new Potion(1002,"Medium health potion",30,0,0,"A medium range healing potion that can regen 10 pts of health",0),
                new Potion(1003,"Massive health potion",100,0,0,"A minor healing potion that can regen 10 pts of health",0),
                new Tool(2001, "Sword",100, Tool.UseAffect.KILL_ENEMY, "A legendary weapon used to eliminate many enemies.", -10, "Swing the blade"),
                new Tool(2002, "Cross",120, Tool.UseAffect.HEAL_PLAYER, "A legendary restoring item.", 110, "Restore health")
            };
        }

    }
}