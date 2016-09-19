using System;
using System.Collections.Generic;
using System.ServiceModel.Web;
using System.Web.Script.Serialization;

namespace Demo.Sudoku.Services
{
    public class WebServices : IWebServices
    {
        private readonly IDataQueries _dataQueries;
        private readonly ISudokuQueries _sudokuQueries;
        
        public WebServices(IDataQueries dataQueries, ISudokuQueries sudokuQueries)
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            _dataQueries = dataQueries;
            _sudokuQueries = sudokuQueries;
        }

        public IEnumerable<string> GetStoredDataFileNames(string path)
        {
            var fileNames = _dataQueries.GetStoredDataFileNames(GetCurrentDirectoryInfo(path, null));
            return fileNames;
        }

        public IEnumerable<IEnumerable<int?>> GetSodukuBoard(string fileName)
        {
            return _dataQueries.GetSudokuBoard(GetCurrentDirectoryInfo(null, fileName));
        }

        public bool SodokuIsValid(string jsonBoard)
        {
            return _sudokuQueries.SodokuIsValid(GetMatrixFromJson(jsonBoard));
        }

        public string CheckLevel(string jsonBoard)
        {
            return _sudokuQueries.CheckLevel(GetMatrixFromJson(jsonBoard));
        }

        public IEnumerable<IEnumerable<int?>> SolveSudoku(string jsonBoard)
        {
            return _sudokuQueries.SolveSoduko(GetMatrixFromJson(jsonBoard));
        }

        private DirectoryService GetCurrentDirectoryInfo(string path, string fileName)
        {
            if (string.IsNullOrEmpty(path))
                path = AppDomain.CurrentDomain.BaseDirectory + "/" + "Data";

            return new DirectoryService(path +(string.IsNullOrEmpty(fileName) ? "" : ("/" + fileName)));
        }

        private List<List<int?>> GetMatrixFromJson(string jsonMatrix)
        {
            JavaScriptSerializer jscript = new JavaScriptSerializer();
            Board board = jscript.Deserialize<Board>(jsonMatrix);
            return board.Matrix;
        }
    }
}  