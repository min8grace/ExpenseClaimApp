using AutoMapper;
using PointOfSales.Basic.Application.Features.LineItem.Commands.CreateLineItem;
using PointOfSales.Basic.Application.Features.LineItems.Commands.UpdateLineItem;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Model
{
    public class LineItemProfile : Profile
    {
        public LineItemProfile()
        {

            CreateMap<LineItem, EditLineItemModel>();
            CreateMap<EditLineItemModel, LineItem>();
            CreateMap<LineItem, UpdateLineItemCommand>();
            CreateMap<LineItem, CreateLineItemCommand>();
        }
    }
}
