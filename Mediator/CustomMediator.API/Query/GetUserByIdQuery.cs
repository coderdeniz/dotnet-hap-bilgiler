using CustomMediator.Library.Interfaces;

namespace CustomMediator.API.Query
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public int Id { get; init; }

        public GetUserByIdQuery(int id)
        {
            Id = id;    
        }
    }
}
