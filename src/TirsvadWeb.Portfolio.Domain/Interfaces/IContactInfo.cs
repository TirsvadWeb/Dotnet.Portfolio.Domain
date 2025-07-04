using TirsvadWeb.Portfolio.Domain.Entities;

namespace TirsvadWeb.Portfolio.Domain.Interfaces;

/// <summary>
/// Defines the contract for a contact information entry associated with a person.
/// </summary>
public interface IContactInfo : IHashGuidId
{
    /// <summary>
    /// Gets the type of contact information (e.g., Email, Phone, Url).
    /// </summary>
    ContactType Type { get; }

    /// <summary>
    /// Gets the value of the contact information (e.g., email address, phone number, or URL).
    /// </summary>
    string Value { get; }

    /// <summary>
    /// Updates the type and value of the contact information.
    /// </summary>
    /// <param name="type">The new contact type.</param>
    /// <param name="value">The new contact value.</param>
    void Update(ContactType type, string value);
}