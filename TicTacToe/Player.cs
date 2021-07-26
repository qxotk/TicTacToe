using System;
namespace TicTacToe
{
    public class Player
    {
        public string Name { get; private set; }
        public char Mark { get; private set; }
        public short Ordinal { get; private set; }

        public Player(string name, char mark, short ordinal)
        {
            Name = name;
            Mark = mark;
            Ordinal = ordinal;
        }

        private Player()
        {
        }
    }
}
