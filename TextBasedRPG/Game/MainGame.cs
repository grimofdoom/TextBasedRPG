using System;
using System.Collections.Generic;
using System.Threading;

namespace TextBasedRPG {

    [Serializable]
    public class MainGame : Engine.Game {
        
        
        public override void Setup() {
            gameName = "newGame";
            gameVersion = "0.01";
            playerName = "john";
            enableAutoSave = true;
        }

        public override void Intro() {
            Console.WriteLine(gameName);
            Console.WriteLine("Version: " + gameVersion);
        }

        public override void Close() {
            Console.WriteLine("Closing Game");
            Thread.Sleep(500);
        }

        public override void Copyrights() {
            Console.WriteLine("This test game was developed by GrimOfDoom");
            Console.WriteLine("There is nothing more to be said");
            Console.WriteLine("The End");
        }
    }
}