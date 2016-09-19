using Machine.Specifications;

namespace Demo.Sudoku.Tests
{
    public class WithSubject<TSubject> : WithAutoData
    {
        protected static TSubject sut;

        Establish context = () =>
            sut = A<TSubject>();
    }
}
