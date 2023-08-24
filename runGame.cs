//Main game loop
using System;
namespace MyApp {
    class Run {
        public static void Main(String[] args) {
            Yahtzee game = new();
            game.PlayGame();
            Console.WriteLine("\nThanks for Playing!");
        }
    }
}

