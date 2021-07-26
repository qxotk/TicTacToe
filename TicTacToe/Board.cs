using System;
using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        public const short BOARD_SIZE = 3;
        public const short BOARD_LENGTH = 9;

        private const char EMPTY = ' ';
        private char[] state = new char[BOARD_SIZE * BOARD_SIZE]
        {
                EMPTY, EMPTY, EMPTY,
                EMPTY, EMPTY, EMPTY,
                EMPTY, EMPTY, EMPTY
        };

        public static bool SpaceIsValid(short space)
        {
            return space >= 1 && space <= BOARD_LENGTH;
        }

        public bool SpaceIsAvailable(short space)
        {
            return SpaceIsValid(space) && state[space - 1] == EMPTY;
        }

        public Board AddMove(short space, char mark)
        {
            state[space-1] = mark;
            eval(mark);
            return new Board(state, Condition);
        }

        public string TextState =>
            "\n"
            + $"{state[0]}|{state[1]}|{state[2]}\n"
            + $"-+-+-\n"
            + $"{state[3]}|{state[4]}|{state[5]}\n"
            + $"-+-+-\n"
            + $"{state[6]}|{state[7]}|{state[8]}\n";

        public Board()
        {
            Condition = BoardConditionTypes.Playable;
        }

        private Board(char[] state, BoardConditionTypes condition)
        {
            this.Condition = condition;
            this.state = state;
        }

        public enum BoardConditionTypes {Playable, Won, Stale};
        public BoardConditionTypes Condition { get; private set; }

        private void eval(char mark)
        {
            bool row1 = (state[0] == mark && state[1] == mark && state[2] == mark);
            bool row2 = (state[3] == mark && state[4] == mark && state[5] == mark);
            bool row3 = (state[6] == mark && state[7] == mark && state[8] == mark);
            bool col1 = (state[0] == mark && state[3] == mark && state[6] == mark);
            bool col2 = (state[1] == mark && state[4] == mark && state[7] == mark);
            bool col3 = (state[2] == mark && state[5] == mark && state[8] == mark);
            bool diag1 = (state[0] == mark && state[4] == mark && state[8] == mark);
            bool diag2 = (state[2] == mark && state[4] == mark && state[6] == mark);

            bool hasWinner = (row1 || row2 || row3 || col1 || col2 || col3 || diag1 || diag2);
            bool noMovesLeft = !state.ToList<char>().Contains(' ');

            Condition = hasWinner ? BoardConditionTypes.Won : noMovesLeft ? BoardConditionTypes.Stale : BoardConditionTypes.Playable;
        }
    }
}
