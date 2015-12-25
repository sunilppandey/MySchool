using MySchool.API.Models;
using MySchool.Data.Entities;
using MySchool.Data.Repositories;
using MySchool.Model.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MySchool.API.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : BaseApiController
    {
        private readonly ApplicationUserRepository _applicationUserRepository = null;

        public AccountsController()
        {
            _applicationUserRepository = new ApplicationUserRepository();
        }

        [Route("users")]
        public IHttpActionResult GetUsers()
        {
            var users = _applicationUserRepository.GetUsers();

            return Ok(users.Select(u => this.TheModelFactory.Create(u)));
        }

        [Route("user/{id:int}", Name = "GetUserById")]
        public async Task<IHttpActionResult> GetUser(int Id)
        {
            var user = await this.AppUserManager.FindByIdAsync(Id);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();

        }

        [Route("user/{username}")]
        public async Task<IHttpActionResult> GetUserByName(string username)
        {
            var user = await _applicationUserRepository.GetUserByName(username);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();

        }

        [Route("register")]
        public async Task<IHttpActionResult> CreateUser(CreateUserBindingModel createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser()
            {
                UserName = createUserModel.Username,
                Email = createUserModel.Email,
                FirstName = createUserModel.FirstName,
                LastName = createUserModel.LastName,
                Level = 3,
                JoinDate = DateTime.Now.Date
            };

            IdentityResult addUserResult = await _applicationUserRepository.CreateUser(user, createUserModel.Password);

            if (!addUserResult.Succeeded)
            {
                return GetErrorResult(addUserResult);
            }

            Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

            return Created(locationHeader, TheModelFactory.Create(user));
        }
    }
}
