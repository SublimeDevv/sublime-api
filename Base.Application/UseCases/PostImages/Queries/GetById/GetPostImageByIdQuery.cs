using Base.Application.DTOs.PostImages;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.PostImages.Queries.GetById
{
    public class GetPostImageByIdQuery : IRequest<PostImageDto>
    {
        public required Guid Id { get; set; }
    }
}
