using CustomMediator.Library.Interfaces;

namespace CustomMediator.API.Query
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        public Task<UserViewModel> Handle(GetUserByIdQuery request)
        {
            // get data from db

            return Task.FromResult(new UserViewModel
            {
                FirstName = "Deniz",
                LastName = "Duman"
            });
        }
    }
}
