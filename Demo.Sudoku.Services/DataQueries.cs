using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Demo.Sudoku.Services
{
    public class DataQueries : IDataQueries
    {
        public IEnumerable<string> GetStoredDataFileNames(IDirectoryService directoryService)
        {
            return directoryService.GetFiles();
        }

        public IEnumerable<IEnumerable<int?>> GetSudokuBoard(IDirectoryService directoryService)
        {
            var fileRows = GetTextRows(directoryService.ReadFile());
            return fileRows.Select(GetColumns);
        }

        private IEnumerable<int?> GetColumns(string line)
        {
            var columns = Regex.Matches(line, @"\w");
            return from Match column in columns select column.Value == "n" ? (int?)null : Convert.ToInt16(column.Value);
        }

        private IEnumerable<string> GetTextRows(string text)
        {
            var lines = text.Split(Environment.NewLine.ToCharArray());
            return lines.Where(line => !string.IsNullOrEmpty(line)).ToList();
        }
    }
}
