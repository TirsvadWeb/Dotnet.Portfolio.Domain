using TirsvadWeb.Portfolio.Domain.Entities;
using TirsvadWeb.Portfolio.Domain.Interfaces;

namespace TestDomain.Interfaces;

[TestClass]
public class IContactInfoTests
{
    private class TestContactInfo : IContactInfo
    {
        public Guid Id { get; set; }
        public string Hash { get; set; } = string.Empty;
        public ContactType Type { get; private set; }
        public string Value { get; private set; } = string.Empty;

        public void Update(ContactType type, string value)
        {
            Type = type;
            Value = value;
        }
    }

    [TestMethod]
    public void Update_ChangesTypeAndValue()
    {
        // Arrange
        var contact = new TestContactInfo();
        var newType = ContactType.Email;
        var newValue = "test@example.com";

        // Act
        contact.Update(newType, newValue);

        // Assert
        Assert.AreEqual(newType, contact.Type);
        Assert.AreEqual(newValue, contact.Value);
    }
}