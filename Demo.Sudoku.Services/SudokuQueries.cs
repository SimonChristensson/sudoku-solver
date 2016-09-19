using System.Collections.Generic;
using System.Linq;

namespace Demo.Sudoku.Services
{
    public class SudokuQueries : ISudokuQueries
    {
        public bool SodokuIsValid(List<List<int?>> matrix)
        {
            int rowNr = 0;
            while (rowNr < matrix.Count)
            {
                int columnNr = 0;

                while (columnNr < matrix[0].Count)
                {
                    if (matrix[rowNr][columnNr] == null)
                    {
                        columnNr = columnNr + 1;
                        continue;
                    }

                    if (!IsUniqueColumnAndRow(matrix, rowNr, columnNr))
                        return false;

                    if (!SegmentContainsUniqueValues(matrix, rowNr, columnNr))
                        return false;

                    columnNr = columnNr + 1;
                }

                rowNr = rowNr + 1;
            }

            return true;
        }

        public List<List<int?>> SolveSoduko(List<List<int?>> matrix)
        {
            var rowNr = 0;
            var setters = new List<int>(); //Previous used values

            while (rowNr < matrix.Count)
            {
                var columnNr = 0;
              
                while (columnNr < matrix[0].Count) //Each column
                {
                    if (matrix[rowNr][columnNr] == null)
                    {
                        matrix[rowNr][columnNr] = 1;
                       
                        while (!IsValid(matrix, rowNr, columnNr))
                        {
                            matrix[rowNr][columnNr] = matrix[rowNr][columnNr]+1;
                            if (matrix[rowNr][columnNr] > 9) // Something is wrong => go back and try again
                            {
                                var at = setters[setters.Count - 1];

                                if (setters.Count > 1)
                                {
                                    matrix[rowNr][columnNr] = null;
                                    setters.RemoveAt(setters.Count - 1);
                                }

                                rowNr = at / 9;
                                columnNr = (at % 9);
                                matrix[rowNr][columnNr] = matrix[rowNr][columnNr] + 1;
                            }
                        }

                        setters.Add((rowNr * 9) + (columnNr));
                    }

                    columnNr = columnNr+1;
                }

                rowNr = rowNr + 1;
            }

            return matrix;
        }

        public string CheckLevel(List<List<int?>> matrix)
        {
            //number of backtracking
            //count clues
            //take solve time

            return "Still to be implemented";

        }

        private bool IsValid(List<List<int?>> matrix, int rowNr, int columnNr)
        {
            return (IsUniqueColumnAndRow(matrix, rowNr, columnNr) &&
                    SegmentContainsUniqueValues(matrix, rowNr, columnNr) && matrix[rowNr][columnNr] < 10);
        }

        private List<List<int?>> GetSegment(int rowNr, int columnNr, List<List<int?>> matrix)
        {
            int columnStart = (columnNr / 3)*3;
            int rowStart = (rowNr / 3)*3;
            var segmentRows = matrix.GetRange(rowStart, 3);
            return segmentRows.Select(segmentRow => segmentRow.GetRange(columnStart, 3)).ToList();
        }

        private bool SegmentContainsUniqueValues(List<List<int?>> matrix, int rowNr, int columnNr)
        {
            var segment = GetSegment(rowNr, columnNr, matrix);
            var allValues = segment.Select(row => row.Select(c => c).Where(value => value != null)).ToList();

            var list = new List<int?>();
            foreach (var row in allValues)
            {
                list.AddRange(row);
            }

            if (list.Distinct().Count() != list.Count())
                return false;

            return true;
        }

        private bool IsUniqueColumnAndRow(List<List<int?>> matrix, int rowNr, int columnNr)
        {
            var rowValues = matrix[rowNr].Where(r => r != null).ToList();

            if (rowValues.Distinct().Count() != rowValues.Count())
                return false;

            var columnValues = (from row in matrix where row[columnNr] != null select row[columnNr]).ToList();

            if (columnValues.Distinct().Count() != columnValues.Count)
                return false;

            return true;
        } 
    }
}
