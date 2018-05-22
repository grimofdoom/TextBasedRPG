using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace TextBasedRPG.Engine
{
    public class TextEngine
    {
        //TextEngine main Variables, states of game
        private bool QuitGame;
        private bool RestartGame;
        static int LineSpacer = 6;
        public Game GameInstance;

        public TextEngine() {
            QuitGame = false;
            RestartGame = false;
        }

        //GameInstant play process = Load -> Copyrights -> Setup -> Intro -> [GAMING] -> Close -> Save
        public void Play() {
            while (!QuitGame) {
                //Reset [RestartGame] to false, so if game restarts, it can re-run normally
                RestartGame = false;
                Credits();
                //Load game
                Load();
                //Game Instance startup
                GameInstance.Copyrights();
                GameInstance.Setup();
                Thread.Sleep(400);
                QuickSpacers();
                GameInstance.Intro();
                //This is the actual main game loop
                while (!RestartGame) {
                    //Main menu
                    Console.WriteLine("Hello " + GameInstance.playerName);
                    Console.WriteLine("");
                    Console.WriteLine("rename  : Changes player name");
                    Console.WriteLine("repeat  : Blurts whatever you said");
                    Console.WriteLine("restart : Restarts the game without quitting");
                    Console.WriteLine("quit    : Quits the game entirely");
                    Console.Write("What is your choice?:");
                    //Grab user input and format it, separate into 2 variables for reading and repeating
                    UserInput input = new UserInput();
                    //Main menu options
                    switch (input.FInput(0)) {
                        case "rename":
                            GameInstance.playerName = input.FInput(1);
                            break;
                        case "quit":
                            Quit();
                            break;
                        case "restart":
                            Restart();
                            break;
                        case "repeat":
                            Console.WriteLine("I am blurting: " + input.Input().Remove(0, input.FInput(0).Length + 1));
                            QuickSpacers();
                            break;
                        default:
                            Console.WriteLine("You failed to write something comprehensible, FAIL!");
                            QuickSpacers();
                            break;
                    }
                }
                GameInstance.Close();
                Save();
            }
        }

        // =================================== Basic Main Functions ===================================
        void Restart() {
            Console.Clear();
            RestartGame = true;
        }
        //Fully quits the game, should encorporate an auto-save like function into here with option to enable/disable
        void Quit() {
            RestartGame = true;
            QuitGame = true;
        }
        //Plays the intro
        void Credits() {
            Console.WriteLine("Welcome to this Text Based RPG");
            Console.WriteLine("This game may be later adapted into a text based MMORPG");
            Console.WriteLine("This game has no name");
            Console.WriteLine("Copyright 2018 Timothy Leitzke");
        }
        //Quickly create lines of space
        void SpaceLines(int linesToSpace) {
            for (int i = 0; i < linesToSpace; i++) {
                Console.WriteLine(" ");
            }
        }
        void QuickSpacers() {
            SpaceLines(LineSpacer);
        }
        //Save_load game state
        void Save() {
            string dir = @"c:\temp";
            string serializationFile = Path.Combine(dir, "TextGameState.bin");
            using (Stream stream = File.Open(serializationFile, FileMode.Create)) {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(stream, GameInstance);
            }
        }
        void Load() {
            string dir = @"c:\temp";
            string serializationFile = Path.Combine(dir, "TextGameState.bin");
            if (File.Exists(serializationFile) && GameInstance.enableAutoSave) {
                using (Stream stream = File.Open(serializationFile, FileMode.Open)) {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    GameInstance = (Game)bformatter.Deserialize(stream);
                }
            }
        }
    }
}
