using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

class Yahtzee {
    Tuple<string, bool, int>[] ScoreBoard = 
    {
        Tuple.Create("yahtzee", false, 50),
        Tuple.Create("large", false, 40),
        Tuple.Create("small", false, 30),
    };
    private Random roll1 = new();
    private Random roll2 = new();
    private Random roll3 = new();
    private Random roll4 = new();
    private Random roll5 = new();

    private int totalScore = 0;
    private int yahtzeeBonus = 0;
    private int handScore = 0; 
    private int turnCounter = 1;

    //TODO: Change this from separate ints to 5 int elements in an array
    private int die1;
    private int die2;  
    private int die3;  
    private int die4; 
    private int die5;

    //private readonly int[] ListOfDice = new int[] { die1, die2, die3, die4, die5 };

    private readonly string theRules = "\nRoll 5 dice on your first turn\nKeep 0-5 and roll up to twice more with the rest\nFill entries on the scorecard each turn with the result of the rolls\n\nUPPER SECTION\n(Aces) Count and add only aces\n(Twos) Count and add only twos\n(Threes) Count and add only threes\n(Fours) Count and add only fours\n(Fives) Count and add only fives\n(Sixes) Count and add only sixes\nIf total score of upper is 63 or greater, bonus 35 points\n\nLOWER SECTION\n(3 of a kind) Add total of all dice\n(4 of a kind) Add total of all dice\n(Full House) Two of one kind, three of another. Score 25\n(Small straight) Sequence of 4. Score 30\n(Large straight) Sequence of 5. Score 40\n(Yahtzee) 5 of a kind. Score 50\n(Chance) Add total of all dice\n(Yahtzee bonus) 100 bonus points for each additional Yahtzee after the first\n";

    private void RollSingleDie(int die) {
        switch (die) {
            case 1:
                die1 = roll1.Next(1,7);
                break;
            case 2:
                die2 = roll2.Next(1,7);
                break;
            case 3:
                die3 = roll3.Next(1,7);
                break;
            case 4:
                die4 = roll4.Next(1,7);
                break;
            case 5:
                die5 = roll5.Next(1,7);
                break;
        }
    }

    //Get new integer values between 1-6 for every die 
    private void RollAllDice() {
        for (int i = 1; i <= 5; i++) {
            RollSingleDie(i);
        }
    }

    //Display the values of all 5 die at any given moment
    private void DisplayCurrentDiceValues() {
        Console.WriteLine("Die 1: " + die1 + " | Die 2: " + die2 + " | Die 3: " + die3 + " | Die 4: " + die4 + " | Die 5: " + die5);
    }
    
    //Ask user if they want to see the rules or proceed to the game
    private void DisplayRules() {
        Console.WriteLine(theRules);
    }

    //Check to see if all the dice on any given hand are all the same
    private bool IsYahtzee() {
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
    private int NextUserAction(string userInput) {
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
    private void PlayHand() {
        RollAllDice();
        string keepDiceOrRollAgain;
        string endTurnEarly;
        //Iterate three times at most per hand
        for (int currentRollCount = 0; currentRollCount <= 1; currentRollCount++) {
            //Ask user if they want to keep each die each roll.
            //Definetely a more elegant way to do this but as a proof of concept
            Console.WriteLine($"This is roll {currentRollCount +1}");
             DisplayCurrentDiceValues();
            for (int currentDie = 1; currentDie <=5; currentDie++) {
                while (true) {
                    //DisplayCurrentDiceValues();
                    Console.WriteLine($"Do you want to keep dice {currentDie} ? [y] [n]");
                    keepDiceOrRollAgain = Console.ReadLine();
                        if (keepDiceOrRollAgain == "n") {
                            RollSingleDie(currentDie);
                            break;
                        }
                        else if (keepDiceOrRollAgain == "y") {
                            break;
                        }
                        else {
                            Console.WriteLine("Invalid entry\n");
                        }
                }
            }
            //Give user the option to score the hand early and not have to roll three times if the dice are what they want
            //DisplayCurrentDiceValues();
            Console.WriteLine("Would you like to score this roll? [y] [n]\n");
            endTurnEarly = Console.ReadLine();

            //For right now just add the total of the dice to the total score
            //TODO: Implement a scoring procedure to add the score to the right portion of the scorecard and account for points
            if (endTurnEarly == "y") {
                totalScore += die1 + die2 + die3 + die4 + die5;
                break;
            }
        }
        //TODO: This is where you would have to select the scorcard slot of your hand having rolled three times
        Console.Write("Results of the final throw are: ");
        DisplayCurrentDiceValues();
        totalScore += die1 + die2 + die3 + die4 + die5;
        Console.WriteLine($"Current total score is: {totalScore}\n");
    }

    //Main method to invoke the game. Only call this from another file
     public void PlayGame() {
        Console.WriteLine("Welcome to the Yahtzee app!\n");
        while(true) {
            Console.WriteLine($"#################### Turn {this.turnCounter} ####################");
            Console.WriteLine("################################################");
            Console.WriteLine("# Press [Enter] key to roll the dice           #");
            Console.WriteLine("# Type 'score' to display the score            #");
            Console.WriteLine("# Type 'rules' if you want to see the rules    #");
            Console.WriteLine("# Type 'quit' to end the game                  #");
            Console.WriteLine("################################################\n");

            string userInputFromKeyboard = Console.ReadLine();
            int inputAsInt = NextUserAction(userInputFromKeyboard);
            switch (inputAsInt) {
                //Display the score
                case 1: 
                     Console.WriteLine($"\nCurrent total score is: {totalScore}\n");
                     continue;
                //Display the rules
                case 2:
                    DisplayRules();
                    continue;
                //Enter key is pressed returning an empty string
                case 3:
                //Roll all the dice. Preliminary proof of concept
                /*
                Console.WriteLine("Rolling all the dice\n");
                    this.RollAllDice();
                    DisplayCurrentDiceValues();
                    if (IsYahtzee()) {
                        break;
                    }
                */

                //In this block I'm going to attempt to implement a way to keep specific die and reroll the others
                //This this is actual way the game needs to be played
                    
                    this.PlayHand();
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



