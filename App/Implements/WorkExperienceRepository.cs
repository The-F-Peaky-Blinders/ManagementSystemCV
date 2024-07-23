using AutoMapper;
using ManagementSystemCV.App.Interfaces;
using ManagementSystemCV.Infraestructures.Context;

namespace ManagementSystemCV.App.Implements
{
    public class WorkExperienceRepository : IWorkExperience
    {
        public readonly ManagementContext _context;
        public readonly IMapper _mapper;
        public WorkExperienceRepository(ManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public WorkExperienceRepository(){}
        
    }
}