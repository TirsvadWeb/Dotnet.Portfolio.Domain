namespace TirsvadWeb.Portfolio.Domain.Interfaces;

/// <summary>
/// Defines the contract for a person entity in the portfolio domain.
/// </summary>
public interface IPerson : IHashGuidId
{
    /// <summary>
    /// Gets the full name of the person.
    /// </summary>
    string FullName { get; }

    /// <summary>
    /// Gets the biography of the person.
    /// </summary>
    string Bio { get; }

    /// <summary>
    /// Gets the profile image of the person as a base64 string or URL.
    /// </summary>
    string ProfileImage { get; }

    /// <summary>
    /// Gets the social banner image of the person as a base64 string or URL.
    /// </summary>
    string SocialBannerImage { get; }

    /// <summary>
    /// Gets a value indicating whether the person is published.
    /// </summary>
    bool Publish { get; }

    /// <summary>
    /// Gets the collection of projects associated with the person.
    /// </summary>
    IReadOnlyCollection<IProject> Projects { get; }

    /// <summary>
    /// Gets the collection of skills associated with the person.
    /// </summary>
    IReadOnlyCollection<ISkill> Skills { get; }

    /// <summary>
    /// Gets the collection of education records associated with the person.
    /// </summary>
    IReadOnlyCollection<IEducation> Educations { get; }

    /// <summary>
    /// Updates the profile information for the person.
    /// </summary>
    /// <param name="fullName">The new full name.</param>
    /// <param name="bio">The new biography.</param>
    /// <param name="profileImage">The new profile image as a base64 string or URL.</param>
    /// <param name="socialBannerImage">The new social banner image as a base64 string or URL.</param>
    /// <param name="publish">A value indicating whether the person is published.</param>
    void UpdateProfile(string fullName, string bio, string profileImage, string socialBannerImage, bool publish);
}