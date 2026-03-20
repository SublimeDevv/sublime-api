using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Queries.GetRoles
{
    public class GetRolesQuery : IRequest<IList<string>> { }
}
