using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_O
{
    delegate void BoardActionHandler(Board sender, bool Player);
    class Board
    {
        byte Size;
        bool?[,] XO;
        bool Player = false;

        public event BoardActionHandler Win;
        public event BoardActionHandler Draw;
        public Board(BoardActionHandler Win, BoardActionHandler Draw) : this(3)
        {
            this.Win += Win;
            this.Draw += Draw;
        }
        private Board(byte Size)
        {
            this.Size = Size;
            XO = new bool?[Size, Size];
        }
        //clone constructor
        private Board(byte Size, bool?[,] XO, BoardActionHandler Win, BoardActionHandler Draw):this(Win, Draw)
        {
            this.Size = Size;
            this.XO = (bool?[,])XO.Clone();
        }

        public void Play(byte i, byte j)
        {
            if (i < Size && j < Size)
            {
                if (XO[i, j] == null)
                {
                    XO[i, j] = Player;
                    Player = !Player;
                    //calculate board and call an action
                    for (byte l = 0; l < Size; l++)
                    {
                        if(isWinColumn(l) != null)
                        {
                            Win(this, isWinColumn(l)==true? true :false);
                        }
                        if(isWinRow(l) != null)
                        {
                            Win(this, isWinRow(l) == true ? true : false);
                        }
                    }
                    for (int l = 0; l < 2; l++)
                    {
                        if(isWinDiagonal(l%2 == 0)!= null)
                        {
                            Win(this, isWinDiagonal(l % 2 == 0) == true ? true : false);
                        }
                    }
                }
                else
                    throw new Exception("this cell is already full, try again!!");
            }
            else
                throw new Exception("index is greater than " + Size + " the board size");
        }


        private bool? isWinRow(byte i)
        {
            for (int k = 0; k < Size; k++)
            {
                if (XO[i, k] == null)
                    return null;
            }
            if (XO[i, 0] == XO[i, 1] && XO[i, 1] == XO[i, 2] && XO[i, 2] == XO[i,0])
                return XO[i, 0];
            return null;
        }

        private bool? isWinColumn(byte j)
        {
            for (int k = 0; k < Size; k++)
            {
                if (XO[k, j] == null)
                    return null;
            }
            if (XO[0,j] == XO[1,j]  && XO[1, j] == XO[2,j] && XO[2, j] ==XO[0,j])
                return XO[0,j];
            return null;
        }

        private bool? isWinDiagonal(bool x)
        {
            if(x)
            {
                for (int i = 0; i < Size; i++)
                {
                    if (XO[i, i] == null)
                        return null;
                }
                if (XO[0, 0] == XO[1, 1] && XO[1, 1] == XO[2, 2] && XO[2, 2] == XO[0,0])
                    return XO[0,0];
                return null;
            }

            for (int i = 0; i < Size; i++)
            {
                if (XO[i, 2-i] == null)
                    return null;
            }
            if (XO[0, 2] == XO[1, 1] && XO[1, 1] == XO[2, 0] && XO[2, 0] ==XO[0,2])
                return XO[0, 0];
            return null;
        }

        public override string ToString()
        {
            string Retrun = "";
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (XO[i, j] == null)
                        Retrun += "null ";
                    else
                        Retrun += XO[i, j]+ " ";
                }
                Retrun += "\n";
            }
            return Retrun;
        }
        public Board Clone()
        {
            return new Board(Size, XO, Win, Draw);
        }
    }
}
