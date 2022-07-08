using magnet.Shared.Domain.Services.Communication;
namespace magnet.Author.Domain.Services.Communication;

public class AuthorResponse : BaseResponse<Models.Author>
{
    public AuthorResponse(string message) : base(message)
    {
    }

    public AuthorResponse(Models.Author resource) : base(resource)
    {
    }   
}