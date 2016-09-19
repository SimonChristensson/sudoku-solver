using System.Collections.Generic;

namespace Demo.Sudoku.Services
{
    public interface ISudokuQueries
    {
        bool SodokuIsValid(List<List<int?>> matrix);

        List<List<int?>> SolveSoduko(List<List<int?>> matrix);
        
        string CheckLevel(List<List<int?>> matrix);
    }
}
