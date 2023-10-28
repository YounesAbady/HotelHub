using APIContract.BranchDTOs;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;

namespace BusinessLayer.Implementations
{
    public class Branch : IBranch
    {
        private readonly IBranchRepository _repository;
        private readonly IMapper _mapper;

        public Branch(IBranchRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BranchTinyDto>> GetAllTinyAsync()
        {
            return _mapper.Map<List<BranchTinyDto>>(await _repository.WhereAsync(x => x.IsActive));
        }
    }
}
