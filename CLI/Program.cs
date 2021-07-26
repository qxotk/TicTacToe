using System;

using TicTacToe;

namespace CLI
{
    // cli consists of prompts and inputs.
    // Playing the game is a state machine of showing prompts, gathering input,
    // and moving to the next state upon the reuslt of each input.

    class MainClass
    {
        public static void Main(string[] args)
        {
            Message("Welcome to tictactoe.\n");
            Play();
            Message("Thanks for playing tictactoe.\n");
        }

        public static void Play()
        {
            if (PromptYesNo("Would you like to see the instructions?"))
            {
                Message(Game.INSTRUCTIONS);
            }

            do
            {
                Game game = new TicTacToe.Game();
                Message($"{game.Player1.Name}, you are {game.Player1.Mark}\n");
                Message($"{game.Player2.Name}, you are {game.Player2.Mark}\n");

                Message("Let's play...\n");
                Player playerUp = null;
                do
                {
                    Message(game.TextState);
                    playerUp = game.NextPlayer(playerUp);
                    short space = PromptForMove(game, playerUp);
                    game = game.AddMove(space, playerUp);
                } while (game.IsPlayable);
                Message(game.TextState);
                Message(game.TextResult(playerUp));
            } while (PromptYesNo("Another game?"));
        }

        public static bool PromptYesNo(string query)
        {
            string reply = null;
            do
            {
                reply = Prompt(query + " [y/n]: ").ToLower();
            } while (!reply.Equals("y") && !reply.Equals("n"));
            return reply.Equals("y");

        }

        public static string Prompt(string query)
        {
            Console.Write(query);
            return Console.ReadLine();
        }

        public static void Message(string message)
        {
            Console.WriteLine(message);
        }

        public static short PromptForMove(Game g, Player p)
        {
            short space = -1;
            do
            {
                Console.Write($"{p.Name}, enter your move [1 - 9]:");
                string entry = Console.ReadLine();
                if (!short.TryParse(entry, out space))
                {
                    Console.Write($"Your choice '{entry}' is  not a number.\nPlease enter a number between 1 and 9.\n");
                    continue;
                }

                if (!Game.SpaceIsValid(space))
                {
                    Console.Write($"Your choice '{space}' is not between 1 and 9.\nPlease enter a number between 1 and 9.\n");
                    continue;
                }

                if (!g.SpaceIsAvailable(space))
                {
                    Console.Write($"Space {space} has already been marked, you must choose a different space.\nPlease enter a number between 1 and 9.\n");
                    continue;
                }
                break;
            } while (true);
            return space;
        }
    }
}
