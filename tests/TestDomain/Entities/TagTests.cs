using TirsvadWeb.Portfolio.Domain.Entities;

namespace TestDomain.Entities;

[TestClass]
public class TagTests
{
    [TestMethod]
    public void Constructor_SetsNameProperty()
    {
        // Arrange
        var name = "Backend";

        // Act
        var tag = new Tag(name);

        // Assert
        Assert.AreEqual(name, tag.Name);
    }
}