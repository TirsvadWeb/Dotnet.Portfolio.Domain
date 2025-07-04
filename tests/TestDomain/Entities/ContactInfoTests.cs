using TirsvadWeb.Portfolio.Domain.Entities;

namespace TestDomain.Entities;

[TestClass]
public class ContactInfoTests
{
    [TestMethod]
    public void Constructor_Email_ValidatesCorrectly()
    {
        // Arrange
        var info = new ContactInfo(ContactType.Email, "test@example.com");

        // Act & Assert
        Assert.AreEqual(ContactType.Email, info.Type);
        Assert.AreEqual("test@example.com", info.Value);
    }

    [TestMethod]
    public void Constructor_Email_Invalid_Throws()
    {
        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => new ContactInfo(ContactType.Email, "not-an-email"));
    }

    [TestMethod]
    public void Constructor_Url_ValidatesCorrectly()
    {
        // Arrange
        var info = new ContactInfo(ContactType.Url, "https://example.com");

        // Act & Assert
        Assert.AreEqual(ContactType.Url, info.Type);
        Assert.AreEqual("https://example.com", info.Value);
    }

    [TestMethod]
    public void Constructor_Url_Invalid_Throws()
    {
        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => new ContactInfo(ContactType.Url, "not-a-url"));
    }

    [TestMethod]
    public void Constructor_Phone_ValidatesCorrectly()
    {
        // Arrange
        var info = new ContactInfo(ContactType.Phone, "+1 234-567-8900");

        // Act & Assert
        Assert.AreEqual(ContactType.Phone, info.Type);
        Assert.AreEqual("+1 234-567-8900", info.Value);
    }

    [TestMethod]
    public void Constructor_Phone_Empty_Throws()
    {
        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => new ContactInfo(ContactType.Phone, ""));
    }

    [TestMethod]
    public void Constructor_Phone_Invalid_Throws()
    {
        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => new ContactInfo(ContactType.Phone, "abc"));
    }

    [TestMethod]
    public void Update_ValidatesAndUpdates()
    {
        // Arrange
        var info = new ContactInfo(ContactType.Email, "test@example.com");

        // Act
        info.Update(ContactType.Phone, "+45 12345678");

        // Assert
        Assert.AreEqual(ContactType.Phone, info.Type);
        Assert.AreEqual("+45 12345678", info.Value);
    }

    [TestMethod]
    public void Update_InvalidPhone_Throws()
    {
        // Arrange
        var info = new ContactInfo(ContactType.Email, "test@example.com");

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => info.Update(ContactType.Phone, "notaphone"));
    }
}