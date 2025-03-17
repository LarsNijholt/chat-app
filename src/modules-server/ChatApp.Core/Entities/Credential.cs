
namespace ChatApp.Core.Entities;

/// <summary>
/// A class representing a credential for webauthn.
/// </summary>
public class Credential
{
    /// <summary>
    /// The id for the credential.
    /// </summary>
    public int CredentialId { get; set; }
    
    /// <summary>
    /// The Id that related to the <see cref="User"/>.
    /// </summary>
    public int UserId { get; set; }
    
    /// <summary>
    /// The public key class
    /// </summary>
    public string PublicKey { get; set; }
    
    /// <summary>
    /// The Sign Count.
    /// </summary>
    public int SignCount { get; set; }
    
    /// <summary>
    /// The Created date for the credential.
    /// </summary>
    public DateTimeOffset CreatedDate { get; set; }
    
    /// <summary>
    /// The date the credential was last used.
    /// </summary>
    public DateTimeOffset LastUsedDate { get; set; }
}