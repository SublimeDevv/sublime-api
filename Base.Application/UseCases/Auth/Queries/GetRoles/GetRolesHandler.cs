using Base.Application.Contracts.Repositories.Auth;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Queries.GetRoles
{
    public class GetRolesHandler(IRoleRepository roleRepository) : IRequestHandler<GetRolesQuery, IList<string>>
    {
        private readonly IRoleRepository _roleRepository = roleRepository;

        public async Task<IList<string>> Handle(GetRolesQuery query)
        {
            return await _roleRepository.GetAllRolesAsync();
        }
    }
}
