using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using Game_DungeonCrawler.Model;

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
                Lives = 3
            };
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
            return new GameMapCoordinates(){Row = 0, Column=0, Level=0};
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
                Msg = "To rescue the village you must defeat the goblin king."
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
                itemAcq = Character.Items.pickaxe
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
                Gold = 1
            };
            cavernMap.MapLocation[3, 0, 1] = new Location()
            {
                Id = 6,
                LocatName = "Miners room level 2",
                AreaDescription = "" +
                "There are some food laying about that gives you some health." +
                "You see some gold littered about",
                AccessLocation = true,
                Msg = "You may go left right forward or back from this location.",
                XPRequired = 50
            };
            return cavernMap;

        }

    }
}
