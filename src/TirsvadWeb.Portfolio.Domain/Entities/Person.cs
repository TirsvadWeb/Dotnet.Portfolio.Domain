using TirsvadWeb.Portfolio.Domain.Interfaces;

namespace TirsvadWeb.Portfolio.Domain.Entities;

/// <summary>
/// Represents a person entity in the portfolio domain.
/// </summary>
public class Person : BaseEntity, IPerson
{
    /// <summary>
    /// Gets the full name of the person.
    /// </summary>
    public string FullName { get; private set; }

    /// <summary>
    /// Gets the biography of the person.
    /// </summary>
    public string Bio { get; private set; }

    /// <summary>
    /// Gets the profile image of the person as a base64 string or URL.
    /// </summary>
    public string ProfileImage { get; private set; }

    /// <summary>
    /// Gets the social banner image of the person as a base64 string or URL.
    /// </summary>
    public string SocialBannerImage { get; private set; }

    public bool Publish { get; private set; }

    // backing fields + read-only wrappers
    private readonly List<Project> _projects = new();
    private readonly List<Skill> _skills = new();
    private readonly List<Education> _educations = new();

    ///// <summary>
    ///// Gets the collection of projects associated with the person.
    ///// </summary>
    //public IReadOnlyCollection<Project> Projects => _projects;

    ///// <summary>
    ///// Gets the collection of skills associated with the person.
    ///// </summary>
    //public IReadOnlyCollection<Skill> Skills => _skills;

    ///// <summary>
    ///// Gets the collection of education records associated with the person.
    ///// </summary>
    //public IReadOnlyCollection<Education> Educations => _educations;

    IReadOnlyCollection<IProject> IPerson.Projects => (IReadOnlyCollection<IProject>)_projects;

    IReadOnlyCollection<ISkill> IPerson.Skills => (IReadOnlyCollection<ISkill>)_skills;

    IReadOnlyCollection<IEducation> IPerson.Educations => _educations;

    /// <summary>
    /// Initializes a new instance of the <see cref="Person"/> class.
    /// </summary>
    /// <param name="fullName">The full name of the person.</param>
    /// <param name="bio">The biography of the person.</param>
    /// <param name="profileImage">The profile image of the person as a base64 string or URL.</param>
    /// <param name="socialBannerImage">The social banner image of the person as a base64 string or URL.</param>
    public Person(Guid id, string fullName, string bio, string profileImage, string socialBannerImage, bool publish = false)
    {
        Id = id;
        FullName = fullName;
        Bio = bio;
        ProfileImage = profileImage;
        SocialBannerImage = socialBannerImage;
        Publish = publish;
    }

    /// <summary>
    /// Updates the profile information for the person.
    /// </summary>
    /// <param name="fullName">The new full name.</param>
    /// <param name="bio">The new biography.</param>
    public void UpdateProfile(string fullName, string bio, string profileImage, string socialBannerImage, bool publish)
    {
        FullName = fullName;
        Bio = bio;
        ProfileImage = profileImage;
        SocialBannerImage = socialBannerImage;
        Publish = publish;
    }
}