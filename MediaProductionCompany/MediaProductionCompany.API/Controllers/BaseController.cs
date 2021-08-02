using MediaProductionCompany.Core.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MediaProductionCompany.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]/[action]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : Controller
    {
        protected string UserId = "";
        protected APIResponseVM GetResponse(object data = null, string message = "Done")
        {
            return new APIResponseVM
            {
                Status = true,
                Message = message,
                Data = data
            };
        }
        protected APIResponseVM GetExceptionResponse(string message)
        {
            return new APIResponseVM()
            {
                Status = false,
                Message = message,
                Data = null
            };
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (User.Identity.IsAuthenticated)
            {
                UserId = User.FindFirst("UserId").Value;
            }
        }
    }

}
