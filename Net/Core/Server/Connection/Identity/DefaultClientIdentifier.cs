using System.Net.Sockets;

namespace Net.Core.Server.Connection.Identity;

/// <summary>
/// Serves as a base class for <see cref="IClientIdentifier"/>
/// </summary>
public class DefaultId : IClientIdentifier
{
    public DefaultId()
    {
    }

    public DefaultId(string Name)
    {
        this.Name = Name;
    }

    /// <summary>
    /// The clients unique identifier.
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    /// The clients display name.
    /// </summary>
    public string Name { get; init; } = default!;

    /// <summary>
    /// The clients socket. This will be null when the data has been sent from
    /// a client. It should be set on the server side once the client has sent
    /// it's <see cref="IClientIdentifier"/> instance.
    /// </summary>
    public Socket? Socket { get; init; } = default;
}