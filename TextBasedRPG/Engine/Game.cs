using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedRPG.Engine
{
    [Serializable]
    public abstract class Game {

        public String playerName;
        public String gameName;
        public String gameVersion;
        public bool enableAutoSave = true;

        public Game() {

        }

        //Set settings and startup variables here, such as game name
        public abstract void Setup();

        //Set the intro print here
        public abstract void Intro();

        //Set the closing properies and actions here
        public abstract void Close();

        //Set copyrights here
        public abstract void Copyrights();
    }
}
