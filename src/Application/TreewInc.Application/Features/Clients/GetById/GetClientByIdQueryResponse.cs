using TreewInc.Application.Dtos;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.Features.Clients.GetById;

public record GetClientByIdQueryResponse(ClientDto Client);