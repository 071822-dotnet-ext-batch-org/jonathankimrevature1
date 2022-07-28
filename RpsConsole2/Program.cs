using System;

namespace RpsConsole2
{
    class Program
    {
<<<<<<< HEAD
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
=======
        static void Main(string[] args) {

        Random random = new Random();

        // Welcome   
        Console.WriteLine("Welcome to your favorite game, Rock-Paper-Scissors!");

        string player1Name = "";
        string computerName = "";
        //int player1Choice = 0;
        //int computerChoice = 0;
        int player1wins = 0;
        int computerWins = 0;
        int numberOfTies = 0;
        
        //Get user name
        Console.WriteLine("What is your name?");
        player1Name = Console.ReadLine();
        Console.WriteLine($"\nWelcome to Rock-Paper-Scissors, {player1Name}!");

        //get the users choice
        Console.WriteLine("Please enter... \n\t 1 for Rock.\n\t 2 for Paper.\n\t 3 for Scissors.");
        int player1Choice = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(player1Choice);

        
        
        int computerChoice = random.Next(1,4);
         Console.WriteLine(computerChoice);
        

     

>>>>>>> fcf627da22537b994945e3353d6df14dbe36981f
        //computerChoice = random.Next(1,4);
        //computerChoice = (rand.Next(1000) % 3) + 1;
        //Console.WriteLine(computerChoice);
        
<<<<<<< HEAD
        /**
            // Welcome message...
            Console.WriteLine("\t\tWelcome to you favorite game!\n\t\tThis is Rock-Paper Scissors!\n");

            //Instructions to play... explanation of the game flow. which keys are used, etc
            Console.WriteLine("\tPress the number corresponding to Rock, Paper, or Scissors to make your choice.\n\tThe computer will make its choice and you will be notified as to the winner.\n\nTo play, press enter.\n\n");

            // start the game by pressing ENTER
            //Console.ReadLine();

            // (unseen to the user) create some variables to store which choice the user made, 
            // computer choice, computer wins, user wins, number of ties, player1 name (user), player2 name (computer for now)

            int computerChoice = 0;
            Random rand = new Random();// the Random class gets us a pseudorandom decimal between 0 and 1.
            int player1Choice = -1;
            int player1wins = 0;//how many rounds p1 has won
            int computerWins = 0;//how many rounds the compouter has won
            int numberOfTies = 0;//how many ties there have been
            string player1Name = "";
            string computerName = "";
            string player1ChoiceStr;
            bool successfulConversion = false;
            bool isTie = true;
            string playAgain = "";

            // get the users name
            Console.WriteLine("What is your name?");
            player1Name = Console.ReadLine();

            Console.WriteLine($"Welcome to R-P-S Game, {player1Name}");

            //this loop is for each beginning of a game.
            while (true)
            {


                //a while loop to keep prompting the user for choices till there isn't a tie.
                while (isTie)
                {
                    // get the users choice
                    Console.WriteLine("Please enter...\n\t1 for Rock.\n\t2 for Paper.\n\t3 for Scissors.");
                    player1ChoiceStr = Console.ReadLine();

                    successfulConversion = Int32.TryParse(player1ChoiceStr, out player1Choice);
                    //Console.WriteLine($"the number you inputted was {successfulConversion}, {player1Choice}");


                    // get the computers random choice
                    computerChoice = (rand.Next(1000) % 3) + 1;
                    Console.WriteLine(computerChoice);

                    // evaluate the choices to determine the winner of the round.
                    // if it was a tie
                    if (player1Choice == computerChoice)
                    {
                        // tell them it was a tie and loop back up to the top to reprompt
                        Console.WriteLine($"This round was a tie!... Let's try again.");
                        // update the tally for this gaming session of how many games the computer and the user have won.
                        numberOfTies++;// ++ increments the int by exactly 1.
                        //isTie = true;
                    }
                    // if the user won
                    else if ((player1Choice == 1 && computerChoice == 3) ||
                                (player1Choice == 2 && computerChoice == 1) ||
                                    (player1Choice == 3 && computerChoice == 2))
                    {
                        Console.WriteLine($"Congrats, {player1Name}, you won this round.");
                        // update the tally for this gaming session of how many games the computer and the user have won.
                        player1wins = player1wins + 1;// this method gives you the option of incrementing by more than 1
                                                      // player1wins += 1;
                                                      // player1wins++;
                        isTie = false;
                    }
                    //if the computer won
                    else
                    {// if the computer won
                        Console.WriteLine($"I'm sorry, {computerName} won this round.");
                        // update the tally for this gaming session of how many games the computer and the user have won.
                        computerWins += 1;// this method gives you the option of incrementing by more than 1.
                        isTie = false;
                    }
                }

                // ask if they want to play again. (if using rounds, each game would need to be stored.)
                Console.WriteLine($"Hey {player1Name}, would you like to play again?\n\tEnter'Y' to play again or 'N' to quit the program.");
                playAgain = Console.ReadLine();
                if (String.Equals("Y", playAgain, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"The strings are equal");
                    isTie = true;
                }
                else
                {
                    //continue;// will end the current loop and immediately start the next iteration of the same loop.
                    Console.WriteLine($"I'm sorry to see you go... se la vi.");
                    break;
                }
            }


            // tell the user the tally results as of now.


            // Ask if they want to play again.(keep the tally live till the user wants to quit)



            //quit if they don't want to play... loop up to begin again if they DO want to play again.
            **/









        
    }
}

//REMEMBER TO VALIDATE USER INPUT
// try
// {
//     player1Choice = Int32.Parse(player1ChoiceStr);
// }
// catch (OverflowException ex)
// {
//     //this method to write to the console is string interpolation.
//     Console.WriteLine($"The parse method failed because '{ex.Message}'.");

// }
// catch (FormatException ex)
// {
//     Console.WriteLine($"The parse method failed because {ex.Message}");//this method to write to the console is string interpolation.
// }
// catch (ArgumentNullException ex)
// {
//     Console.WriteLine("The parse method failed because {0}", ex.Message);// This is Composite Formatting.
// }
=======
        


        //Evaluate the choices to determien the winner of the round.
    
        }

    }
}
>>>>>>> fcf627da22537b994945e3353d6df14dbe36981f
