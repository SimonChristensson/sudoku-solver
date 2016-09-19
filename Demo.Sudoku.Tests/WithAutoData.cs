using System;
using System.Collections.Generic;
using Machine.Specifications;
using Ploeh.AutoFixture;

namespace Demo.Sudoku.Tests
{
    public abstract class WithAutoData
    {
        protected static Fixture fixture;

        Establish context = () =>
        {
            fixture = new Fixture();
        };

        protected static T A<T>()
        {
            return fixture.Create<T>();
        }

        protected static T AFrozen<T>()
        {
            return fixture.Freeze<T>();
        }

        protected static IEnumerable<T> Many<T>(int count = 3)
        {
            return fixture.CreateMany<T>(count);
        }

        protected static IEnumerable<T> Many<T>(Action<T> with, int count = 3)
        {
            var values = fixture.CreateMany<T>(count);

            foreach (var value in values)
            {
                with(value);
            }

            return values;
        }
    }
}
