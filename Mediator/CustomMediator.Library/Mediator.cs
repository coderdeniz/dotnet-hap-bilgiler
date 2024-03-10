using CustomMediator.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMediator.Library
{
    public class Mediator : IMediator
    {
        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            // request -> getuserbyıdquery
            // response -> userviewmodel

            var reqType = request.GetType();
            
            var reqTypeInterface = reqType.GetInterfaces().Where(i => i.IsGenericType
            && i.GetGenericTypeDefinition() == typeof(IRequest<>)).FirstOrDefault();

            // IRequest<GetUserViewModel>

            var responseType = reqTypeInterface.GetGenericArguments()[0];

            var genericType = typeof(IRequestHandler<,>).MakeGenericType(reqType,responseType);

            var handler = ServiceProvider.Provider.GetService(genericType);

            return (Task<TResponse>)genericType.GetMethod("Handle").Invoke(handler, new object[]
            {
                request
            });

        }
    }
}
