namespace ChatApp.Core.Entities;

/// <summary>
/// The user entity.
/// </summary>
public class User
{
    /// <summary>
    /// The Id (Primary key).
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The UserName used for logging in.
    /// </summary>
    public string UserName { get; set; }
    
    /// <summary>
    /// The Email Address of the user.
    /// </summary>
    public string EmailAddress { get; set; }
}