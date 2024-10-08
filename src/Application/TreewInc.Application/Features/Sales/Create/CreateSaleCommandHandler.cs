﻿using Microsoft.AspNetCore.Http;
using Results;
using TreewInc.Application.Abstractions.Messaging;
using TreewInc.Core.Abstractions;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.Features.Sales.Create;

public class CreateSaleCommandHandler : IHandler<CreateSaleCommand, CreateSaleCommandResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public CreateSaleCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

	public async Task<Result<CreateSaleCommandResponse>> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
	{
		var client = await _unitOfWork.Repository<Client>()
			.GetOneAsync([c => c.Id == request.ClientId], cancellationToken: cancellationToken)
			.ConfigureAwait(false);
		var productTask = _unitOfWork.Repository<Product>()
			.GetOneAsync([p => p.Id == request.ProductId], cancellationToken: cancellationToken);
		if (client is null)
			return ResultFactory.Error<CreateSaleCommandResponse>([$"Client not found with Id: {request.ClientId}"], StatusCodes.Status400BadRequest);
		var product = await productTask.ConfigureAwait(false);
		if (product is null)
			return ResultFactory.Error<CreateSaleCommandResponse>([$"Product not found with Id: {request.ProductId}"], StatusCodes.Status400BadRequest);
		if (product.Stock < request.Quantity)
			return ResultFactory.Error<CreateSaleCommandResponse>(["Product stock is not enough"], StatusCodes.Status400BadRequest);

		var sale = new Sale(client, product, request.Quantity);
		await _unitOfWork.Repository<Sale>().AddOneAsync(sale, cancellationToken).ConfigureAwait(false);
		await _unitOfWork.SaveAsync(cancellationToken).ConfigureAwait(false);
		return ResultFactory.Ok(new CreateSaleCommandResponse(sale.Id), StatusCodes.Status200OK);
	}
}