using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Authentication.Login;

public record LoginQuery(string Email, string Password) : IQuery<LoginQueryResponse>;