using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_O
{
    class Agent
    {
        AlphaBetaNode Tree = new AlphaBetaNode(false);
        public void Play(Board board)
        {
             Tree.Children.Find(board);
        }
    }
}
