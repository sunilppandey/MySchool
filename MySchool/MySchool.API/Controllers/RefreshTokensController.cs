using MySchool.Data.Repositories;
using MySchool.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MySchool.API.Controllers
{
    [RoutePrefix("api/RefreshTokens")]
    public class RefreshTokensController : BaseApiController
    {
        private readonly ApplicationUserRepository _applicationUserRepository = null;

        public RefreshTokensController()
        {
            _applicationUserRepository = new ApplicationUserRepository();
        }

        [Authorize(Users = "Admin")]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_applicationUserRepository.GetAllRefreshTokens());
        }

        //[Authorize(Users = "Admin")]
        [AllowAnonymous]
        [Route("")]
        public async Task<IHttpActionResult> Delete(string tokenId)
        {
            var result = await _applicationUserRepository.RemoveRefreshToken(Helper.GetHash(tokenId));
            if (result)
            {
                return Ok();
            }
            return BadRequest("Token Id does not exist");

        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _applicationUserRepository.Dispose();
        //    }

        //    base.Dispose(disposing);
        //}
    }
}
