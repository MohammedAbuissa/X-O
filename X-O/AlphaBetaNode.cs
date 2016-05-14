using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_O
{
    class AlphaBetaNode
    {
        bool Type; //Maximizer or Minimizer
        public sbyte Alpha { get; set; }
        public sbyte Beta { get; set; }

        sbyte value;
        public sbyte Value
        {
            get
            {
                return value;
            }
            set
            {
                if (Type)
                {
                    //maximizer

                }
                else
                {
                    //minimizer

                }
            }
        }
    }
}
