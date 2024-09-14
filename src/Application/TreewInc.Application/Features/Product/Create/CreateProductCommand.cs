﻿using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Product.Create;

public record CreateProductCommand(string Name, string? Description, decimal Price, int Stock) : ICommand<CreateProductCommandResponse>;