using TirsvadWeb.Portfolio.Domain.Interfaces;
using TirsvadWeb.Portfolio.Domain.ValueObjects;

namespace TestDomain.Interfaces;

[TestClass]
public class IProjectTests
{
    private class TestProject : IProject
    {
        public Guid Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid PersonId { get; private set; }
        public IPerson Author { get; private set; }
        public List<ITag> TagList { get; } = new();
        public IReadOnlyCollection<ITag> Tags => TagList.AsReadOnly();
        public UriString? LiveUrl { get; private set; }
        public UriString? RepoUrl { get; private set; }

        public TestProject(string title, string description, DateTime createdAt, Guid personId, IPerson author)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            CreatedAt = createdAt;
            PersonId = personId;
            Author = author;
        }

        public void UpdateDetails(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public void SetLiveUrl(string? url)
        {
            LiveUrl = url is null ? null : new UriString(url);
        }

        public void SetRepoUrl(string? url)
        {
            RepoUrl = url is null ? null : new UriString(url);
        }

        public void AddTag(ITag tag)
        {
            if (!TagList.Contains(tag))
                TagList.Add(tag);
        }

        public void RemoveTag(ITag tag)
        {
            TagList.Remove(tag);
        }
    }

    private class DummyPerson : IPerson
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; } = "Author";
        public string Bio { get; set; } = "";
        public string ProfileImage { get; set; } = "";
        public string SocialBannerImage { get; set; } = "";
        public bool Publish { get; set; } = true;
        public IReadOnlyCollection<IProject> Projects { get; set; } = Array.Empty<IProject>();
        public IReadOnlyCollection<ISkill> Skills { get; set; } = Array.Empty<ISkill>();
        public IReadOnlyCollection<IEducation> Educations { get; set; } = Array.Empty<IEducation>();
        public void UpdateProfile(string fullName, string bio, string profileImage, string socialBannerImage, bool publish) { }
    }

    private class DummyTag : ITag
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "Tag";
        public string Hash { get; set; } = "";
    }

    [TestMethod]
    public void UpdateDetails_UpdatesTitleAndDescription()
    {
        // Arrange
        var project = new TestProject("Old", "OldDesc", DateTime.UtcNow, Guid.NewGuid(), new DummyPerson());

        // Act
        project.UpdateDetails("New", "NewDesc");

        // Assert
        Assert.AreEqual("New", project.Title);
        Assert.AreEqual("NewDesc", project.Description);
    }

    [TestMethod]
    public void SetLiveUrl_SetsAndClearsLiveUrl()
    {
        // Arrange
        var project = new TestProject("T", "D", DateTime.UtcNow, Guid.NewGuid(), new DummyPerson());

        // Act and Assert
        project.SetLiveUrl("https://live.com");
        Assert.AreEqual("https://live.com", project.LiveUrl?.Value);
        project.SetLiveUrl(null);
        Assert.IsNull(project.LiveUrl);
    }

    [TestMethod]
    public void SetRepoUrl_SetsAndClearsRepoUrl()
    {
        // Arrange
        var project = new TestProject("T", "D", DateTime.UtcNow, Guid.NewGuid(), new DummyPerson());

        // Act and Assert
        project.SetRepoUrl("https://repo.com");
        Assert.AreEqual("https://repo.com", project.RepoUrl?.Value);
        project.SetRepoUrl(null);
        Assert.IsNull(project.RepoUrl);
    }

    [TestMethod]
    public void AddTag_AddsTagIfNotPresent()
    {
        // Arrange
        var project = new TestProject("T", "D", DateTime.UtcNow, Guid.NewGuid(), new DummyPerson());
        var tag = new DummyTag();

        // Act
        project.AddTag(tag);

        // Assert
        Assert.IsTrue(project.Tags.Contains(tag));
    }

    [TestMethod]
    public void RemoveTag_RemovesTagIfPresent()
    {
        // Arrange
        var project = new TestProject("T", "D", DateTime.UtcNow, Guid.NewGuid(), new DummyPerson());
        var tag = new DummyTag();

        // Act
        project.AddTag(tag);
        project.RemoveTag(tag);

        // Assert
        Assert.IsFalse(project.Tags.Contains(tag));
    }
}