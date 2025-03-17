using FastEndpoints;

namespace ChatApp.Server.Endpoints;

/// <summary>
/// Test endpoint for fast endpoints.
/// </summary>
public class Counter : EndpointWithoutRequest
{
    /// <inheritdoc />
    public override void Configure()
    {
        Get("/api/counter");
        AllowAnonymous();
    }

    /// <inheritdoc />
    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendOkAsync(ct);
    }
}