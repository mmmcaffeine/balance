using System;
using FluentAssertions;
using Xunit;

namespace Dgt.Balance
{
    public class BalancedCalculatorTests
    {
        [Fact]
        public void IsBalanced_Should_ThrowNotImplementedException()
        {
            // Arrange
            Action action = () => _ = BalancedCalculator.IsBalanced();

            // Act, Assert
            action.Should().Throw<NotImplementedException>();
        }
    }
}