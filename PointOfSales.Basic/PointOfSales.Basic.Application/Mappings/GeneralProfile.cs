using AutoMapper;
using PointOfSales.Basic.Application.Features.Claims.Commands.CreateClaim;
using PointOfSales.Basic.Application.Features.Claims.Queries.GetAllClaims;
using PointOfSales.Basic.Application.Features.LineItem.Commands.CreateLineItem;
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

            CreateMap<Claim, GetAllLineItemsViewModel>().ReverseMap();
            CreateMap<CreateClaimCommand, Claim>();
            CreateMap<GetAllLineItemsQuery, GetAllClaimsParameter>();

            CreateMap<ClaimLineItem, GetAllLineItemsViewModel>().ReverseMap();
            CreateMap<CreateLineItemCommand, ClaimLineItem>();
            CreateMap<GetAllLineItemsQuery, GetAllLineItemsParameter>();

        }
    }
}
