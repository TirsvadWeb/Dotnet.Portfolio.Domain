using TirsvadWeb.Portfolio.Domain.Interfaces;

namespace TestDomain.Interfaces;

[TestClass]
public class ITagTests
{
    private class TestTag : ITag
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Hash { get; set; } = string.Empty;
    }

    [TestMethod]
    public void Name_Property_ReturnsExpectedValue()
    {
        // Arrange
        var tag = new TestTag { Name = "CSharp" };

        // Act & Assert
        Assert.AreEqual("CSharp", tag.Name);
    }
}