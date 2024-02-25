using System.Runtime.InteropServices;
using Google.OrTools.Sat;

namespace Nonogram_Solver;

class Program
{
    static void Main(string[] args)


    {
        Nonogram n = new Nonogram();
        string input = "";
        for (int i = 0; i < 50; i++)
        {
            List<int> row = new List<int>();
            Console.Write("Enter Values for Row or leave blank to start Columns: ");
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;
            string[] inStrs = input.Split(' ');
            int inVal = 0;
            for (int j = 0; j < inStrs.Length; j++)
            {
                if (!int.TryParse(inStrs[j], out inVal))
                {
                    Console.WriteLine("Input is Not Valid. Please Try Again");
                    i--;
                    break;
                }
                row.Add(inVal);
            }
            if (row.Count == inStrs.Count())
            {
                n.Rows.Add(row);
            }
        }

        for (int i = 0; i < 50; i++)
        {
            List<int> col = new List<int>();
            Console.Write("Enter Values for Columns or leave blank solve: ");
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;
            string[] inStrs = input.Split(' ');
            int inVal = 0;
            for (int j = 0; j < inStrs.Length; j++)
            {
                if (!int.TryParse(inStrs[j], out inVal))
                {
                    Console.WriteLine("Input is Not Valid. Please Try Again");
                    i--;
                    break;
                }
                col.Add(inVal);
            }
            if (col.Count == inStrs.Count())
            {
                n.Cols.Add(col);
            }
        }

        int[,] solution = NonoSolver.SolveNonogram(n);
        for(int i = 0; i < solution.GetLength(0); i++){
            for(int j = 0; j < solution.GetLength(1); j++){
                Console.Write(solution[i,j] == 1 ? "█":" ");
            }
            Console.Write("\n");
        }
    }


}
