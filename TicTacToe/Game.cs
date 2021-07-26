using System;
using System.Linq;
namespace TicTacToe
{
    public class Game
    {
        // Tic Tac Toe is played by 2 players using a board showing 9 spaces;
        // the spaces are arranged in 3 rows of 3 columns each.
        //
        // The spaces are numbered from 1 to 9 in row major order. To place
        // a mark in the top left corner, the player enters "1", to place a
        // mark in the second row, second column (the center space), the player
        // enters "5" and so on.
        //
        // Players take turns placing a mark into one of the nine unoccupied
        // spaces on the board.  The player that goes first is assigned 'x' as
        // their mark, and the second player is assigned 'o' as their mark.
        //
        // The object of the game is to be the first player who can place three
        // marks in any of the rows, columns or diagonals on the board.
        //
        // The first player to accomplish this declares "Tic tac toe, three in
        // a row" and wins the game.
        //
        // If after all marks are placed neither player achieves three in a row,
        // the game ends in a stalemate.

        public static bool SpaceIsValid(short space)
        {
            return Board.SpaceIsValid(space);
        }

        public bool SpaceIsAvailable(short space)
        {
            return board.SpaceIsAvailable(space);
        }

        public Player NextPlayer(Player player)
        {
            return (player == null || player.Name == Player2.Name ? Player1 : Player2);
        }

        public string TextState => board.TextState;

        public Game AddMove(short space, Player player)
        {
            return new Game(board.AddMove(space, player.Mark));
        }

        public bool IsPlayable => board.Condition == Board.BoardConditionTypes.Playable;
        public string TextResult(Player player)
        {
            string result;
            switch (board.Condition) {
                case Board.BoardConditionTypes.Won:
                    result = $"{player.Name} wins!";
                    break;
                case Board.BoardConditionTypes.Stale:
                    result = "This game is a stalemate.";
                    break;
                default:
                    result = "Unexpected reuslt. Are you cheating?";
                    break;
            }
            return result;
        }

        public enum MarkType { Empty = ' ', X = 'x', O = 'o' };
        public enum SpaceType
        {
            TOP_LEFT = 1, TOP_CENTER = 2, TOP_RIGHT = 3,
            MIDDLE_LEFT = 3, MIDDLE_CENTER = 4, MIDDLE_RIGHT = 5,
            BOTTOM_LEFT = 6, BOTTOM_CENTER = 7, BOTTOM_RIGHT = 9
        }
        public const string INSTRUCTIONS = "\n"
            + "Instructions:\n"
            + "\n"
            + "When prompted, enter the number (1 - 9) coresponding to\n"
            + "the space on the board where you wish to place your mark.\n"
            + "\n"
            + "The spaces on the board are numbered as follows:\n"
            + "1|2|3\n"
            + "-+-+-\n"
            + "4|5|6\n"
            + "-+-+-\n"
            + "7|8|9\n"
            + "\n";

        public Player Player1 => new Player("Player 1", 'x', 1);
        public Player Player2 => new Player("Player 2", 'o', 2);

        private Board board;

        public Game() => board = new Board();

        public Game(Board board)
        {
            this.board = board;
        }
    }
}
