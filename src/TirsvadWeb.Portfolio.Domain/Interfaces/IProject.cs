using TirsvadWeb.Portfolio.Domain.ValueObjects;

namespace TirsvadWeb.Portfolio.Domain.Interfaces;

/// <summary>
/// Defines the contract for a project entity in the portfolio domain.
/// </summary>
public interface IProject : IHashGuidId
{
    /// <summary>
    /// Gets the title of the project.
    /// </summary>
    string Title { get; }

    /// <summary>
    /// Gets the description of the project.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Gets the creation date and time of the project.
    /// </summary>
    DateTime CreatedAt { get; }

    /// <summary>
    /// Gets the identifier of the person who owns the project.
    /// </summary>
    Guid PersonId { get; }

    /// <summary>
    /// Gets the author of the project.
    /// </summary>
    IPerson Author { get; }

    /// <summary>
    /// Gets the collection of tags associated with the project.
    /// </summary>
    IReadOnlyCollection<ITag> Tags { get; }

    /// <summary>
    /// Gets the live URL of the project, if available.
    /// </summary>
    UriString? LiveUrl { get; }

    /// <summary>
    /// Gets the repository URL of the project, if available.
    /// </summary>
    UriString? RepoUrl { get; }

    /// <summary>
    /// Updates the title and description of the project.
    /// </summary>
    /// <param name="title">The new title of the project.</param>
    /// <param name="description">The new description of the project.</param>
    void UpdateDetails(string title, string description);

    /// <summary>
    /// Sets the live URL of the project.
    /// </summary>
    /// <param name="url">The live URL to set, or null to clear.</param>
    void SetLiveUrl(string? url);

    /// <summary>
    /// Sets the repository URL of the project.
    /// </summary>
    /// <param name="url">The repository URL to set, or null to clear.</param>
    void SetRepoUrl(string? url);

    /// <summary>
    /// Adds a tag to the project if it is not already present.
    /// </summary>
    /// <param name="tag">The tag to add.</param>
    void AddTag(ITag tag);

    /// <summary>
    /// Removes a tag from the project if it exists.
    /// </summary>
    /// <param name="tag">The tag to remove.</param>
    void RemoveTag(ITag tag);
}