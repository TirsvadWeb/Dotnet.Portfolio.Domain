using System.Net.Mail;
using System.Text.RegularExpressions;
using TirsvadWeb.Portfolio.Domain.Interfaces;

namespace TirsvadWeb.Portfolio.Domain.Entities;

/// <summary>
/// Represents a way to contact the person: email, phone, or social link.
/// </summary>
public class ContactInfo : BaseEntity, IContactInfo
{
    /// <summary>
    /// Gets the type of contact information (e.g., Email, Phone, Url).
    /// </summary>
    public ContactType Type { get; private set; }

    /// <summary>
    /// Gets the value of the contact information (e.g., email address, phone number, URL).
    /// </summary>
    public string Value { get; private set; }

    private static bool IsValidPhoneNumber(string value)
    {
        // Simple E.164 or international/local phone number validation
        return !string.IsNullOrWhiteSpace(value) &&
               Regex.IsMatch(value, @"^\+?[0-9\s\-()]{7,}$");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ContactInfo"/> class.
    /// Validates the value based on the contact type.
    /// </summary>
    /// <param name="type">The type of contact information.</param>
    /// <param name="value">The value of the contact information.</param>
    /// <exception cref="ArgumentException">Thrown if the value is not a valid email address or URL when the type requires it.</exception>
    /// <exception cref="ArgumentException">Thrown if the value is not a valid phone number when the type is Phone.</exception>
    /// <exception cref="ArgumentNullException">Thrown if the value is null or empty.</exception>
    public ContactInfo(ContactType type, string value)
    {
        Type = type;
        Value = type switch
        {
            ContactType.Email when !MailAddress.TryCreate(value, out _)
                => throw new ArgumentException("Invalid email", nameof(value)),
            ContactType.Url when !Uri.IsWellFormedUriString(value, UriKind.Absolute)
                => throw new ArgumentException("Invalid URL", nameof(value)),
            ContactType.Phone when !IsValidPhoneNumber(value)
                => throw new ArgumentException("Invalid phone number", nameof(value)),
            _ => value
        };
    }

    /// <summary>
    /// Updates the contact information type and value.
    /// </summary>
    /// <param name="type">The new contact type.</param>
    /// <param name="value">The new contact value.</param>
    public void Update(ContactType type, string value)
    {
        // Ensure the properties are initialized to avoid CS8618
        Type = type;
        Value = type switch
        {
            ContactType.Email when !MailAddress.TryCreate(value, out _)
                => throw new ArgumentException("Invalid email", nameof(value)),
            ContactType.Url when !Uri.IsWellFormedUriString(value, UriKind.Absolute)
                => throw new ArgumentException("Invalid URL", nameof(value)),
            ContactType.Phone when !IsValidPhoneNumber(value)
                => throw new ArgumentException("Invalid phone number", nameof(value)),
            _ => value
        };
    }
}

/// <summary>
/// Enumerates the types of contact information.
/// </summary>
public enum ContactType
{
    /// <summary>
    /// Email address.
    /// </summary>
    Email,
    /// <summary>
    /// Phone number.
    /// </summary>
    Phone,
    /// <summary>
    /// URL (e.g., website or social profile).
    /// </summary>
    Url
}
