using System.Text;
using ChatApp.Core.Entities;
using ChatApp.EntityFrameworkCore.Data;
using FastEndpoints;
using Fido2NetLib;
using Fido2NetLib.Objects;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Security.Endpoints.Token.Post;

public class Endpoint : Endpoint<Request, CredentialCreateOptions>
{
    private readonly IFido2 _fido2;
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

    public Endpoint(IFido2 fido2, IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        _fido2 = fido2;
        _dbContextFactory = dbContextFactory;

    }
    
    public override void Configure()
    {
        Post("/api/token");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var key = req.Alias;
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync(ct);

        var user = new User
            {
                DisplayName = req.DisplayName,
                Name = key,
                Id = Encoding.UTF8.GetBytes(key)
            };

        dbContext.Users.Add(user);
        
        var authenticatorSelection = AuthenticatorSelection.Default;
        if (req.authenticator != null)
        {
            authenticatorSelection.AuthenticatorAttachment = req.authenticator;
        }

        if (req.userVerification != null)
        {
            authenticatorSelection.UserVerification = req.userVerification.Value;
        }

        if (req.residentKey != null)
        {
            authenticatorSelection.ResidentKey = req.residentKey.Value;
        }

        var fidoUser = new Fido2User
            {
                DisplayName = user.DisplayName,
                Name = user.Name,
                Id = user.Id
            };

        var existingKeys = dbContext.Credentials
            .AsEnumerable()
            .Where(c => c.UserId.AsSpan()
                .SequenceEqual(user.Id))
            .Select(c => c.Descriptor)
            .ToList();

        // 4. Create options
        var options = _fido2.RequestNewCredential(new RequestNewCredentialParams
            {
                User = fidoUser,
                ExcludeCredentials = existingKeys,
                AuthenticatorSelection = authenticatorSelection,
                AttestationPreference = req.attestationType ?? AttestationConveyancePreference.None,
                Extensions = new AuthenticationExtensionsClientInputs
                    {
                        Extensions = true,
                        UserVerificationMethod = true,
                        CredProps = true
                    }
            });
        
        await SendOkAsync(options, ct);
    }
}