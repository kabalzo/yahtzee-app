//Main game loop
using System;
namespace MyApp {
    class Run {
        public static void Main(String[] args) {
            Yahtzee game = new Yahtzee();
            game.playGame();
            Console.WriteLine("Thanks for Playing!");
        }
    }
}

