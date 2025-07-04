using TirsvadWeb.Portfolio.Domain.Interfaces;

namespace TestDomain.Interfaces;

[TestClass]
public class IHashGuidIdTests
{
    private class TestHashGuidId : IHashGuidId
    {
        public Guid Id { get; set; }
    }

    [TestMethod]
    public void Id_Property_ReturnsExpectedGuid()
    {
        // Arrange
        var expectedId = Guid.NewGuid();
        var entity = new TestHashGuidId { Id = expectedId };

        // Act & Assert
        Assert.AreEqual(expectedId, entity.Id);
    }
}