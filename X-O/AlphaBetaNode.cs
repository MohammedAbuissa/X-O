using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_O
{
    class AlphaBetaNode: IComparable<AlphaBetaNode>, IComparable<AgentBoard>
    {
        //root node consturctor
        public AlphaBetaNode(bool Type)
        {
            this.Type = Type;
            Alpha = sbyte.MinValue;
            Beta = sbyte.MaxValue;
            Data = new AgentBoard(Win, Draw);
            if (Type)
                Value = sbyte.MinValue;
            else
                Value = sbyte.MaxValue;
            Children = new List<AlphaBetaNode>();
            
        }
        //recursion constructor
        public AlphaBetaNode(AgentBoard Data, Pair Move, bool Type, sbyte Alpha, sbyte Beta) : this(Type)
        {
            this.Data = Data;
            this.Data.Win += Win;
            this.Data.Draw += Draw;
            this.Alpha = Alpha;
            this.Beta = Beta;
            this.Move = Move;
            Data.Play(Move);
        }
        public Pair Move { get; set; }
        //false Minimizer, true Maximizer, null leaf node 
        bool? Type { get; set; }
        public sbyte Alpha { get; private set; }
        public sbyte Beta { get; private set; }
        public List<AlphaBetaNode> Children { get; set; }
        public AgentBoard Data;
        sbyte value;
        public sbyte Value
        {
            get
            {
                return value;
            }
            private set
            {
                if (Type == true)
                {
                    //maximizer
                    if (value > Alpha)
                        Alpha = value;
                }
                else if (Type == false)
                {
                    //minimizer
                    if (value < Beta)
                        Beta = value;
                }
                this.value = value;
            }
        }

        private void Win(Board sender, bool Player)
        {
            if (Player)
                Value = 1;
            else
                Value = -1;
            Type = null;
        }
        private void Draw(Board sender, bool Player)
        {
            Value = 0;
            Type = null;
        }

        public void Expnad()
        {
            List<Pair> AvailablePlaces = Data.EmptyCells();
            if (Type != null)
                foreach (var item in AvailablePlaces)
                {
                    AlphaBetaNode Dummy = new AlphaBetaNode(Data.Clone(), item, Type == true ? false : true, Alpha, Beta);
                    Dummy.Expnad();//recursion
                    if (Type == true)
                    {
                        Value = Dummy.Value > Value ? Dummy.Value : Value;
                    }
                    else if (Type == false)
                    {
                        Value = Dummy.Value < Value ? Dummy.Value : Value;
                    }
                    Children.Add(Dummy);
                }
        }

        public int CompareTo(AlphaBetaNode other)
        {
            return Data.CompareTo(other.Data);
        }

        public int CompareTo(AgentBoard other)
        {
            return Data.CompareTo(other);
        }
    }
}
