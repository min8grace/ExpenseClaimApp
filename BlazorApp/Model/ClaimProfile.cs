using AutoMapper;
using BlazorApp.Pages;
using PointOfSales.Basic.Application.Features.Claims.Commands.CreateClaim;
using PointOfSales.Basic.Application.Features.Claims.Commands.UpdateClaim;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Model
{
    public class ClaimProfile : Profile
    {
        public ClaimProfile()
        {
            
            CreateMap<Claim, EditClaimModel>();
            CreateMap<EditClaimModel, Claim>();
            CreateMap<Claim, UpdateClaimCommand>();
            CreateMap<Claim, CreateClaimCommand>();
        }
    }
}
