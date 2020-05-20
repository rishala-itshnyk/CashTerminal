using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace CashTerminal.Tests
{
    [TestFixture]
    public class CashTerminalTests
    {
        private CashTerminal _cashTerminal;

        [SetUp]
        public void Setup()
        {
            _cashTerminal = new CashTerminal();
        }

        [Test]
        public void DispenseOptimizedCash_ShouldDispenseCorrectDenominations()
        {
            // Arrange
            int withdrawalAmount = 700;
            var expectedOutput = new StringWriter();
            Console.SetOut(expectedOutput);

            // Act
            _cashTerminal.DispenseOptimizedCash(withdrawalAmount);

            // Assert
            var output = expectedOutput.ToString();
            Assert.That(output, Does.Contain("1 x 500 UAH"));  // Expecting 1 x 500
            Assert.That(output, Does.Contain("1 x 200 UAH"));  // Expecting 1 x 200
        }

        [Test]
        public void DispenseCustomCash_ShouldDispenseBasedOnUserSelection()
        {
            // Arrange
            int withdrawalAmount = 600;
            var selectedDenominations = new List<int> { 500, 100 };
            var expectedOutput = new StringWriter();
            Console.SetOut(expectedOutput);

            // Act
            _cashTerminal.DispenseCustomCash(withdrawalAmount, selectedDenominations);

            // Assert
            var output = expectedOutput.ToString();
            Assert.That(output, Does.Contain("1 x 500 UAH"));
            Assert.That(output, Does.Contain("1 x 100 UAH"));
        }

        [Test]
        public void ShowAvailableDenominations_ShouldDisplayAvailableDenominations()
        {
            // Arrange
            var expectedOutput = new StringWriter();
            Console.SetOut(expectedOutput);

            // Act
            _cashTerminal.ShowAvailableDenominations();

            // Assert
            var output = expectedOutput.ToString();
            Assert.That(output, Does.Contain("500 UAH"));
            Assert.That(output, Does.Contain("200 UAH"));
            Assert.That(output, Does.Contain("100 UAH"));
        }
    }
}
