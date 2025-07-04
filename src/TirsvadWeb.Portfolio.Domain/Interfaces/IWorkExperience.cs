namespace TirsvadWeb.Portfolio.Domain.Interfaces;

/// <summary>
/// Defines the contract for a professional work experience entry.
/// </summary>
public interface IWorkExperience : IHashGuidId
{
    /// <summary>
    /// Gets the company name.
    /// </summary>
    string Company { get; }

    /// <summary>
    /// Gets the role or job title.
    /// </summary>
    string Role { get; }

    /// <summary>
    /// Gets the start date of the work experience.
    /// </summary>
    DateTime StartDate { get; }

    /// <summary>
    /// Gets the end date of the work experience, if applicable.
    /// </summary>
    DateTime? EndDate { get; }

    /// <summary>
    /// Gets the responsibilities or description of the work experience.
    /// </summary>
    string Responsibilities { get; }

    /// <summary>
    /// Updates the role, end date, and responsibilities of the work experience.
    /// </summary>
    /// <param name="role">The new role or job title.</param>
    /// <param name="endDate">The new end date, if applicable.</param>
    /// <param name="responsibilities">The new responsibilities or description.</param>
    void Update(string role, DateTime? endDate, string responsibilities);
}