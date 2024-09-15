using Riok.Mapperly.Abstractions;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.Dtos.Mappers;

[Mapper]
public static partial class ClientMapper
{
	public static partial ClientDto MapToClientDto(this Client client);
}
