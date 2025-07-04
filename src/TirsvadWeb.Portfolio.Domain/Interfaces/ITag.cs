namespace TirsvadWeb.Portfolio.Domain.Interfaces;

/// <summary>
/// Defines the contract for a tag entity used for categorizing portfolio items.
/// </summary>
public interface ITag : IHashGuidId
{
    /// <summary>
    /// Gets the name of the tag.
    /// </summary>
    string Name { get; }
}