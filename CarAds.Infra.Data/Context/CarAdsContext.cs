using CarAds.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarAds.Infra.Data.Context
{
    public class CarAdsContext : DbContext
    {
        public CarAdsContext(DbContextOptions<CarAdsContext> options) : base(options)
        { }
        
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
