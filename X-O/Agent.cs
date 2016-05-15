using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_O
{
    class Agent
    {
        AlphaBetaNode Tree = new AlphaBetaNode(true);
        public Agent()
        {
            Tree.Expnad();
        }
        public void Play(Board board)
        {
            Tree = Tree.Children.Max();
            board.Play(Tree.Move);
        }

        public void Advance(Board board)
        {
            Tree = Tree.Children.Find(t => t.Data.CompareTo(board)==0);
        }
    }
}
