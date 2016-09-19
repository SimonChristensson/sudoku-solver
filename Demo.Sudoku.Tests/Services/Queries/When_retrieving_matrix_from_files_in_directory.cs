using System.Collections.Generic;
using Demo.Sudoku.Services;
using FluentAssertions;
using Machine.Specifications;
using Rhino.Mocks;

namespace Demo.Sudoku.Tests.Services.Queries
{
    [Subject(typeof(DataQueries))]
    public class When_retrieving_matrix_from_files_in_directory : DataQueriesSpecs
    {
        protected static IEnumerable<IEnumerable<int?>> response;
        protected static string fileContentResult;

        Establish context = () =>
        {
            directory = MockRepository.GenerateStub<IDirectoryService>();
            fileContentResult = A<string>();
            directory.Stub(f => f.ReadFile()).Return(fileContentResult);
        };

        Because of = () =>
            response = sut.GetSudokuBoard(directory);

        It should_return_a_matching_result_set = () =>
            response.Should().NotBeEmpty();
    }
}
