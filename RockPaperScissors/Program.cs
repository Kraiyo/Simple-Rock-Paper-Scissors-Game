using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        public Int32 win = 0;
        public Int32 lose = 0;
        public Int32 draw = 0;

        static void Main(string[] args)
        {
            Program game = new Program();
            game.GameinitMethod();
        }

        private void GameinitMethod()///The games Init method
        {

            System.Console.WriteLine("Welcome to a classic game of Rock Paper Scissors.\nWould you like to play: Yes or No");
            string gameStart = System.Console.ReadLine();

            string gameStartL = gameStart.ToLower();

            if (gameStartL == "yes")///Will Start a new game
            {
                GameStart();
            } else if (gameStartL == "no")///Will close out the console
            {
                GameEnd();
            } else///Expection handeler for any thing but the two answers
            {
                System.Console.WriteLine("Your answer was not reconized. Please try again.");
                GameinitMethod();
            }
        }

        private void GameStart()///So many method calls
        {
            Int32 aiV = AI_Answer();

            Int32 uV = User_Answer();

            Judgement(aiV, uV);///Uses the returned values of the user and AI methods, to find who won (if anyone)

        }

        private Int32 AI_Answer()///A method to decide the AIs answer
        {
            Random rnd = new Random();

            Int32 aiAnswer = rnd.Next(0, 3);///Generates a random number from 0 to 2. 

            /*
             * 0 = Rock. 
             * 1 = Paper. 
             * 2 = Scissors.
             */

            return aiAnswer;
        }

        private Int32 User_Answer()///A method to ask the use for their answer
        {
            System.Console.WriteLine("Rock, Paper, or Scissors?");
            string uAnswer = System.Console.ReadLine();

            switch (uAnswer.ToLower())///Converts the users answer into one of three numbers for calculation later
            {
                case "rock":
                    return 0;
                case "paper":
                    return 1;
                case "scissors":
                    return 2;
                default:
                    System.Console.WriteLine("Your pick was invalid, please try again.");///In case the user mispells something, or mistypes something
                    break;
            }

            return User_Answer();///If the user mistypes something, the method will run again till it gets a valid answer
        }

        private void Judgement(Int32 aiValue, Int32 uValue)///A method that figures out if the match is a win, lose, or draw.
        {
            /*  | 0 | 1 | 2 | User Win/Lose/Draw Guide
             * 0| D | W | L |
             * 1| L | D | W |
             * 2| W | L | D |
             */

            bool?[,] truthTable = new bool?[,] { { null, false, true }, { true, null, false }, { false, true, null } };///2d array that works like the above guide

            Int32 aiV = aiValue;
            Int32 uV = uValue;

            Boolean? winner = truthTable[uV, aiV];

            switch (winner)
            {
                case true:///A winner is you
                    System.Console.WriteLine("You've Won!");
                    win += 1;
                    break;
                case false:///Not only do you lose, but. . .
                    System.Console.WriteLine("Seems that you've lost.");
                    lose += 1;
                    break;
                case null:///Draw
                    System.Console.WriteLine("Not a win, but not a lose. Draw.");
                    draw += 1;
                    break;
                default:
                    System.Console.WriteLine("Someone went wrong somewhere. Please go to the programmers den and wake it from it's slumber with the error message.");
                    break;
            }
            Replay();///No matter what, it will ask if you want to replay.

        }

        private void GameEnd()///A method which ends the game and closes the console
        {
            Environment.Exit(0);
        }

        private void Replay()///A method to see if user would like to replay or end the game
        {
            System.Console.WriteLine("Would you like to play again? Yes or No.");
            string replay = System.Console.ReadLine();
            string replayL = replay.ToLower();

            if (replayL == "yes")
            {
                GameStart();
            }
            else
            {
                System.Console.WriteLine("Total Wins:{0} \nTotal Loses:{1} \nTotal Draws:{2}", win, lose, draw);
                System.Console.ReadLine();
                GameEnd();
            }
        }
    }
}
