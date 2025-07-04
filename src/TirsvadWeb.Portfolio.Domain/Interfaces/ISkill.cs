using TirsvadWeb.Portfolio.Domain.Entities;

namespace TirsvadWeb.Portfolio.Domain.Interfaces;

/// <summary>
/// Defines the contract for a skill or technology entity associated with a person.
/// </summary>
public interface ISkill : IHashGuidId
{
    /// <summary>
    /// Gets the name of the skill or technology.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the proficiency level for this skill.
    /// </summary>
    SkillLevel Level { get; }

    /// <summary>
    /// Gets the identifier of the person who owns this skill.
    /// </summary>
    Guid PersonId { get; }

    /// <summary>
    /// Gets the person entity associated with this skill.
    /// </summary>
    IPerson Person { get; }

    /// <summary>
    /// Updates the proficiency level for this skill.
    /// </summary>
    /// <param name="newLevel">The new proficiency level.</param>
    void UpdateLevel(SkillLevel newLevel);
}