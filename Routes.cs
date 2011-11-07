using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Web.Routing;
using Microsoft.ApplicationServer.Http;
using Microsoft.ApplicationServer.Http.Activation;
using Orchard.Mvc.Routes;
using Orchard.Wcf;
using myRestfulModule.Services;

namespace myRestfulModule
{
    public class Routes : IRouteProvider {
        private static readonly ServiceRoute _route = MapServiceRoute(typeof (PeopleService), "myRestfulModule/People");

        public IEnumerable<RouteDescriptor> GetRoutes() {
        
            
            
            return new[] {
                new RouteDescriptor {
                    Priority = 1,
                    Route = _route
                }



                

            };

            
        }

        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        private static ServiceRoute MapServiceRoute(Type serviceType, string routePrefix, HttpConfiguration configuration = null, object constraints = null, bool useMethodPrefixForHttpMethod = true)
        {
            if (configuration == null)
                configuration = new WebApiConfiguration(useMethodPrefixForHttpMethod);

            var serviceHostFactory = new HttpServiceHostFactory { Configuration = configuration };
            var webApiRoute = new WebApiRoute(routePrefix, serviceHostFactory, serviceType) { Constraints = new RouteValueDictionary(constraints) };
            return webApiRoute;
        }
    }
}
