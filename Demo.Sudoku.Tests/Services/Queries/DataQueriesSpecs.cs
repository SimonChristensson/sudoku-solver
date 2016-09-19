using Demo.Sudoku.Services;
using Machine.Specifications;

namespace Demo.Sudoku.Tests.Services.Queries
{
    public class DataQueriesSpecs : WithSubject<DataQueries>
    {
        protected static IDirectoryService directory;

        Establish context = () =>
        {
            sut = A<DataQueries>();
        };
    }
}
