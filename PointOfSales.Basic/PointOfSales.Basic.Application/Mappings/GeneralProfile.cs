using AutoMapper;
using PointOfSales.Basic.Application.Features.Categories.Commands.CreateCategory;
using PointOfSales.Basic.Application.Features.Categories.Queries.GetAllCategories;
using PointOfSales.Basic.Application.Features.Claims.Commands.CreateClaim;
using PointOfSales.Basic.Application.Features.Claims.Queries.GetAllClaims;
using PointOfSales.Basic.Application.Features.Currencies.Commands.CreateCurrency;
using PointOfSales.Basic.Application.Features.Currencies.Queries.GetAllCategories;
using PointOfSales.Basic.Application.Features.Currencies.Queries.GetAllCurrencies;
using PointOfSales.Basic.Application.Features.LineItem.Commands.CreateLineItem;
using PointOfSales.Basic.Application.Features.LineItems.Queries.GetAllLineItems;
using PointOfSales.Basic.Application.Features.Products.Commands.CreateProduct;
using PointOfSales.Basic.Application.Features.Products.Queries.GetAllProducts;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSales.Basic.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();

            CreateMap<Claim, GetAllClaimsViewModel>().ReverseMap();
            CreateMap<CreateClaimCommand, Claim>();
            CreateMap<GetAllClaimsQuery, GetAllClaimsParameter>();

            CreateMap<LineItem, GetAllLineItemsViewModel>().ReverseMap();
            CreateMap<CreateLineItemCommand, LineItem>();
            CreateMap<GetAllLineItemsQuery, GetAllLineItemsParameter>();

            CreateMap<Category, GetAllCategoriesViewModel>().ReverseMap();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<GetAllCategoriesQuery, GetAllCategoriesParameter>();

            CreateMap<Currency, GetAllCurrenciesViewModel>().ReverseMap();
            CreateMap<CreateCurrencyCommand, Currency>();
            CreateMap<GetAllCurrenciesQuery, GetAllCurrenciesParameter>();

        }
    }
}
