namespace TirsvadWeb.Portfolio.Domain.Entities;

/// <summary>
/// A skill or technology the person is proficient in.
/// </summary>
public class Skill : BaseEntity
{
    /// <summary>
    /// Gets the name of the skill or technology.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the proficiency level for this skill.
    /// </summary>
    public SkillLevel Level { get; private set; }

    // NEW FK/nav
    public Guid PersonId { get; private set; }
    public Person Person { get; private set; } = null!;

    public Skill() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Skill"/> class.
    /// </summary>
    /// <param name="name">The name of the skill or technology.</param>
    /// <param name="level">The proficiency level for this skill.</param>
    public Skill(string name, SkillLevel level, Person person)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Level = level;
        Person = person ?? throw new ArgumentNullException(nameof(person));
        PersonId = person.Id;
    }

    /// <summary>
    /// Updates the proficiency level for this skill.
    /// </summary>
    /// <param name="newLevel">The new proficiency level.</param>
    public void UpdateLevel(SkillLevel newLevel) => Level = newLevel;
}

/// <summary>
/// Represents the proficiency level for a skill.
/// </summary>
public enum SkillLevel
{
    /// <summary>
    /// Beginner level.
    /// </summary>
    Beginner,
    /// <summary>
    /// Intermediate level.
    /// </summary>
    Intermediate,
    /// <summary>
    /// Advanced level.
    /// </summary>
    Advanced,
    /// <summary>
    /// Expert level.
    /// </summary>
    Expert
}
