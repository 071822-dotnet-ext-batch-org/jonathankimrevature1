using System;

namespace rpsGame
{
    class newProgram
    {
        static void Main(string[] args) 
        {   
            //Declare variables
            Random random = new Random();
            bool playAgain = true;
            string player1Name = "";
            string gameContinue = "";

            // Welcome   
            Console.WriteLine("Welcome to your favorite game, Rock-Paper-Scissors!");

            //Get user name
            Console.WriteLine("What is your name?");
            player1Name = Console.ReadLine();
            Console.WriteLine($"\nWelcome to Rock-Paper-Scissors, {player1Name}!");

            //Outer While loop: Begin game
            while (playAgain == true)
            {
                int numberRounds = 0;
                int playerWins = 0;
                int computerWins = 0;
                int numberOfTies = 0;

                //Get number of rounds
                Console.WriteLine("Choose gamemode: \nBest of 3 \nBest of 5 \nBest of 7 ");
                numberRounds = Convert.ToInt32(Console.ReadLine());
            
                //Inner For loop: Play game
                for(int i=0; i<99; i++)
                {
                    //get the users choice
                    Console.WriteLine("\nPlease enter... \n\t 1 for Rock.\n\t 2 for Paper.\n\t 3 for Scissors.");
                    int player1Choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"You chose: {player1Choice}");
                
                    //get computer choice
                    int computerChoice = random.Next(1,4);
                    Console.WriteLine($"Computer chose: {computerChoice}");

                    //determine game results
                    if (player1Choice == computerChoice) {
                        Console.WriteLine("It is a tie!");
                        numberOfTies ++;
                    }
                    else if(player1Choice == 1 && computerChoice == 2) {
                        Console.WriteLine("Computer +1 Point!");
                        computerWins ++;
                    }
                    else if(player1Choice == 1 && computerChoice == 3) {
                        Console.WriteLine("Player +1 Point!");
                        playerWins ++;
                    }
                    else if(player1Choice == 2 && computerChoice == 1) {
                        Console.WriteLine("Player +1 Point!");
                        playerWins ++;
                    }
                    else if(player1Choice == 2 && computerChoice == 3) {
                        Console.WriteLine("Computer +1 Point!");
                        computerWins ++;
                    }
                    else if(player1Choice == 3 && computerChoice == 1) {
                        Console.WriteLine("Computer +1 Point!");
                        computerWins ++;

                    }
                    else if(player1Choice == 3 && computerChoice == 2) {
                        Console.WriteLine("Player +1 Point!");
                        playerWins ++;
                    }

                    //Scoreboard
                    Console.WriteLine("");
                    Console.WriteLine($"Player Wins: {playerWins}");
                    Console.WriteLine($"Computer Wins: {computerWins}");
                    Console.WriteLine($"Ties: {numberOfTies}");

                    //Win conditions
                    if (numberRounds == 3) {
                        if (playerWins ==2) {
                            Console.WriteLine($"\nCongratulations {player1Name}, you won!");
                            playAgain = false;
                            break;
                        } 
                        else if (computerWins == 2){
                            Console.WriteLine($"\nSorry {player1Name}, you lost.");
                            playAgain = false;
                            break;
                        }
                    } 
                    else if (numberRounds == 5){
                        if (playerWins == 3) {
                            Console.WriteLine($"\nCongratulations {player1Name}, you won!");
                            playAgain = false;
                            break;
                        }
                        else if (computerWins == 3){
                            Console.WriteLine($"\nSorry {player1Name}, you lost.");
                            playAgain = false;
                            break;
                        }
                    } 
                    else if (numberRounds == 7){
                        if (playerWins == 4){
                            Console.WriteLine($"\nCongratulations {player1Name}, you won!");
                            playAgain = false;
                            break;
                        }
                        else if (computerWins == 4){
                            Console.WriteLine($"\nSorry {player1Name}, you lost.");
                            playAgain = false;
                            break;
                        }
                    }
                }
                    
            //Outer While loop: Stop game or keep playing
            if (playAgain == false)
            {
                Console.WriteLine("\nPlay Again?\nPress y/n");
                gameContinue = Console.ReadLine();
                gameContinue = gameContinue.ToUpper();
                        
                if (gameContinue.Equals("Y")){
                    playAgain = true;
                }
                else if (gameContinue.Equals("N")){
                    Console.WriteLine($"Thanks for playing {player1Name}!");
                    playAgain = false;
                }  
            }  

            }        
        }
    }
}