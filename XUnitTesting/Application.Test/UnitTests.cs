using System;
using Xunit;

namespace Application.Test
{
    public class UnitTests
    {
        [Fact]
        public void TestDivide()
        {
            decimal output = Logics.Divide(4, 2);
            Assert.Equal(2, output); // Assert.Equal(expected, actual)
        }

        [Fact]
        public void TestDivide2()
        {
            decimal output = Logics.Divide(1, 3);
            Assert.Equal(0.333M, output, 3); 
        }

        [Theory]
        [InlineData(5, 4, 1.25)]
        [InlineData(10, 5, 2)]
        [InlineData(121, 11, 11)]
        public void TestDivideMultipleInputs(decimal n, decimal d, decimal expected)
        {
            decimal output = Logics.Divide(n, d);
            Assert.Equal(expected, output);
        }

        [Fact]
        public void TestDivideByZero() // Test for expection
        {
            decimal output;
            Assert.Throws<DivideByZeroException>(() => output = Logics.Divide(1, 0));
        }
    }
}