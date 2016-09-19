using System.Collections.Generic;

namespace Demo.Sudoku.Services
{
    public interface IDataQueries
    {
        IEnumerable<string> GetStoredDataFileNames(IDirectoryService path);
        IEnumerable<IEnumerable<int?>> GetSudokuBoard(IDirectoryService path);
    }
}
