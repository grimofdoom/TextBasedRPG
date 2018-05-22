using System;
using System.Collections.Generic;

namespace TextBasedRPG {
    class Program {
        static void Main(string[] args) {
            Engine.TextEngine engine = new Engine.TextEngine {
                GameInstance = new MainGame()
            };
            engine.Play();
        }
    }
}
