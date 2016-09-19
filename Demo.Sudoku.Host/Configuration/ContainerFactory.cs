using Autofac;
using Demo.Sudoku.Services;

namespace Demo.Sudoku.Host.Configuration
{
    public static class ContainerFactory
    {
        public static readonly IContainer Builder;

        static ContainerFactory()
        {
            Builder = RegisterDependencies();
        }
        public static IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DataQueries>().As<IDataQueries>();
            builder.RegisterType<SudokuQueries>().As<ISudokuQueries>();
            builder.RegisterType<WebServices>().As<IWebServices>();
            return builder.Build();
        }
    }
}
