using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_O
{
    class Program
    {
        static bool Going = true;
        static void Main(string[] args)
        {
            //Board b = new Board(WinAction, DrawAction);
            //for (int i = 0; i < 4 && Going; i++)
            //{
            //    Console.WriteLine(b);
            //    byte x = byte.Parse(Console.ReadLine());
            //    byte y = byte.Parse(Console.ReadLine());
            //    b.Play(x, y);
            //}
            //Board c = b.Clone();
            //for (int i = 0; i < 5&& Going; i++)
            //{
            //    Console.WriteLine(c);
            //    byte x = byte.Parse(Console.ReadLine());
            //    byte y = byte.Parse(Console.ReadLine());
            //    c.Play(x, y);
            //}

            //test AlphaBetaNode
            AlphaBetaNode k = new AlphaBetaNode(false);
            k.Expnad();
            PrintTree(k);
            Console.ReadLine();
        }

        static void PrintTree(AlphaBetaNode Node)
        {
            Console.WriteLine(Node.Data);
            foreach (var Child in Node.Children)
            {
                PrintTree(Child);
            }
        }

        static void WinAction(Board b, bool Winner)
        {
            Going = false;
            Console.WriteLine(Winner + " has won!");
        }

        static void DrawAction(Board b, bool Args)
        {
            Going = false;
            Console.WriteLine("Draw");
        }
    }
}
