using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMediator.Library
{
    public class ServiceProvider
    {
        private static IServiceProvider _serviceProvider;

        public static IServiceProvider Provider => _serviceProvider;

        public static void SetInstance(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
