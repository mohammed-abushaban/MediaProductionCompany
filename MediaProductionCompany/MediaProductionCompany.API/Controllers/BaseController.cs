using MediaProductionCompany.Core.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MediaProductionCompany.API.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : Controller
    {
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
    }

}
