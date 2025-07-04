using TirsvadWeb.Portfolio.Domain.Entities;

namespace TestDomain.Entities;

[TestClass]
public class ProjectTests
{
    private static Person CreateAuthor() =>
        new Person(Guid.NewGuid(), "Author", "Bio", "profile.jpg", "banner.jpg");

    [TestMethod]
    public void Constructor_SetsAllProperties()
    {
        // Arrange
        var title = "Project X";
        var description = "A test project";
        var personId = Guid.NewGuid();
        var author = CreateAuthor();
        var liveUrl = "https://live.com";
        var repoUrl = "https://repo.com";

        // Act
        var project = new Project(title, description, personId, author, liveUrl, repoUrl);

        // Assert
        Assert.AreEqual(title, project.Title);
        Assert.AreEqual(description, project.Description);
        Assert.AreEqual(personId, project.PersonId);
        Assert.AreEqual(author, project.Author);
        Assert.AreEqual(liveUrl, project.LiveUrl?.Value);
        Assert.AreEqual(repoUrl, project.RepoUrl?.Value);
        Assert.IsTrue((DateTime.UtcNow - project.CreatedAt).TotalSeconds < 5);
    }

    [TestMethod]
    public void Constructor_ThrowsIfTitleNull()
    {
        // Arrange
        var author = CreateAuthor();

        // Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            _ = new Project(null!, "desc", Guid.NewGuid(), author);
        });
    }

    [TestMethod]
    public void Constructor_ThrowsIfDescriptionNull()
    {
        // Arrange
        var author = CreateAuthor();

        // Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            _ = new Project("title", null!, Guid.NewGuid(), author);
        });
    }

    [TestMethod]
    public void Constructor_ThrowsIfAuthorNull()
    {
        // Arrange & Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            _ = new Project("title", "desc", Guid.NewGuid(), null!);
        });
    }

    [TestMethod]
    public void UpdateDetails_UpdatesTitleAndDescription()
    {
        // Arrange
        var project = new Project("Old", "OldDesc", Guid.NewGuid(), CreateAuthor());

        // Act
        project.UpdateDetails("New", "NewDesc");

        // Assert
        Assert.AreEqual("New", project.Title);
        Assert.AreEqual("NewDesc", project.Description);
    }

    [TestMethod]
    public void UpdateDetails_ThrowsIfTitleNullOrWhitespace()
    {
        // Arrange
        var project = new Project("Old", "OldDesc", Guid.NewGuid(), CreateAuthor());

        // Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            project.UpdateDetails(null!, "desc");
        });
    }

    [TestMethod]
    public void UpdateDetails_ThrowsIfDescriptionNullOrWhitespace()
    {
        // Arrange
        var project = new Project("Old", "OldDesc", Guid.NewGuid(), CreateAuthor());

        // Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            project.UpdateDetails("title", null!);
        });
    }

    [TestMethod]
    public void SetLiveUrl_SetsAndClearsLiveUrl()
    {
        // Arrange
        var project = new Project("T", "D", Guid.NewGuid(), CreateAuthor());

        // Act & Assert
        project.SetLiveUrl("https://live.com");
        Assert.AreEqual("https://live.com", project.LiveUrl?.Value);
        project.SetLiveUrl(null);
        Assert.IsNull(project.LiveUrl);
    }

    [TestMethod]
    public void SetRepoUrl_SetsAndClearsRepoUrl()
    {
        // Arrange
        var project = new Project("T", "D", Guid.NewGuid(), CreateAuthor());

        // Act & Assert
        project.SetRepoUrl("https://repo.com");
        Assert.AreEqual("https://repo.com", project.RepoUrl?.Value);
        project.SetRepoUrl(null);
        Assert.IsNull(project.RepoUrl);
    }

    [TestMethod]
    public void AddTag_AddsTagIfNotPresent()
    {
        // Arrange
        var project = new Project("T", "D", Guid.NewGuid(), CreateAuthor());
        var tag = new Tag("Backend");

        // Act
        project.AddTag(tag);

        // Assert
        Assert.IsTrue(project.Tags.Contains(tag));
    }

    [TestMethod]
    public void RemoveTag_RemovesTagIfPresent()
    {
        // Arrange
        var project = new Project("T", "D", Guid.NewGuid(), CreateAuthor());
        var tag = new Tag("Backend");

        // Act
        project.AddTag(tag);
        project.RemoveTag(tag);

        // Assert
        Assert.IsFalse(project.Tags.Contains(tag));
    }

    [TestMethod]
    public void AddTag_ThrowsIfNull()
    {
        // Arrange
        var project = new Project("T", "D", Guid.NewGuid(), CreateAuthor());

        // Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            project.AddTag(null!);
        });
    }

    [TestMethod]
    public void RemoveTag_ThrowsIfNull()
    {
        // Arrange
        var project = new Project("T", "D", Guid.NewGuid(), CreateAuthor());

        // Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            project.RemoveTag(null!);
        });
    }
}