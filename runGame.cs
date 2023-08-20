//Main game loop
using System;
namespace MyApp {
    class Run {
        public static void Main(String[] args) {
            Yahtzee game = new Yahtzee();
            game.PlayGame();
            Console.WriteLine("Thanks for Playing!");
        }
    }
}

