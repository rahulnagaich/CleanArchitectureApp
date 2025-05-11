
using CleanArchitectureApp.Application.Interfaces.Persistence.Repositories;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, BaseResponse<Guid>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository,
            ICustomerRepository customerRepository,
            IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public async Task<BaseResponse<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // Validate Customer
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId, cancellationToken);
            if (customer is null)
                return ResponseHandler.NotFound<Guid>("Customer not found.");

            if (request.Items == null || request.Items.Count == 0)
                return ResponseHandler.NotFound<Guid>("Order must contain at least one item.");

            // Collect product IDs
            var productIds = request.Items.Select(i => i.ProductId).Distinct().ToList();

            // Get valid products from DB
            var existingProducts = await _productRepository.GetByIdAsync(productIds, cancellationToken);

            //var existingProductIds = existingProducts.Select(p => p.Id).ToHashSet();

            //// Check for missing products
            //var invalidProductIds = productIds.Except(existingProductIds).ToList();
            //if (invalidProductIds.Any())
            //{
            //    var missingIds = string.Join(", ", invalidProductIds);
            //    return ResponseHandler.NotFound<Guid>($"The following product IDs were not found: {missingIds}");
            //}

            // Create Order
            var order = new Order(Guid.NewGuid(), request.CustomerId);

            foreach (var item in request.Items)
            {
                order.AddItem(item.ProductId, item.Quantity, item.UnitPrice);
            }

            await _orderRepository.CreateAsync(order, cancellationToken);

            return ResponseHandler.Created(order.Id, "Order created successfully.");
        }
    }

}
