using Fido2NetLib.Objects;

namespace ChatApp.Web.Contracts;

public interface IUserService
{
    Task<string> RegisterAsync(string? username, string? displayName = null,
        AttestationConveyancePreference? attestationType = null, AuthenticatorAttachment? authenticator = null,
        UserVerificationRequirement? userVerification = null, ResidentKeyRequirement? residentKey = null);
    
    Task<string> LoginAsync(string? username);
    Task<bool> IsWebAuthnSupportedAsync();

}