using MediatR;
using MediatrExample.Models;

namespace MediatrExample.Med.Queries
{
    public class GetProductByIdQuery : IRequest<GetProductByIdVM>
    {
        public Guid Id { get; set; }
    }

    public class ProductQueryLogEvent : INotification
    {
        public string Email { get; set; }
    }

    public class ProductQueryLogHandler : INotificationHandler<ProductQueryLogEvent>
    {
        public Task Handle(ProductQueryLogEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("test");
            return Task.CompletedTask;
        }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdVM>
    {
        private readonly IMediator mediator;

        public GetProductByIdQueryHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<GetProductByIdVM> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            await mediator.Publish(new ProductQueryLogEvent {Email = "mail"});
            return await Task.FromResult(new GetProductByIdVM()
            {
                Id = Guid.NewGuid(),
                Name = "Book"
            });             
            // get product from repository
        }
    }
}
