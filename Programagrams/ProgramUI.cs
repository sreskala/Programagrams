using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Programagrams
{
    public class ProgramUI
    {
        public void Run()
        {
            DisplayGreeting();
            Menu();
        }
        public void Menu()
        {
            bool keepPlaying = true;

            while(keepPlaying)
            {
                //easy text
                string easyPath = @"C:\Users\samsa\source\repos\Programagrams\Easy.txt";
                //medium text
                string mediumPath = @"C:\Users\samsa\source\repos\Programagrams\Medium.txt";
                //hard text
                string hardPath = @"C:\Users\samsa\source\repos\Programagrams\Hard.txt";
                //insane text
                string insanePath = @"C:\Users\samsa\source\repos\Programagrams\Insane.txt";

                Console.Clear();
                Console.WriteLine("Select the difficulty you’d like to challenge!: \n" +
                    "1. Easy \n" +
                    "2. Medium \n" +
                    "3. Hard \n" +
                    "4. (Possible Insane?) \n" +
                    "5. (Possible random as well) \n");

                bool correctChoice = false;

                while(!correctChoice)
                {
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            ModeChoose(easyPath);
                            Console.ReadLine();
                            correctChoice = true;
                            break;
                        case "2":
                            ModeChoose(mediumPath);
                            Console.ReadLine();
                            correctChoice = true;
                            break;
                        case "3":
                            ModeChoose(hardPath);
                            Console.ReadLine();
                            correctChoice = true;
                            break;
                        case "4":
                            ModeChoose(insanePath);
                            Console.ReadLine();
                            correctChoice = true;
                            break;
                        case "5":
                            string[] modes = { easyPath, mediumPath, hardPath, insanePath };
                            Random rand = new Random();
                            int chooseMode = rand.Next(modes.Length - 1);
                            ModeChoose(modes[chooseMode]);
                            Console.ReadLine();
                            correctChoice = true;
                            break;
                        default:
                            Console.WriteLine("Not a valid choice. Please only input numbers 1 - 5");
                            correctChoice = false;
                            break;
                    }
                }
                

                Console.WriteLine("Would you like to play again (y/n) ?");
                string playChoice = Console.ReadLine().ToLower().Trim();

                if (playChoice == "y")
                {
                    keepPlaying = true;
                } else if(playChoice == "n")
                {
                    keepPlaying = false;
                } else
                {
                    Console.WriteLine("Not a valid choice!");
                }
            }
            
        }

        //scramble method
        public string Scramble(string word)
        {
            //Randomizes the string word
            char[] array = word.ToCharArray();
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }
        public void ModeChoose(string path)
        {
            string text = File.ReadAllText(path);
            
            string[] difficulty = text.Split(',');

            Random randy = new Random();
            int wordNum = randy.Next(difficulty.Length - 1);
            string word = difficulty[wordNum].Trim();
            string scrambledWord = Scramble(word);
            Console.WriteLine(scrambledWord);


            bool wasGuessed = false;
            for(int i = 1; i < 4; i++)
            {
                string guess = Console.ReadLine();
                if (word == guess.ToLower().Trim())
                {
                    Console.WriteLine("Congrats you guessed the word correctly!");
                    Console.WriteLine($"The word was {word}. You took {i} attempt(s) to get it right!");
                    wasGuessed = true;
                    break;
                }
                else if (i == 3)
                {
                    Console.WriteLine("You ran out of attempts");
                    Console.WriteLine($"The correct word was {word}");
                } else
                {
                    Console.WriteLine("Try again!");
                }
            }

            if (wasGuessed)
            {
                Console.WriteLine("You win!");
            } else
            {
                Console.WriteLine("You lose");
            }
            
        }

        public void DisplayGreeting()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to Programagrams!");
            Console.WriteLine("Press any key to start the game.");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

