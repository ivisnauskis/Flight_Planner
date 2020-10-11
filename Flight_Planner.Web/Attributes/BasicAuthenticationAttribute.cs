﻿using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Flight_Planner.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization != null)
            {
                var authToken = actionContext.Request.Headers.Authorization.Parameter;

                var decoded = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));

                var userNameAndPw = decoded.Split(':');
                var userName = userNameAndPw[0];
                var password = userNameAndPw[1];

                if (userName == "codelex-admin" && password == "Password123")
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userNameAndPw[0]), null);
                else
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
    }
}