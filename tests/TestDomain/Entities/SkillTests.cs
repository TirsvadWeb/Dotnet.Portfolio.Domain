using TirsvadWeb.Portfolio.Domain.Entities;

namespace TestDomain.Entities;

[TestClass]
public class SkillTests
{
    private static Person CreatePerson() =>
        new Person(Guid.NewGuid(), "Jane Doe", "Bio", "profile.jpg", "banner.jpg");

    [TestMethod]
    public void Constructor_SetsAllProperties()
    {
        // Arrange
        var person = CreatePerson();

        // Act
        var skill = new Skill("C#", SkillLevel.Expert, person);

        // Assert
        Assert.AreEqual("C#", skill.Name);
        Assert.AreEqual(SkillLevel.Expert, skill.Level);
        Assert.AreEqual(person, skill.Person);
        Assert.AreEqual(person.Id, skill.PersonId);
    }

    [TestMethod]
    public void Constructor_ThrowsIfNameNull()
    {
        // Arrange
        var person = CreatePerson();

        // Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() => new Skill(null!, SkillLevel.Beginner, person));
    }

    [TestMethod]
    public void Constructor_ThrowsIfPersonNull()
    {
        // Act, Assert
        Assert.ThrowsException<ArgumentNullException>(() => new Skill("C#", SkillLevel.Beginner, null!));
    }

    [TestMethod]
    public void UpdateLevel_ChangesLevel()
    {
        // Arrange
        var person = CreatePerson();
        var skill = new Skill("C#", SkillLevel.Beginner, person);

        // Act
        skill.UpdateLevel(SkillLevel.Advanced);

        // Assert
        Assert.AreEqual(SkillLevel.Advanced, skill.Level);
    }
}