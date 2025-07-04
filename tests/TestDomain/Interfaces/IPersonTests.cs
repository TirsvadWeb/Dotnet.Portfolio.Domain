using TirsvadWeb.Portfolio.Domain.Interfaces;

namespace TestDomain.Interfaces;

[TestClass]
public class IPersonTests
{
    private class TestPerson : IPerson
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string ProfileImage { get; set; } = string.Empty;
        public string SocialBannerImage { get; set; } = string.Empty;
        public bool Publish { get; set; }
        public IReadOnlyCollection<IProject> Projects { get; set; } = Array.Empty<IProject>();
        public IReadOnlyCollection<ISkill> Skills { get; set; } = Array.Empty<ISkill>();
        public IReadOnlyCollection<IEducation> Educations { get; set; } = Array.Empty<IEducation>();

        public void UpdateProfile(string fullName, string bio, string profileImage, string socialBannerImage, bool publish)
        {
            FullName = fullName;
            Bio = bio;
            ProfileImage = profileImage;
            SocialBannerImage = socialBannerImage;
            Publish = publish;
        }
    }

    [TestMethod]
    public void UpdateProfile_UpdatesAllProperties()
    {
        // Arrange
        var person = new TestPerson
        {
            Id = Guid.NewGuid(),
            FullName = "Old Name",
            Bio = "Old Bio",
            ProfileImage = "old.jpg",
            SocialBannerImage = "old-banner.jpg",
            Publish = false
        };

        // Act
        person.UpdateProfile("New Name", "New Bio", "new.jpg", "new-banner.jpg", true);

        // Assert
        Assert.AreEqual("New Name", person.FullName);
        Assert.AreEqual("New Bio", person.Bio);
        Assert.AreEqual("new.jpg", person.ProfileImage);
        Assert.AreEqual("new-banner.jpg", person.SocialBannerImage);
        Assert.IsTrue(person.Publish);
    }
}