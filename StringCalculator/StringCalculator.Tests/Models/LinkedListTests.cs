using Microsoft.Extensions.Logging;
using Moq;
using StringCalculator.App.Interfaces;
using Xunit;

namespace StringCalculator.Tests.Models
{
    public class LinkedListTests
    {
        private readonly Mock<ILogger<App.Models.LinkedList<int>>> _mockLogger;

        public LinkedListTests()
        {
            _mockLogger = new Mock<ILogger<App.Models.LinkedList<int>>>();
        }

        [Fact]
        public void Insert_AtHead_ShouldInsertCorrectly()
        {
            // Arrange
            ILinkedList<int> linkedList = new App.Models.LinkedList<int>(_mockLogger.Object);

            // Act
            linkedList.Insert(1, 0);
            linkedList.Insert(2, 0); // Insert at head
            linkedList.PrintList();

            // Assert
            VerifyLoggedOutput("Output: 2 -> 1 -> null");
        }

        [Fact]
        public void Insert_AtPosition_ShouldInsertCorrectly()
        {
            // Arrange
            ILinkedList<int> linkedList = new App.Models.LinkedList<int>(_mockLogger.Object);

            // Act
            linkedList.Insert(1, 0);
            linkedList.Insert(2, 1);
            linkedList.Insert(3, 1); // Insert at position 1
            linkedList.PrintList();

            // Assert
            VerifyLoggedOutput("Output: 1 -> 3 -> 2 -> null");
        }

        [Fact]
        public void Delete_AtHead_ShouldDeleteCorrectly()
        {
            // Arrange
            ILinkedList<int> linkedList = new App.Models.LinkedList<int>(_mockLogger.Object);
            linkedList.Insert(1, 0);
            linkedList.Insert(2, 1);

            // Act
            linkedList.Delete(0); // Delete head
            linkedList.PrintList();

            // Assert
            VerifyLoggedOutput("Output: 2 -> null");
        }

        [Fact]
        public void Delete_AtPosition_ShouldDeleteCorrectly()
        {
            // Arrange
            ILinkedList<int> linkedList = new App.Models.LinkedList<int>(_mockLogger.Object);
            linkedList.Insert(1, 0);
            linkedList.Insert(2, 1);
            linkedList.Insert(3, 2);

            // Act
            linkedList.Delete(1); // Delete at position 1
            linkedList.PrintList();

            // Assert
            VerifyLoggedOutput("Output: 1 -> 3 -> null");
        }

        [Fact]
        public void Delete_AtInvalidPosition_ShouldThrowException()
        {
            // Arrange
            ILinkedList<int> linkedList = new App.Models.LinkedList<int>(_mockLogger.Object);
            linkedList.Insert(1, 0);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => linkedList.Delete(2)); // Invalid position
        }

        [Fact]
        public void Insert_AtInvalidPosition_ShouldThrowException()
        {
            // Arrange
            ILinkedList<int> linkedList = new App.Models.LinkedList<int>(_mockLogger.Object);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => linkedList.Insert(1, 2)); // Invalid position
        }

        [Fact]
        public void PrintList_EmptyList_ShouldOnlyLogNull()
        {
            // Arrange
            ILinkedList<int> linkedList = new App.Models.LinkedList<int>(_mockLogger.Object);

            // Act
            linkedList.PrintList();

            // Assert
            VerifyLoggedOutput("Output: null");
        }

        [Fact]
        public void Insert_NegativePosition_ShouldThrowException()
        {
            // Arrange
            ILinkedList<int> linkedList = new App.Models.LinkedList<int>(_mockLogger.Object);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => linkedList.Insert(1, -1)); // Negative position
        }

        private void VerifyLoggedOutput(string expectedMessage)
        {
            _mockLogger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Information),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString() == expectedMessage),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }
    }
}
