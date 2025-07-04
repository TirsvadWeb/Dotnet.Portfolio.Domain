using TirsvadWeb.Portfolio.Domain.Interfaces;

namespace TirsvadWeb.Portfolio.Domain.Entities;

/// <summary>
/// Represents an educational experience or qualification.
/// </summary>
public class Education : BaseEntity, IEducation
{
    private const string _msgInstitutionCannotBeNullOrEmpty = "Institution name cannot be null or empty.";
    private const string _msgDegreeCannotBeNullOrEmpty = "Degree cannot be null or empty.";
    private const string _msgStartDateCannotBeInFuture = "Start date cannot be in the future.";
    private const string _msgEndDateBeforeStartDate = "End date cannot be before start date.";

    /// <summary>
    /// Gets the name of the educational institution.
    /// </summary>
    public string Institution { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the degree or qualification obtained.
    /// </summary>
    public string Degree { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the start date of the education period.
    /// </summary>
    public DateTime StartDate { get; private set; }

    /// <summary>
    /// Gets the end date of the education period, if applicable.
    /// </summary>
    public DateTime? EndDate { get; private set; }

    /// <summary>
    /// Gets the description or details about the education.
    /// </summary>
    public string Description { get; private set; } = string.Empty;

    public Education() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Education"/> class.
    /// </summary>
    /// <param name="institution">The name of the educational institution.</param>
    /// <param name="degree">The degree or qualification obtained.</param>
    /// <param name="startDate">The start date of the education period.</param>
    /// <param name="endDate">The end date of the education period, if applicable.</param>
    /// <param name="description">The description or details about the education.</param>
    /// <exception cref="ArgumentException">Thrown if the institution or degree is null or empty.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the end date is before the start date.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the start date is in the future.</exception>
    public Education(
    string institution,
    string degree,
    DateTime startDate,
    DateTime? endDate,
    string description)
    {
        if (string.IsNullOrWhiteSpace(institution))
            throw new ArgumentException(_msgInstitutionCannotBeNullOrEmpty, nameof(institution));
        if (string.IsNullOrWhiteSpace(degree))
            throw new ArgumentException(_msgDegreeCannotBeNullOrEmpty, nameof(degree));
        if (startDate > DateTime.UtcNow)
            throw new ArgumentOutOfRangeException(nameof(startDate), _msgStartDateCannotBeInFuture);
        if (endDate.HasValue && endDate < startDate)
            throw new ArgumentOutOfRangeException(nameof(endDate), _msgEndDateBeforeStartDate);

        Institution = institution;
        Degree = degree;
        StartDate = startDate;
        EndDate = endDate;
        Description = description;
    }

    /// <summary>
    /// Updates the degree, end date, and description of the education.
    /// </summary>
    /// <param name="degree">The new degree or qualification.</param>
    /// <param name="endDate">The new end date of the education period, if applicable.</param>
    /// <param name="description">The new description or details about the education.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the degree is null or empty, or if the end date is before the start date.</exception>
    /// <exception cref="ArgumentException">Thrown if the degree is null or empty.</exception>
    public void Update(
    string degree,
    DateTime? endDate,
    string description)
    {
        if (string.IsNullOrWhiteSpace(degree))
            throw new ArgumentException(_msgDegreeCannotBeNullOrEmpty, nameof(degree));
        if (endDate.HasValue && endDate < StartDate)
            throw new ArgumentOutOfRangeException(nameof(endDate), _msgEndDateBeforeStartDate);

        Degree = degree;
        EndDate = endDate;
        Description = description;
    }
}