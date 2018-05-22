using CarAds.Domain.Entities;
using CarAds.Domain.Interfaces.Repositories;
using CarAds.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarAds.Domain.Services
{
    public class MotoristaService : ServiceBase<Motorista>, IMotoristaService
    {
        private readonly IMotoristaRepository _motoristaRepository;

        public MotoristaService(IMotoristaRepository motoristaRepository) : base(motoristaRepository)
        {
            _motoristaRepository = motoristaRepository;
        }
    }
}
