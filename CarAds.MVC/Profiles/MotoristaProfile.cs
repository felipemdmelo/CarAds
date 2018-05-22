using AutoMapper;
using CarAds.Domain.Entities;
using CarAds.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAds.MVC.AutoMapper
{
    public class MotoristaProfile : Profile
    {
        public MotoristaProfile()
        {
            CreateMap<Motorista, MotoristaViewModel>();
            CreateMap<MotoristaViewModel, Motorista>();
        }
    }
}
