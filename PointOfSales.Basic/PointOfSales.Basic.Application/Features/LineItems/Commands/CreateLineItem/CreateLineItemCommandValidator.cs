using FluentValidation;
using PointOfSales.Basic.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSales.Basic.Application.Features.LineItem.Commands.CreateLineItem
{
    public class CreateLineItemCommandValidator : AbstractValidator<CreateLineItemCommand>
    {
        private readonly ILineItemRepositoryAsync lineItemRepository;

        public CreateLineItemCommandValidator(ILineItemRepositoryAsync lineItemRepository)
        {
            this.lineItemRepository = lineItemRepository;

            //RuleFor(p => p.Barcode)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
            //    .MustAsync(IsUniqueBarcode).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }

        //private async Task<bool> IsUniqueBarcode(string barcode, CancellationToken cancellationToken)
        //{
        //    return await claimRepository.IsUniqueBarcodeAsync(barcode);
        //}
    }
}
