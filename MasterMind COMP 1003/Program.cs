using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
namespace MasterMind_COMP_1003
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialized all the variables.
            bool gameRunning = true;
            int whiteMarker;
            //creates an array for storing the startcode
            string[] startCode = new string[4];
            int redMarker;
            int dict = 0;
            //creates an array for storing the guesscode
            string[] guessCode = new string[4];
            int attempts;
            //creates a large dictionary for storing all previous moves.
            Dictionary<int, Dictionary<int, String>> totalhistory = new Dictionary<int, Dictionary<int, string>>();
            //creates game loop
            while (gameRunning == true)
            {
                Console.WriteLine("Code Maker please enter your code and don't let the breaker see");
                // creates a boolean to store whether the question was answered correctly or not
                bool incorrect = false;
                //creates a for loop for entering the code.
                for (int x = 0; x < 4; x++)
                {
                    Console.WriteLine("Enter Position, "+(x+1));
                    startCode[x] = Console.ReadLine();
                    Console.Clear();
                }
                //initializes marker variables to 0 
                redMarker = 0;
                attempts = 0;
                whiteMarker = 0;
                string continue1 = string.Empty;
                //creates a loop to run whilst the code hasnt been cracked.
                while (redMarker < 4 && attempts < 10)
                {
                    //initializes the history dictionary to avoid referencing
                    Dictionary<int, string> history = new Dictionary<int, string>();
                    //resets the dictionary
                    history.Clear();
                    redMarker = 0;
                    attempts++;
                    for (int i = 0; i < guessCode.Length; i++)
                    {
                        //Asks the code breaker to guess the code
                        Console.WriteLine("Guess code position " + (i + 1) + ": ");
                        guessCode[i] = Console.ReadLine();
                        //adds the contents of the string array to the dictionary "history"
                        history.Add(i, guessCode[i]);
                        incorrect = true;
                        if (guessCode[i] == startCode[i])
                        {
                            Console.WriteLine("Correct position and colour");
                            redMarker++;
                        }
                        //This else loop needs to be ran multiple times or needs an equivalent to .contains for string[]
                        else
                        {
                            int max = 0;
                            //loops through the code to compare the guess with each element of the code.
                            for (int no = 0; no < guessCode.Length; no++)
                            {
                                if (startCode[no] == guessCode[i])
                                {
                                    Console.WriteLine("Correct colour but incorrect position: ");
                                    whiteMarker++;
                                    break;
                                }
                                else
                                {
                                    max++;
                                }
                            }
                            //if the element entered doesnt match the 4 elements in the codemakers code then the entry is considered incorrect
                            if (max == 4)
                            {
                                if (incorrect == true)
                                {
                                    Console.WriteLine("Not Correct ");
                                    incorrect = false;
                                }
                            }
                        }
                        //waits before asking for another input
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                    dict++;
                    //temp dictionary to avoid referencing history
                    Dictionary<int, string> newval = new Dictionary<int, string>();
                    foreach (KeyValuePair<int, string> kvp in history)
                    {
                        newval.Add(kvp.Key, kvp.Value);
                    }
                    //Increments the key for the big dictionary
                    dict++;
                    totalhistory.Add(dict, newval);
                    if (redMarker == 4)
                    {
                        // if there are 4 red markers then the user is correct
                        Console.WriteLine("Well done guesser you've won");
                        history.Clear();
                    }
                    else { 
                        //if there are not 4 markers then the codebreaker is incorrect and needs to retry.
                        Console.WriteLine("Incorrect try again you have "+ (10-attempts) + " attempts left: ");
                        Console.WriteLine("Here are you're current guesses: ");
                        foreach (KeyValuePair<int, string> kvp in history)
                        {
                            Console.WriteLine("Position = {0}, Value = {1}", (kvp.Key+1), kvp.Value);
                        }
                    }
                    history.Clear();
                }
                Console.WriteLine("Here are your attempts: ");
                int l = 0;
                foreach (KeyValuePair<int, Dictionary<int, string>> kvp in totalhistory)
                {
                    l++;
                    Console.WriteLine("This was attempt number: " + l);
                    foreach (KeyValuePair<int, string> kp in kvp.Value)
                    {
                            Console.WriteLine("Position = {0}, Value = {1}", (kp.Key + 1), kp.Value);
                            
                    }
                }
                Console.WriteLine("Would you like to continue? Enter yes if you would like to continue: ");
                continue1 = Console.ReadLine();
                if (continue1 == "yes") 
                {
                    redMarker = 0;
                    whiteMarker = 0;
                    guessCode = null;
                    startCode = null;
                    gameRunning = true; 
                }
                else {
                    Console.WriteLine("Thanks for playing");
                    gameRunning = false;
                    Environment.Exit(0);
                }

            }
        }
    }
}
