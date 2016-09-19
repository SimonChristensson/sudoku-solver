using System.Collections.Generic;
using Demo.Sudoku.Services;
using FluentAssertions;
using Machine.Specifications;
using Rhino.Mocks;

namespace Demo.Sudoku.Tests.Services.Queries
{
    [Subject(typeof(DataQueries))]
    public class When_retrieving_the_names_of_all_data_files : DataQueriesSpecs
    {
        protected static IEnumerable<string> response;
        //protected static IDirectoryService directory;
        protected static IEnumerable<string> fileNamesResultSet;

        Establish context = () =>
                            {
                                directory = MockRepository.GenerateStub<IDirectoryService>();
                                fileNamesResultSet = Many<string>();
                                directory.Stub(f => f.GetFiles()).Return(fileNamesResultSet);
                            };

        Because of = () =>
            response = sut.GetStoredDataFileNames(directory);

        It should_return_a_matching_result_set = () =>
            response.Should().Equal(fileNamesResultSet);
    }
}
