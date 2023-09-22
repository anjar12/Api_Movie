using Domain.Interfaces;
using Domain.Model;
using Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_Movie.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWorks _unitOfWork;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUnitOfWorks unitOfWork, ILogger<AuthController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("Auth/Acces")]

        public ActionResult<AuthToken> Access()
        {
            string Key = string.Empty;
            if (HttpContext.Request.Headers.TryGetValue(Settings.headerNameKey, out var value))
            {
                Key = value;
            }

            if (Key == Settings.headerValueKey)
            {
                AuthToken response = _unitOfWork.auth.PageGenerateToken("JwtAccess", "access");
                if (response != null)
                {
                    return response;
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
