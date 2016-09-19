using System.Collections.Generic;

namespace Demo.Sudoku.Services
{
    public interface IDirectoryService
    {
        IEnumerable<string> GetFiles();

        string ReadFile();
    }
}
