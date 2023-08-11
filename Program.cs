Random roll1 = new();
Random roll2 = new();
Random roll3 = new();
Random roll4 = new();
Random roll5 = new();

int totalScore = 0;
int handScore = 0; 
int turnCounter = 1;

int die1;
int die2;  
int die3;  
int die4; 
int die5; 

void rollDie1() {
    die1 = roll1.Next(1,7);
}
void rollDie2() {
    die2 = roll2.Next(1,7);
}
void rollDie3() {
    die3 = roll3.Next(1,7);
}
void rollDie4() {
    die4 = roll4.Next(1,7);
}
void rollDie5() {
    die5 = roll5.Next(1,7);
}

void rollAllDice() {
    rollDie1();
    rollDie2();
    rollDie3();
    rollDie4();
    rollDie5();
}

void displayCurrentDiceValues() {
    Console.WriteLine("Die 1: " + die1);
    Console.WriteLine("Die 2: " + die2);
    Console.WriteLine("Die 3: " + die3);
    Console.WriteLine("Die 4: " + die4);
    Console.WriteLine("Die 5: " + die5 + "\n");
}

void displayRules() {
    Console.WriteLine("");
}
bool isYahtzee()
{
    if (die1 == die2 && die2 == die3 && die3 == die4 && die4 == die5) {
        Console.WriteLine("Yahtzee!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        return true;
    }
    else {
        return false;
    }
}

bool nextUserAction(string userInput) {
    if (userInput != "score") {
        return false;
    }
    else {
        return true;
    }
}

//Main game loop
while(true) {
    Console.WriteLine("Welcome to the Yahtzee app! Would you like to see the rules?");
    Console.WriteLine("Yes [y] No [n]");
    string displayGameRules = Console.ReadLine();

    //Ask user if they want to see the rules or proceed to the game
    while (true) {
        if (displayGameRules == "y" || displayGameRules == "Y" || displayGameRules == "yes" || displayGameRules == "Yes"|| displayGameRules == "YES") {
            displayRules();
        }
        else if (displayGameRules == "n" || displayGameRules == "N" || displayGameRules == "no" || displayGameRules == "No" || displayGameRules == "YES") {
           break;
        }
        else {
            Console.WriteLine("You've entered an invalid command.");
        }
    }
    
    while (true) {
        string userInput;
        Console.WriteLine($"Turn {turnCounter}");
        Console.WriteLine("Press [Enter] key to roll the dice. Type 'score' to display the score.");
        userInput = Console.ReadLine();
        if (nextUserAction(userInput)) {
            Console.WriteLine("\nCurrent total score is: " + totalScore);
            continue;
        }
        
        rollAllDice();
        displayCurrentDiceValues();
        if (isYahtzee()) {
            break;
        }
        turnCounter++;
    }
    break;
}
Console.WriteLine("Thanks for Playing!");


