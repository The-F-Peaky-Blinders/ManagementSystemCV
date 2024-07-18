using AutoMapper;
using ManagementSystemCV.App.Interfaces;
using ManagementSystemCV.Infraestructures.Context;

namespace ManagementSystemCV.App.Implements
{
    public class CurriculumRepository : ICurriculum
    {
        public readonly ManagementContext _context;
        public readonly IMapper _mapper;
        public CurriculumRepository(ManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CurriculumRepository(){}

        
    }
}