using Fido2NetLib.Objects;

namespace ChatApp.Security.Endpoints.Token.Post;

public class Request
{
    public string Alias { get; set; }
    public string DisplayName { get; set; }
    public AttestationConveyancePreference? attestationType { get; set; }
    public AuthenticatorAttachment? authenticator { get; set; }
    public UserVerificationRequirement? userVerification { get; set; }
    public ResidentKeyRequirement? residentKey { get; set; }
}