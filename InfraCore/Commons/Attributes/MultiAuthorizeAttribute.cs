using Microsoft.AspNetCore.Authorization;

namespace InfraCore.Commons.Attributes
{
    public class MultiAuthorizeAttribute : AuthorizeAttribute
    {
        public MultiAuthorizeAttribute(params string[] roles) : base()
        {
            if (roles != null && roles.Length > 0)
            {
                Roles = string.Join(",", roles);
            }
        }
    }
}
