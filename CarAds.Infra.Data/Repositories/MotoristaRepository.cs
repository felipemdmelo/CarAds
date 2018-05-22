using CarAds.Domain.Entities;
using CarAds.Domain.Interfaces.Repositories;
using CarAds.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarAds.Infra.Data.Repositories
{
    public class MotoristaRepository : RepositoryBase<Motorista>, IMotoristaRepository
    {
        public MotoristaRepository(CarAdsContext db) : base(db)
        {
        }
    }
}
