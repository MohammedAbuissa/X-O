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
            Board b = new Board(WinAction, DrawAction);
            Agent Arya = new Agent();
            while (Going)
            {
                Arya.Play(b);
                Console.WriteLine(b);
                if (Going)
                {
                    Console.WriteLine("Your Turn");
                    byte i = byte.Parse(Console.ReadLine());
                    byte j = byte.Parse(Console.ReadLine());
                    b.Play(i, j);
                    Console.WriteLine(b);
                    Arya.Advance(b);
                }
            }

            ////test AlphaBetaNode
            //AlphaBetaNode k = new AlphaBetaNode(false);
            //k.Expnad();
            //PrintTree(k);
            Console.ReadLine();
        }

        static void PrintTree(AlphaBetaNode Node)
        {
            Console.WriteLine(Node.Alpha);
            Console.WriteLine(Node.Beta);
            Console.WriteLine(Node.Value);
            Console.WriteLine(Node.Data);
            foreach (var Child in Node.Children)
            {
                Console.WriteLine(Child.Alpha);
                Console.WriteLine(Child.Beta);
                Console.WriteLine(Child.Value);
                Console.WriteLine(Child.Data);
            }
            Console.WriteLine("+++++++++++++++++++++++++");
            foreach (var item in Node.Children)
            {
                PrintTree(item);
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
