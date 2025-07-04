using TirsvadWeb.Portfolio.Domain.Entities;
using TirsvadWeb.Portfolio.Domain.Interfaces;

namespace TestDomain.Interfaces;

[TestClass]
public class ISkillTests
{
    private class DummyPerson : IPerson
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; } = "Test Person";
        public string Bio { get; set; } = "";
        public string ProfileImage { get; set; } = "";
        public string SocialBannerImage { get; set; } = "";
        public bool Publish { get; set; } = true;
        public IReadOnlyCollection<IProject> Projects { get; set; } = Array.Empty<IProject>();
        public IReadOnlyCollection<ISkill> Skills { get; set; } = Array.Empty<ISkill>();
        public IReadOnlyCollection<IEducation> Educations { get; set; } = Array.Empty<IEducation>();
        public void UpdateProfile(string fullName, string bio, string profileImage, string socialBannerImage, bool publish) { }
    }

    private class TestSkill : ISkill
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public SkillLevel Level { get; private set; }
        public Guid PersonId { get; private set; }
        public IPerson Person { get; private set; }

        public TestSkill(string name, SkillLevel level, Guid personId, IPerson person)
        {
            Id = Guid.NewGuid();
            Name = name;
            Level = level;
            PersonId = personId;
            Person = person;
        }

        public void UpdateLevel(SkillLevel newLevel)
        {
            Level = newLevel;
        }
    }

    [TestMethod]
    public void UpdateLevel_ChangesSkillLevel()
    {
        // Arrange
        var person = new DummyPerson();
        var skill = new TestSkill("C#", SkillLevel.Beginner, person.Id, person);

        // Act
        skill.UpdateLevel(SkillLevel.Expert);

        // Assert
        Assert.AreEqual(SkillLevel.Expert, skill.Level);
    }

    [TestMethod]
    public void Properties_AreSetCorrectly()
    {
        // Arrange
        var person = new DummyPerson();
        var skill = new TestSkill("SQL", SkillLevel.Intermediate, person.Id, person);

        // Assert
        Assert.AreEqual("SQL", skill.Name);
        Assert.AreEqual(SkillLevel.Intermediate, skill.Level);
        Assert.AreEqual(person.Id, skill.PersonId);
        Assert.AreEqual(person, skill.Person);
    }
}