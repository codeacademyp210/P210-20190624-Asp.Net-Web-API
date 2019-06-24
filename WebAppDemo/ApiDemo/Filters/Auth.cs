using ApiDemo.DAL;
using ApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ApiDemo.Filters
{
    public class Auth : ActionFilterAttribute
    {

        private ApiDemoContext db = new ApiDemoContext();

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if(!actionContext.Request.Headers.Contains("token"))
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return;
            }
            string t = actionContext.Request.Headers.GetValues("token").FirstOrDefault();

            if (t == null)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return;
            }


            User user = db.Users.FirstOrDefault(u => u.Token == t);
            if (user == null)
            {
               actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }


            base.OnActionExecuting(actionContext);
        }
    }
}