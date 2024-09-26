﻿using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.GraphQL.Abstractions.Services;

public interface IClientService
{
	Task<ILookup<int, Sale>> GetSalesByClientIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
}
