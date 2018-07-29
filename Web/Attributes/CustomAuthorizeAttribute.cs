using System.Web;
using System.Web.Mvc;
using Core.Abstract;

namespace Web.Attributes
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly IAccessService _access;
        private readonly string[] _roles;

        public CustomAuthorizeAttribute(params string[] roles)
        {
            _access = DependencyResolver.Current.GetService<IAccessService>();
            _roles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            foreach (string role in _roles)
            {
                if (_access.CheckUserRole(httpContext.User.Identity.Name, role))
                    return true;
            }
            return false;
        }

    }
}