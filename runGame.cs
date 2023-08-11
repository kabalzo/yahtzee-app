//Main game loop
Yahtzee game = new Yahtzee();
string userInputFromKeyboard;
int input;
Console.WriteLine("Welcome to the Yahtzee app!");
while(true) {
    while (true) {
        Console.WriteLine($"Turn {game.turnCounter}");
        Console.WriteLine("Press [Enter] key to roll the dice");
        Console.WriteLine("Type 'score' to display the score");
        Console.WriteLine("Type 'rules' if you want to see the rules");
        Console.WriteLine("Type 'quit' to end the game");

        userInputFromKeyboard = Console.ReadLine();
        input = game.nextUserAction(userInputFromKeyboard);
        if(input == -2) {
            break;
        }
        else if (input == -1) {
            continue;
        }
        else {
            input = 0;
            break;
        }
    }
    if (input != 0) {
        game.rollAllDice();
        game.displayCurrentDiceValues();
        if (game.isYahtzee()) {
            break;
        }
        game.turnCounter++;
    }
    else {
        break;
    }
}
Console.WriteLine("Thanks for Playing!");
