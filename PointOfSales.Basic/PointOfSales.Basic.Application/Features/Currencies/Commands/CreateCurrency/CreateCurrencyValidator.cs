using System;
using AutoMapper;
using MediatR;
using PointOfSales.Basic.Application.Interfaces.Repositories;
using PointOfSales.Basic.Application.Wrappers;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace PointOfSales.Basic.Application.Features.Currencies.Commands.CreateCurrency
{
    public class CreateCurrencyValidator : AbstractValidator<CreateCurrencyCommand>
    {
        private readonly ICurrencyRepositoryAsync currencyRepository;

        public CreateCurrencyValidator(ICurrencyRepositoryAsync currencyRepository)
        {
            this.currencyRepository = currencyRepository;

            //RuleFor(p => p.Barcode)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
            //    .MustAsync(IsUniqueBarcode).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }

        //private async Task<bool> IsUniqueBarcode(string barcode, CancellationToken cancellationToken)
        //{
        //    return await currencyRepository.IsUniqueBarcodeAsync(barcode);
        //}
    }
}
