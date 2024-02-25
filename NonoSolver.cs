using Google.OrTools.Sat;
using Google.Protobuf;

namespace Nonogram_Solver;

public static class NonoSolver
{

    public static int[,] SolveNonogram(Nonogram n)
    {
        CpModel model = new CpModel();
        int rows = n.Rows.Count, cols = n.Cols.Count;
        BoolVar[,] cells = new BoolVar[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                cells[i, j] = model.NewBoolVar($"x{i}y{j}");
            }
        }

        for (int i = 0; i < rows; i++)
        {
            int[,] restrictions = getTuples(n.Rows[i], cols);
            model.AddAllowedAssignments(Extensions.getRow(cells, i)).AddTuples(restrictions);
        }

        for (int i = 0; i < cols; i++)
        {
            int[,] restrictions = getTuples(n.Cols[i], rows);
            model.AddAllowedAssignments(Extensions.getCol(cells, i)).AddTuples(restrictions);
        }

        CpSolver solver = new CpSolver();
        solver.Solve(model);

        int[,] returnArr = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                returnArr[i, j] = (int)solver.Value(cells[i, j]);
            }
        }
        return returnArr;
    }

    public static int[,] getTuples(List<int> inList, int size)
    {
        return Extensions.listTo2D(Extensions.stringsToIntLists(Extensions.generateRestrictionStrings(inList, size)));
    }
}