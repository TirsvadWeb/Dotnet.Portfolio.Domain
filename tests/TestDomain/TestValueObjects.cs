using TirsvadWeb.Portfolio.Domain.ValueObjects;

namespace TestDomain
{
    [TestClass]
    public sealed class TestValueObjects
    {
        [TestMethod]
        public void UriString_ValidAbsoluteUri_ShouldSetValue()
        {
            // Arrange
            var uri = "https://example.com/resource";

            // Act
            var uriString = new UriString(uri);

            // Assert
            Assert.AreEqual(uri, uriString.Value);
            Assert.AreEqual(uri, uriString.ToString());
        }

        [TestMethod]
        public void UriString_InvalidUri_ShouldThrowArgumentException()
        {
            // Arrange
            var invalidUri = "not a valid uri";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new UriString(invalidUri));
        }

        [TestMethod]
        public void UriString_RelativeUri_ShouldThrowArgumentException()
        {
            // Arrange
            var relativeUri = "/relative/path";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new UriString(relativeUri));
        }
    }
}