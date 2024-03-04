using MediatR;
using WebApplication2.Models;

namespace WebApplication2.Med.Queries
{

    public class GetProductByIdQuery : IRequest<GetProductByIdViewModel>
    {
        public Guid Id { get; set; }

    }
}
