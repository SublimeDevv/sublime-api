using Base.Application.DTOs.PostImages;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.PostImages.Queries.List
{
    public class ListPostImagesByPostQuery : IRequest<List<PostImageDto>>
    {
        public required Guid PostId { get; set; }
    }
}
