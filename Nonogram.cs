using Newtonsoft;
namespace Nonogram_Solver{
    
    public class Nonogram{

        public List<List<int>> Rows {get;set;}
        public List<List<int>> Cols {get;set;}
        public List<List<bool>> Grid {get;set;}

        public Nonogram(){
            Rows = new List<List<int>>();
            Cols = new List<List<int>>();
        }

      
    }
}

