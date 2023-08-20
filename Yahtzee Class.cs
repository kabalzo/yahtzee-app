using System.ComponentModel;
using System.Runtime.CompilerServices;

class Yahtzee {

    public Random roll1 = new();
    public Random roll2 = new();
    public Random roll3 = new();
    public Random roll4 = new();
    public Random roll5 = new();

    private int totalScore = 0;
    public int yahtzeeBonus = 0;
    public int handScore = 0; 
    public int turnCounter = 1;

    public int die1;
    public int die2;  
    public int die3;  
    public int die4; 
    public int die5; 

    public string theRules = "Roll 5 dice on your first turn\nKeep 0-5 and roll up to twice more with the rest\nFill entries on the scorecard each turn with the result of the rolls\n\nUPPER SECTION\n(Aces) Count and add only aces\n(Twos) Count and add only twos\n(Threes) Count and add only threes\n(Fours) Count and add only fours\n(Fives) Count and add only fives\n(Sixes) Count and add only sixes\nIf total score of upper is 63 or greater, bonus 35 points\n\nLOWER SECTION\n(3 of a kind) Add total of all dice\n(4 of a kind) Add total of all dice\n(Full House) Two of one kind, three of another. Score 25\n(Small straight) Sequence of 4. Score 30\n(Large straight) Sequence of 5. Score 40\n(Yahtzee) 5 of a kind. Score 50\n(Chance) Add total of all dice\n(Yahtzee bonus) 100 bonus points for each additional Yahtzee after the first\n";

    public void RollDie1() {
            die1 = roll1.Next(1,7);
    }
    public void RollDie2() {
            die2 = roll2.Next(1,7);
    }
    public void RollDie3() {
            die3 = roll3.Next(1,7);
    }
    public void RollDie4() {
            die4 = roll4.Next(1,7);
    }
    public void RollDie5() {
            die5 = roll5.Next(1,7);
    }
    public void RollAllDice() {
            RollDie1();
            RollDie2();
            RollDie3();
            RollDie4();
            RollDie5();
    }
    void DisplayCurrentDiceValues() {
        Console.WriteLine("Die 1: " + die1);
        Console.WriteLine("Die 2: " + die2);
        Console.WriteLine("Die 3: " + die3);
        Console.WriteLine("Die 4: " + die4);
        Console.WriteLine("Die 5: " + die5 + "\n");
    }
    
    //Ask user if they want to see the rules or proceed to the game
    void DisplayRules() {
        Console.WriteLine(theRules);
    }

    //Check to see if all the dice on any given hand are all the same
    bool IsYahtzee() {
            if (die1 == die2 && die2 == die3 && die3 == die4 && die4 == die5) {
                Console.WriteLine("Yahtzee!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                return true;
            }
            else {
                return false;
            }
    }

    //Return an integer value between 1-5 based on the string input
    //The int value corresponds to the switch statment that controls the game flow
    int NextUserAction(string userInput) {
        while (true) {
            if (userInput == "score") {
                return 1;
            }
            else if (userInput == "rules") {
                return 2;
            }
            else if (userInput == "") {
                return 3;
            }
            else if (userInput == "quit") {
                return 4;
            }
            else {
                Console.WriteLine("You've entered an invalid command");
                return 5;
            }
        }
    }

    //This will be used for holding dice and adding up the score for a hand
    //instead of just rerolling all the dice as it is right now
    void PlayHand() {
        int handRoll = 0;
    }
    public void PlayGame() {
        Console.WriteLine("Welcome to the Yahtzee app!");
        while(true) {
            Console.WriteLine($"Turn {this.turnCounter}");
            Console.WriteLine("Press [Enter] key to roll the dice");
            Console.WriteLine("Type 'score' to display the score");
            Console.WriteLine("Type 'rules' if you want to see the rules");
            Console.WriteLine("Type 'quit' to end the game");

            string userInputFromKeyboard = Console.ReadLine();
            int inputAsInt = NextUserAction(userInputFromKeyboard);
            switch (inputAsInt) {
                //Display the score
                case 1: 
                     Console.WriteLine($"\nCurrent total score is: {totalScore}");
                     continue;
                //Display the rules
                case 2:
                    DisplayRules();
                    continue;
                //Enter key is pressed returning an empty string
                case 3:
                    this.RollAllDice();
                    DisplayCurrentDiceValues();
                    if (IsYahtzee()) {
                        break;
                    }
                    this.turnCounter++;
                    continue;
                //Quit the game
                case 4:
                    break;
                //Invalid command
                case 5:
                    Console.WriteLine("You've entered an invalid command");
                    continue;
            }
            break;
        }
    }
}



