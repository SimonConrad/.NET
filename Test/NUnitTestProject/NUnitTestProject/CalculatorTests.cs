using ClassLibrary;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;

namespace NUnitTestProject
{
    // TODO Wykorzytsaæ wiêcej z API NUnit-a
    // TODO Wykorzytsaæ wiêcej z API FluentAssertions
    // TODO Wykorzytsaæ wiêcej z API Moq

    // TODO U¿yæ Bogus-a wdo mockowanie danych
    // TODO Zapi¹æ automat do wylicania pokrycia testami kodu

    // INFO Dobre praktyki: test jednostkowy testuje publiczne API, w testach trzyammy regu³ SOLID, jesli mamy wymagnie dok³adne mo¿na pisaæ TDDD, Arrange Act, Assert, testy jednostkowe troche jak BDD
    public class CalculatorTests
    {
        //[SetUp]
        //public void Setup()
        //{

        //}


        [Test]
        public void CalculatorTestsDivide_WhenProperArguments_ThenProperResult()
        {
            // Arrange
            var dependency = new Mock<ICalculatorDependency>();
            var calculator = new Calculator(dependency.Object);

            // Act 
            var res = calculator.Divide(2, 2);

            // Assert
            res.Should().Be(1);
        }

        [Test]
        public void CalculatorTestsDivide_WhenZeroInDenominator_ThenThrowArgumentException()
        {
            // Arrange
            var dependency = new Mock<ICalculatorDependency>();
            var calculator = new Calculator(dependency.Object);

            // Act 
            Action actionToTest = () =>
            {
                calculator.Divide(1, 0);
            };

            // Assert
            actionToTest.Should().Throw<ArgumentException>();
        }

        // TDD - Red, Green, Refactor
        [Test]
        public void CalculatorTestsSum_WhenSumBelowOrEqulas5_ThenDoNormalSumming()
        {
            // Arrange
            var dependency = new Mock<ICalculatorDependency>();
            var calculator = new Calculator(dependency.Object);

            // Act
            double result = calculator.Sum(1, 2);

            // Assert
            result.Should().Be(3);
        }

        // TDD - Red, Green, Refactor
        [Test]
        public void CalculatorTestsSum_WhenSumExtends5_ThenReturn5()
        {
            // Arrange
            var dependency = new Mock<ICalculatorDependency>();
            var calculator = new Calculator(dependency.Object);

            // Act
            double result = calculator.Sum(3, 7);

            // Assert
            result.Should().Be(5);
        }
    }
}