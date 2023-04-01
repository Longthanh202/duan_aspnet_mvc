using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace LeThanhLong_DoAn.Filter
{
    public class Authorization: FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.HttpContext.User.IsInRole("Admin") == false)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}