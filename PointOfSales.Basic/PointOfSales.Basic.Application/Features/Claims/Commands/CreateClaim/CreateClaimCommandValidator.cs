using FluentValidation;
using PointOfSales.Basic.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSales.Basic.Application.Features.Claims.Commands.CreateClaim
{
    public class CreateClaimCommandValidator : AbstractValidator<CreateClaimCommand>
    {
        private readonly IClaimRepositoryAsync claimRepository;

        public CreateClaimCommandValidator(IClaimRepositoryAsync claimRepository)
        {
            this.claimRepository = claimRepository;

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
