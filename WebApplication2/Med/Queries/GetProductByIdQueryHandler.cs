using MediatR;
using WebApplication2.Models;

namespace WebApplication2.Med.Queries
{

    /*
        CQRS'in temel amacı sistem üzerindeki isteklerin durumlarının kontrolü. 2 durumu var 
        Commands: verilerin değişikliği üzerine,WriteStorage'dan data işlemleri gerçekleştiriliyor.
        Query: verilerin değişmeden sorgulanması, ReadStorage'den direk data okunup Presentation'a getiriliyor.
        Amaç: write ve read işlemlerinin birbirinden db olarak ayrılması
        İki db arasıdaki senkronize işlemi gerçekleştiriliyor
    */

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdViewModel>
    {
        public Task<GetProductByIdViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            

            // get product from repository
        }
    }
}
