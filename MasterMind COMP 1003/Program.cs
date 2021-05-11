using System;

namespace MasterMind_COMP_1003
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameRunning = true;
            int whiteMarker;
            string[] startCode = new string[4];
            int redMarker;
            bool guessing;
            string[] guessCode = new string[4];
            int attempts;

            while (gameRunning == true)
            {
                bool incorrect = false;
                for (int x = 0; x < 4; x++)
                {
                    Console.WriteLine("Enter Position, "+(x+1));
                    startCode[x] = Console.ReadLine();
                    Console.Clear();
                }
                int no = 0;
                redMarker = 0;
                attempts = 0; guessing = true;
                whiteMarker = 0;
                string continue1 = string.Empty;
                while (redMarker < 4 && attempts < 10)
                {
                    attempts++;
                    for (int i = 0; i < guessCode.Length; i++)
                    {
                            Console.WriteLine("Guess code position " + (i + 1) + ": ");
                            guessCode[i] = Console.ReadLine();
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

                    if (redMarker == 4)
                    {
                        Console.WriteLine("Well done guesser you've won");
                    }
                    else { Console.WriteLine("Incorrect try again you have "+ (10-attempts) + " attempts left: "); }
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
