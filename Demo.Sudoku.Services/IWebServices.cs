using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Demo.Sudoku.Services
{
    [ServiceContract]
    public interface IWebServices
    {
        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<string> GetStoredDataFileNames(string path);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<IEnumerable<int?>> GetSodukuBoard(string fileName);

        [OperationContract]
        [WebGet(UriTemplate = "SodokuIsValid?board={board}",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool SodokuIsValid(string board);

        [OperationContract]
        [WebGet(UriTemplate = "CheckLevel?board={board}",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string CheckLevel(string board);


        [OperationContract]
        [WebGet(UriTemplate = "SolveSudoku?board={board}",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<IEnumerable<int?>> SolveSudoku(string board);


    }
}