using Base.Application.DTOs.Posts;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;
using Base.Application.Utils.Pager;

namespace Base.Application.UseCases.Posts.Queries.List
{
    public class ListPostsQuery : PagedQueryDto, IRequest<PagedResult<PostDto>>
    {
    }
}
