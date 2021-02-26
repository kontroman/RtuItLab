﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ServicesDtoModels.Models.Identity;
using System;

namespace Shops.API.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!(context.HttpContext.Items["User"] is User))
                context.Result = new JsonResult(new { message = "Unauthorized" })
                    { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}
