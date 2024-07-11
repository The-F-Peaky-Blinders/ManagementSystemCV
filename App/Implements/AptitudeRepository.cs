using AutoMapper;
using managementcv.App.Interfaces;
using managementcv.Infraestructures.Context;

namespace managementcv.App.Implements
{
    public class AptitudeRepository : IAptitude
    {
        public readonly ManagementContext _context;
        public readonly IMapper _mapper;
        public AptitudeRepository(ManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AptitudeRepository(){}
    
        
    }
}