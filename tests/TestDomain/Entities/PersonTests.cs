using TirsvadWeb.Portfolio.Domain.Entities;

namespace TestDomain.Entities;

[TestClass]
public sealed class PersonTests
{
    [TestMethod]
    public void Person_Constructor_SetsPropertiesCorrectly()
    {
        // Arrange
        var id = Guid.NewGuid();
        var fullName = "John Doe";
        var bio = "A passionate developer.";
        var profileImage = "profile.jpg";
        var socialBannerImage = "banner.jpg";
        var publish = true;

        // Act
        var person = new Person(id, fullName, bio, profileImage, socialBannerImage, publish);

        // Assert
        Assert.AreEqual(id, person.Id);
        Assert.AreEqual(fullName, person.FullName);
        Assert.AreEqual(bio, person.Bio);
        Assert.AreEqual(profileImage, person.ProfileImage);
        Assert.AreEqual(socialBannerImage, person.SocialBannerImage);
        Assert.AreEqual(publish, person.Publish);
    }

    [TestMethod]
    public void Person_UpdateProfile_UpdatesProperties()
    {
        // Arrange
        var person = new Person(Guid.NewGuid(), "Jane Doe", "Bio", "img1.jpg", "banner1.jpg");
        var newFullName = "Jane Smith";
        var newBio = "Updated bio";
        var newProfileImage = "img2.jpg";
        var newBannerImage = "banner2.jpg";
        var newPublish = true;

        // Act
        person.UpdateProfile(newFullName, newBio, newProfileImage, newBannerImage, newPublish);

        // Assert
        Assert.AreEqual(newFullName, person.FullName);
        Assert.AreEqual(newBio, person.Bio);
        Assert.AreEqual(newProfileImage, person.ProfileImage);
        Assert.AreEqual(newBannerImage, person.SocialBannerImage);
        Assert.AreEqual(newPublish, person.Publish);
    }
}