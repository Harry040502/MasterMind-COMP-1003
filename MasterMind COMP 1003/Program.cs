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

            while (gameRunning == true)
            {
                Console.WriteLine("Code Maker please enter your code and don't let the breaker see");
                bool incorrect = false;
                for (int x = 0; x < 4; x++)
                {
                    Console.WriteLine("Enter Position, "+(x+1));
                    startCode[x] = Console.ReadLine();
                    Console.Clear();
                }
                int no = 0;
                redMarker = 0;
                attempts = 0;
                whiteMarker = 0;
                string continue1 = string.Empty;
                while (redMarker < 4 && attempts < 10)
                {
                    Dictionary<int, string> history = new Dictionary<int, string>();
                    history.Clear();
                    redMarker = 0;
                    attempts++;
                    for (int i = 0; i < guessCode.Length; i++)
                    {
                        Console.WriteLine("Guess code position " + (i + 1) + ": ");
                        guessCode[i] = Console.ReadLine();
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
                            for (no = 0; no < guessCode.Length; no++)
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
                            if (max == 4)
                            {
                                if (incorrect == true)
                                {
                                    Console.WriteLine("Not Correct ");
                                    incorrect = false;
                                }
                            }
                        }
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                    dict++;
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
                        Console.WriteLine("Well done guesser you've won");
                        history.Clear();
                    }
                    else { 
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
