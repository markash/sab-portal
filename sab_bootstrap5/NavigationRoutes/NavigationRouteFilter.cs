using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using Marketing;
using Models;
using System.Web.Security;

namespace NavigationRoutes
{
    public class NavigationRouteFilter : INavigationRouteFilter
    {
        public bool ShouldRemove(Route route)
        {
            return true;
        }
    }

    public class AuthorizationRouteFilter : INavigationRouteFilter
    {
        public bool ShouldRemove(Route route)
        {
            bool test = Roles.IsUserInRole("Administrator");
            if (!Security.CurrentUserIsAuthenticated())
            {
                return true;
            }
            else if (route.Url.ToUpper().Contains("MAINTAIN") && !Security.CurrentUserInRole(ApplicationRole.Administrator))
            {
                return true;
            }
            else if (route.Url.ToUpper().Contains("REPORT") && !Security.CurrentUserInRole(ApplicationRole.Administrator))
            {
                return true;
            }

            return false;
        }
    }
}
