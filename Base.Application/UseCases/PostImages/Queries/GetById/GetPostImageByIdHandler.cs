using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.PostImages;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.PostImages.Queries.GetById
{
    public class GetPostImageByIdHandler(IPostImageRepository repository) : IRequestHandler<GetPostImageByIdQuery, PostImageDto>
    {
        private readonly IPostImageRepository _repository = repository;

        public async Task<PostImageDto> Handle(GetPostImageByIdQuery request)
        {
            var postImage = await _repository.GetByIdAsync(request.Id) ?? throw new NotFoundException();
            return new PostImageDto
            {
                Id = postImage.Id,
                ImageUrl = postImage.ImageUrl,
                Order = postImage.Order,
                PostId = postImage.PostId,
                CreatedAt = postImage.CreatedAt,
                UpdatedAt = postImage.UpdatedAt
            };
        }
    }
}
