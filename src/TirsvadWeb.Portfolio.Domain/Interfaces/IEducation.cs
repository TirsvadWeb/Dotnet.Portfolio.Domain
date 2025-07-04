namespace TirsvadWeb.Portfolio.Domain.Interfaces;

/// <summary>
/// Defines the contract for an educational experience or qualification.
/// </summary>
public interface IEducation : IHashGuidId
{
    /// <summary>
    /// Gets the name of the educational institution.
    /// </summary>
    string Institution { get; }

    /// <summary>
    /// Gets the degree or qualification obtained.
    /// </summary>
    string Degree { get; }

    /// <summary>
    /// Gets the start date of the education period.
    /// </summary>
    DateTime StartDate { get; }

    /// <summary>
    /// Gets the end date of the education period, if applicable.
    /// </summary>
    DateTime? EndDate { get; }

    /// <summary>
    /// Gets the description or details about the education.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Updates the degree, end date, and description of the education.
    /// </summary>
    /// <param name="degree">The new degree or qualification.</param>
    /// <param name="endDate">The new end date of the education period, if applicable.</param>
    /// <param name="description">The new description or details about the education.</param>
    void Update(string degree, DateTime? endDate, string description);
}