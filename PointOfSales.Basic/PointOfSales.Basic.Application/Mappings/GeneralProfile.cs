using AutoMapper;
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
        }
    }
}
