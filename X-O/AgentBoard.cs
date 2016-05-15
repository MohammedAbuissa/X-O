using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace X_O
{
    struct Pair
    {
        public byte X { get; set; }
        public byte Y { get; set; }
        public Pair(byte X, byte Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
    class AgentBoard : Board
    {
        public AgentBoard(BoardActionHandler Win, BoardActionHandler Draw):base(Win, Draw)
        { }
        private AgentBoard(byte Size, bool?[,] XO, bool Player) : base(Size, XO, Player, null, null) { }
        public List<Pair> EmptyCells()
        {
            List<Pair> Return = new List<Pair>();
            for (byte i = 0; i < Size; i++)
            {
                for (byte j = 0; j < Size; j++)
                {
                    if (XO[i, j] == null)
                        Return.Add(new Pair(i, j));

                }
            }
            return Return;
        }
        public new AgentBoard Clone()
        {
            return new AgentBoard(Size, XO, Player);
        }
    }
}
