using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Security.Principal;
using System.Threading;

namespace SalesForceNew.Class
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actioncontext)
        {
            if(actioncontext.Request.Headers.Authorization == null)
            {
                actioncontext.Response = actioncontext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string AuthonticationToken = actioncontext.Request.Headers.Authorization.Parameter;
                string DecodedAuthonticationToken= Encoding.UTF8.GetString(Convert.FromBase64String(AuthonticationToken));
                string[] UsernamePasswordArray = DecodedAuthonticationToken.Split(':');
                string Username = UsernamePasswordArray[0];
                string Password = UsernamePasswordArray[1];

                if(EmployeeSecurity.Login(Username, Password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                }
                else
                {
                    actioncontext.Response = actioncontext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}